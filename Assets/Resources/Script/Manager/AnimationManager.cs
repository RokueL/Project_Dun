using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    public Animator animator;


    bool isWalk = false;
    private void Update()
    {
        inputAnimation();
        stateAnimation();
    }
    void stateAnimation()
    {
        animator.SetBool("isWalk", isWalk);
    }
    void inputAnimation()
    {
        animator.SetBool("isWalk", isWalk);
        if (Input.GetKey(KeyCode.W))
        {
            isWalk = true;
        }
        else
        {

            isWalk = false;
        }
    }
}
