using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallJump : MonoBehaviour
{


    public float speed;
	bool walljumping;
    public float distance;
    private Animator anim; 
    public bool resetCounter;
   

    //wall climb vars
    public bool isOnWall;
    public float verticalMoveSpeed;
    public bool ready;
    public float downTime, upTime, pressTime = 0;
    public float countDown;
    public bool falling;

    public bool canClimb;
    public bool canWallJump;
    // Start is called before the first frame update
    void Start()
    {
         anim=GetComponent<Animator>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        Physics2D.queriesStartInColliders = false;
		RaycastHit2D hit = Physics2D.Raycast(transform.position,Vector2.right*transform.localScale.x,distance);


        RaycastHit2D WallClimbcheck = Physics2D.Raycast(transform.position,Vector2.right*transform.localScale.x*PlayerController.instance.isFlip,0.7f);

          RaycastHit2D WallClimbcheck2 = Physics2D.Raycast(new Vector2(transform.position.x,transform.position.y-0.3f),Vector2.right*transform.localScale.x*PlayerController.instance.isFlip,0.7f);

           RaycastHit2D WallClimbcheck3 = Physics2D.Raycast(new Vector2(transform.position.x,transform.position.y-0.5f),Vector2.right*transform.localScale.x*PlayerController.instance.isFlip,0.7f);




    Debug.DrawRay(transform.position, Vector2.right*transform.localScale.x*0.6f*PlayerController.instance.isFlip, Color.green);
    Debug.DrawRay(new Vector2(transform.position.x,transform.position.y-0.3f), Vector2.right*transform.localScale.x*0.6f*PlayerController.instance.isFlip, Color.green);
    Debug.DrawRay(new Vector2(transform.position.x,transform.position.y-0.5f), Vector2.right*transform.localScale.x*0.6f*PlayerController.instance.isFlip, Color.green);









    if(PlayerController.instance.isGrounded){
        resetCounter = true;
    }





 if(canWallJump){

		if (Input.GetKeyDown (KeyCode.Space) && !PlayerController.instance.isGrounded && hit.collider != null) {
						{
								
								GetComponent<Rigidbody2D> ().velocity = new Vector2 (speed * hit.normal.x, speed);

								

						}
		
				}


 }

 if(canClimb){

                if (Input.GetButtonDown("Fire2") && ready == false && (WallClimbcheck.collider != null || WallClimbcheck2.collider != null || WallClimbcheck3.collider != null)) {

                         if(resetCounter){
                         downTime = Time.time;
                         pressTime = downTime + countDown;
                         resetCounter = false;
                         }
                         ready = true;
                         Debug.Log("On Wall");
                          isOnWall = true;
                          PlayerController.instance.theRB.gravityScale = 0;
                          falling = false;
                          
                 }
                 if ((Input.GetButtonUp("Fire2") && ready) || (WallClimbcheck.collider == null && WallClimbcheck2.collider == null && WallClimbcheck3.collider == null && ready)) {
                         ready = false;
                         Debug.Log("Falling");
                          isOnWall = false;
                          PlayerController.instance.theRB.gravityScale = 5;
                          falling = true;
                 }
                 if (Time.time >= pressTime && ready == true) {
                         ready = false;
                         Debug.Log("falling");
                        falling = true;
                          isOnWall = false;
                          PlayerController.instance.theRB.gravityScale = 5;
                 }

                 if(isOnWall){
                  PlayerController.instance.theRB.velocity =  new Vector2(PlayerController.instance.theRB.velocity.x,verticalMoveSpeed*Input.GetAxisRaw("Vertical"));   
                 }
                     
 }
/*

            	if (Input.GetKey(KeyCode.K) && WallClimbcheck.collider != null) {
						{
								SetReset = true;
                                isOnWall = true;
								Debug.Log("bum");
								

						}
		
				}else if(SetReset){
                 	Debug.Log("crack");
                  SetReset = false;
                  isOnWall = false;
                }
                */

        anim.SetBool("isOnWall",isOnWall);
         anim.SetBool("falling",falling);
        anim.SetFloat("verticalMoveSpeed",Mathf.Abs(PlayerController.instance.theRB.velocity.y));
    }
 
}
