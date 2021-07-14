using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : StateMachineBehaviour
{
    public Transform cameraEnemy;
    public bool Chase;
    public SpriteRenderer theSR;
    public Rigidbody2D theRB;
    public cameraVariableHolder sameh;
    
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        sameh = animator.GetComponent<cameraVariableHolder>();
       // Debug.Log(Transform.position);
        cameraEnemy = animator.GetComponent<Transform>();
        theRB = animator.GetComponent<Rigidbody2D>();
        theSR = animator.GetComponent<SpriteRenderer>();

    }

    
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    { 
          if(sameh.instance.moveCount>0){
              Debug.Log("hematullah");
            sameh.instance.moveCount-=Time.deltaTime;
            sameh.instance.isMoving = true;

   
       cameraEnemy.position = Vector3.MoveTowards(cameraEnemy.position,sameh.instance.points[sameh.instance.currentPoint].position,sameh.instance.moveSpeed*Time.deltaTime);

        if(Vector3.Distance(cameraEnemy.position,sameh.instance.points[sameh.instance.currentPoint].position)<0.5f){
            
            sameh.instance.currentPoint++;
            if(sameh.instance.currentPoint == sameh.instance.points.Count){
                sameh.instance.currentPoint = 0;
            }
        }


     if(cameraEnemy.position.x<sameh.instance.points[sameh.instance.currentPoint].position.x && sameh.instance.facingLeft){
            theSR.flipX = true;
        }else if(cameraEnemy.position.x>sameh.instance.points[sameh.instance.currentPoint].position.x  && sameh.instance.facingLeft){
            theSR.flipX = false;
        }else if(cameraEnemy.position.x<sameh.instance.points[sameh.instance.currentPoint].position.x && !sameh.instance.facingLeft){
                theSR.flipX = false;
        }else if(cameraEnemy.position.x>sameh.instance.points[sameh.instance.currentPoint].position.x  && !sameh.instance.facingLeft){
            theSR.flipX = true;
        }

  
        if(sameh.instance.moveCount<=0){
            sameh.instance.waitCount = Random.Range(sameh.instance.waitTime*0.75f,sameh.instance.waitTime*1.25f);
            if(sameh.instance.waitCount <= 0){
                 sameh.instance.moveCount = Random.Range(sameh.instance.moveTime*.75f,sameh.instance.moveTime*1.25f);
            }

        }  
        }else if(sameh.instance.waitCount>0){
            sameh.instance.waitCount-=Time.deltaTime;
            sameh.instance.isMoving = false;
            theRB.velocity = new Vector2(0f,theRB.velocity.y);

            if(sameh.instance.waitCount<=0){
                sameh.instance.moveCount = Random.Range(sameh.instance.moveTime*.75f,sameh.instance.moveTime*1.25f);
            }
           
        }
         













         if (Vector3.Distance(sameh.instance.transform.position, PlayerController.instance.transform.position) < 5)
        {
            Chase = true;
        }
        else {
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
