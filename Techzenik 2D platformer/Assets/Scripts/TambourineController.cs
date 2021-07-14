using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TambourineController : MonoBehaviour
{
    public float moveSpeed;
    public List<Transform> points;
    public int currentPoint;

    private bool movingRight;
    public bool isMoving;
    public Rigidbody2D theRB;
    public SpriteRenderer theSR;
    public float distanceToMoveFast;
    public bool accelerateSpeed;
    public float speedMultiplier;
    public Vector3 targetPlayer;
    public float speedTimer, speedCount;
    


    public TambourineController instance;
    public float moveTime, waitTime;
    public float moveCount, waitCount;
    // Start is called before the first frame update
    
    void Awake()
    {
        instance = this; 

    }

    void Start()
    {
        theRB = GetComponent<Rigidbody2D>();
        for(int i = 0 ; i<points.Count;i++){

            points[i].parent = null;
       }

       
        movingRight = true;
        moveCount = moveTime;

        
    }

    // Update is called once per frame
    void Update()
    {
       if(moveCount > 0){

           moveCount-=Time.deltaTime;
            
                transform.position = Vector3.MoveTowards(transform.position,points[currentPoint].position,moveSpeed*Time.deltaTime);
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
        if(Vector3.Distance(transform.position,PlayerController.instance.transform.position)<distanceToMoveFast && !accelerateSpeed){
                moveSpeed = moveSpeed* speedMultiplier;
                accelerateSpeed = true;
                speedCount = speedTimer;
                //targetPlayer = PlayerController.instance.transform.position;
                /*if(Vector3.Distance(transform.position,attackTarget)<=5f){

                }*/
        }
        if(speedCount>= 0){
            speedCount -= Time.deltaTime;
             
            

        } else if(accelerateSpeed){
             moveSpeed = moveSpeed/speedMultiplier;   
             accelerateSpeed = false;
        }

        if(moveCount<=0){
            waitCount = Random.Range(waitTime*0.75f,waitTime*1.25f);
            if(waitCount <= 0){
                 moveCount = Random.Range(moveTime*.75f,moveTime*1.25f);
                 
            }
           

        }  
        }else if(waitCount>0){
            waitCount-=Time.deltaTime;
            isMoving = false;
            theRB.velocity = new Vector2(0f,theRB.velocity.y);

            if(waitCount<=0){
                moveCount = Random.Range(moveTime*.75f,moveTime*1.25f);
            }

            
        }

        
      
      
   }

    public void SelfDestroy(){
        Destroy(instance.gameObject);

    }
}
