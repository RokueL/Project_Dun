using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyControl : MonoBehaviour
{
    public float Find_Distance = 5f;
    public float Attack_Distance = 2f;

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
                if (isAttack == false)
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
        agent.Stop();
        isAttack = true;
        Debug.Log("공격모션");
        yield return new WaitForSeconds(2f);
        Debug.Log("공격끝");
        isAttack = false;
        agent.Resume();
        state = State.Patrol;
    }

    void Chase()
    {
        if (target != null)
        {
                agent.SetDestination(target.transform.position);
                agent.speed = enemySpeed;

            float distance = Vector3.Distance(target.transform.position, transform.position);

            if(distance <= Attack_Distance)
            {
                state = State.Attack;
            }
        }
    }


}
