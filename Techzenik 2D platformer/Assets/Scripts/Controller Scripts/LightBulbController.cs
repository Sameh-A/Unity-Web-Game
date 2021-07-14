using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBulbController : MonoBehaviour
{
    public float moveSpeed;
    public List<Transform> points;
    public int currentPoint;

    private bool movingRight;
    public bool isMoving;
    public bool IsMoving;
    
    private Rigidbody2D theRB;
    public SpriteRenderer theSR;
    private Animator anim;

    public LightBulbController instance;
    public float moveTime, waitTime;
    public float moveCount, waitCount;

    void Awake(){
        instance = this; 

    }


    // Start is called before the first frame update
    void Start()
    {
        theRB = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        for(int i = 0 ; i<points.Count;i++){
           points[i].parent = null;
       }

       
        movingRight = true;
        moveCount = moveTime;

    }

    // Update is called once per frame
    void Update()
    {
        if(moveCount > 0)
        {

            moveCount -= Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position,points[currentPoint].position,moveSpeed*Time.deltaTime);
            /*if(movingRight){
                
                theRB.velocity = new Vector2(moveSpeed, theRB.velocity.y);
                theSR.flipX = false;
                
                if(transform.position.x > rightPoint.position.x){
                    movingRight = false;
                }
            } else
            {
                theRB.velocity = new Vector2(-moveSpeed, theRB.velocity.y);
                theSR.flipX = true;

                if(transform.position.x < leftPoint.position.x)
                {
                    movingRight = true;
                }

            }

            if(moveCount <= 0){
                 waitCount = waitTime;
            }
            anim.SetBool("IsMoving",false);


        } else if(waitCount > 0)

        {
            waitCount -= Time.deltaTime;
            theRB.velocity = new Vector2(0f, theRB.velocity.y);

            if(waitCount <= 0){
                moveCount = moveTime;
            }
            anim.SetBool("IsMoving",true);
        }*/
          isMoving = true;

          if(Vector3.Distance(transform.position,points[currentPoint].position)<0.5f){
            
            currentPoint++;
            if(currentPoint == points.Count){
                currentPoint = 0;
            }
        }


        if(transform.position.x<points[currentPoint].position.x && movingRight){
            theSR.flipX = false;
        }else if(transform.position.x>points[currentPoint].position.x  && movingRight){
            theSR.flipX = true;
        }else if(transform.position.x<points[currentPoint].position.x && !movingRight){
                theSR.flipX = true;
        }else if(transform.position.x>points[currentPoint].position.x  && !movingRight){
            theSR.flipX = false;
        }

  
        if(moveCount<=0){
            waitCount = Random.Range(waitTime*0.75f,waitTime*1.25f);
            if(waitCount <= 0){
                 moveCount = Random.Range(moveTime*.75f,moveTime*1.25f);
                 
            }
            anim.SetBool("IsMoving",true);

        }  
        }else if(waitCount>0){
            waitCount-=Time.deltaTime;
            isMoving = false;
            theRB.velocity = new Vector2(0f,theRB.velocity.y);

            if(waitCount<=0){
                moveCount = Random.Range(moveTime*.75f,moveTime*1.25f);
            }

            anim.SetBool("IsMoving",false);
        }
       
        

    }

    public void SelfDestroy(){
        Destroy(instance.gameObject);

    }



}