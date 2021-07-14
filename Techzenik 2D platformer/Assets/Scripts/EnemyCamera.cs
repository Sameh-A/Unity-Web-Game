/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCamera : StateMachineBehaviour
{
    private Transform playerPos;
    public float speed;
    public bool facingLeft;
    public Transform thing;
    public bool Chase;


    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        thing = animator.GetComponent<Transform>();
    }
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        animator.transform.position = Vector2.MoveTowards(animator.transform.position, new Vector2 (playerPos.position.x,animator.transform.position.y), speed*Time.deltaTime);
        if (Vector3.Distance(thing.position, PlayerController.instance.transform.position) < 5)
        {
            Chase = true;
        }
        else
        {
            Chase = false;
        }
        animator.SetBool("Chase", Chase);
    }

    
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

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
*/