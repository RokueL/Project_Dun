using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyControl : MonoBehaviour
{
    public float HP = 100f;

    public float Find_Distance = 5f;
    float Attack_Distance = 1.8f;

    public float enemySpeed = 2f;
    
    public GameObject target;
    bool isAttack = false;

    tracking tracking;
    NavMeshAgent agent;

    [SerializeField]enum State { 
    Patrol,
    Chase,
    Attack,
    Attackbegin
    }

    [SerializeField]State state;

    // Start is called before the first frame update
    void Start()
    {
        tracking = GetComponentInChildren<tracking>();
        agent = GetComponent<NavMeshAgent>();

        Setup();
    }

    // Update is called once per frame
    void Update()
    {
        target = tracking.track;
    }

    void Setup()
    {
        agent.speed = enemySpeed;
        agent.stoppingDistance = Attack_Distance;

    }

    private void FixedUpdate()
    {
        switch (state)
        {
            case State.Patrol:
                if(target != null && isAttack == false)
                {
                    Debug.Log(tracking);
                    state = State.Chase;
                }
                break;
            case State.Chase:
                Chase();
                break;
            case State.Attack:
                if (!isAttack)
                {
                    StartCoroutine(Attack());
                }
                break;
            default:
                state = State.Patrol;
                break;
        }
    }

    IEnumerator Attack()
    {
        Debug.Log("공격모션");
        isAttack = true;
        agent.Stop();
        yield return new WaitForSeconds(2f);
        Debug.Log("공격끝");
        agent.Resume();
        isAttack = false;
        state = State.Patrol;
    }

    void Chase()
    {
        if (target != null)
        {
                agent.SetDestination(target.transform.position);
                agent.speed = enemySpeed;

            float distance = Vector3.Distance(target.transform.position, transform.position);

            if(distance <= 2)
            {
                state = State.Attack;
            }
        }
    }


}
