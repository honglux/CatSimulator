using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchIdle : StateMachineBehaviour
{
    readonly float minTime = 3.0f;
    readonly float maxTime = 7.0f;

    float timer = 0.0f;

    public string[] triggers = {};
    public string current;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    //override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (timer <= 0)
        {
            RandomIdle(animator);
            timer = Random.Range(minTime, maxTime);
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }

    void RandomIdle(Animator animator)
    {
        System.Random rdm = new System.Random();
        int index = rdm.Next(triggers.Length);
        string theTrigger = triggers[index];
        animator.SetTrigger(theTrigger);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
