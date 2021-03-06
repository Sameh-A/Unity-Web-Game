using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public static PlayerController instance;
    
    public ParticleSystem dust;
    public ParticleSystem blackDash;

    //dash vars
    public bool canDash;
    public float dashSpeed; 
    public float dashCount;
    public float startDashCount;
    public float direction;
    public bool didDash;
    public bool isDashing;
// standard movement vars
    public float moveSpeed;
    public float originalmoveSpeed;
    public Rigidbody2D theRB;
    public float jumpForce;
    public float originaljumpForce;
    public float slowStack;

    public float slowMovement;
    public float slowCounter;
    public float slowTimer;
    public bool isSlow;
    public bool isStop;

    public bool isConfused;
    //make isGrounded private
    public bool isGrounded;
    public Transform groundCheckPoint;
    public LayerMask whatIsGround;

    private bool canDoubleJump;

    private Animator anim; 
    private SpriteRenderer theSR;
    public int isFlip;


    public float knockBackLength,knockBackForce;
    private float knockBackCounter;

    public bool isHurt;

    public float bounceForce;

    public bool stopInput;

    void Awake(){
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        anim=GetComponent<Animator>();
        theSR=GetComponent<SpriteRenderer>();
        isHurt = false;
        if(canDash){
            dashCount = startDashCount;
        }
        originaljumpForce = jumpForce;
        originalmoveSpeed = moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
    if(!PauseMenu.instance.isPaused && !stopInput)
    {   
        if(theSR.flipX){
            isFlip = -1;
        }else{
            isFlip = 1;
        }
       
        if(slowTimer > 0){
            slowTimer -= Time.deltaTime;
        

        }
        else{
            if(isSlow){
                moveSpeed += 2 *slowStack;
                jumpForce += 2 *slowStack;
                canDash = true;
                isSlow = false;
                slowStack = 0;
                


            }
            else if(isStop){
                isStop = false;
                moveSpeed = originalmoveSpeed;
                jumpForce = originaljumpForce;
                canDash = true;

            }else if(isConfused){
                isConfused = false;
                moveSpeed = originalmoveSpeed;
                jumpForce = originaljumpForce;
                dashSpeed = dashSpeed*-1;
                
            }

        }


        if(knockBackCounter<=0){
        isHurt = false;
        theRB.velocity = new Vector2(moveSpeed*Input.GetAxisRaw("Horizontal"),theRB.velocity.y);

        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position,.45f,whatIsGround);

        if(isGrounded)
        {
            canDoubleJump = true;
            didDash = false;
        }



        if(Input.GetButtonDown("Jump"))
        {
         
        CreateDust();    
        if(isGrounded)
        {
            AudioManager.instance.PlaySFX(10);
            theRB.velocity = new Vector2(theRB.velocity.x,jumpForce);
        }
            else
            {
                if(canDoubleJump)
                {
                    AudioManager.instance.PlaySFX(10);
                    theRB.velocity = new Vector2(theRB.velocity.x,jumpForce);
                    canDoubleJump = false;
                }
            }


        }
if(theRB.velocity.x<0)
{
theSR.flipX =true;
}else if(theRB.velocity.x>0)
{
theSR.flipX =false;
}
        }
        else{
            knockBackCounter-=Time.deltaTime;
            
        }
    

    
    if(canDash && direction == 0 && !isHurt){
        if(Input.GetButtonDown("Fire1")){
            blackDashPart();
        if(isGrounded){ 
        direction = 1;
        }else{
            if(!didDash){
                direction = 1;
                didDash = true;
            }
        }
        }
    }else if(canDash && !(direction == 0)){
        if(dashCount<=0){
            direction = 0;
            dashCount = startDashCount;
            theRB.velocity = Vector2.zero;
            isDashing = false;
        }else{
            dashCount-=Time.deltaTime;

            if(theSR.flipX){
            theRB.velocity = Vector2.left * dashSpeed;
            }else{
                 theRB.velocity = Vector2.right * dashSpeed;
            }
            isDashing = true;
        }
    }
    anim.SetBool("isGrounded",isGrounded);
    anim.SetFloat("moveSpeed",Mathf.Abs(theRB.velocity.x));
    anim.SetBool("isHurt",isHurt);
    anim.SetBool("isDashing",isDashing);


    
    }
    }
    public void KnockBack(){
        knockBackCounter = knockBackLength;
        isHurt = true;
         if(theSR.flipX){
                theRB.velocity = new Vector2(.75f* knockBackForce,knockBackForce);
            }else{
                theRB.velocity = new Vector2(.75f*-knockBackForce,knockBackForce);
            }
        
        
       

    }

    public void Bounce(){

        theRB.velocity = new Vector2(theRB.velocity.x,bounceForce);
    }

    public void slowDown(){
        moveSpeed = moveSpeed - 2;
        canDash = false;
        slowTimer = slowCounter;
        isSlow = true;
        slowStack++;
        jumpForce = jumpForce - 2;
        Debug.Log("LASREA");




    }

    public void Stop(){
        moveSpeed = 0;
        canDash = false;
        jumpForce = 0;
        slowTimer = slowCounter;
        isStop = true;

    }

  public void Confuse(){

      if(!isConfused){
        moveSpeed = moveSpeed*-1;
        jumpForce = jumpForce*-1;
        slowTimer = slowCounter;
        isConfused = true;
        dashSpeed = dashSpeed*-1;
      }
    }



    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Platform"){
            transform.parent = other.transform;
        }
    }


     private void OnCollisionExit2D(Collision2D other)
    {
        if(other.gameObject.tag == "Platform"){
            transform.parent = null;
        }
    }
    public void CreateDust(){
        dust.Play();
    }
     public void blackDashPart(){
        blackDash.Play();
    }

    }
