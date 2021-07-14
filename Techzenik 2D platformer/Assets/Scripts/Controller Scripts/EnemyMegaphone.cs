using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMegaphone : MonoBehaviour
{
    public Vector3 initialSpot;
    public List<Transform> points;
    public float moveSpeed;
    public int currentPoint;
   public EnemyMegaphone instance;
   public SpriteRenderer theSR;
    public float distanceToAttack,chaseSpeed;
    private Vector3 attackTarget;
    private float attackCounter;
    public float waitAfterAttack;
    

     public Transform firePoint;
    public GameObject projectile;
    
    
     public bool hasShot;
    public bool beenFlipped;

    public float shootDistance;

     private Animator anim; 

     void Awake(){
        instance = this;
    }
    
    // Start is called before the first frame update
    void Start()
    {
         initialSpot = new Vector3(transform.position.x,transform.position.y,transform.position.z);
        for(int i = 0; i<points.Count;i++){
            points[i].parent = null;
        }

        anim=GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(attackCounter>0){
            attackCounter-=Time.deltaTime;

                if(!hasShot && (beenFlipped && PlayerController.instance.transform.position.x  > transform.position.x || !beenFlipped && PlayerController.instance.transform.position.x  < transform.position.x ) && Vector3.Distance(transform.position,PlayerController.instance.transform.position)<=shootDistance){
               anim.SetTrigger("Spit");
               Invoke("Shoot", .2f);
               
                hasShot = true;
            }else if(!hasShot && beenFlipped && PlayerController.instance.transform.position.x  < transform.position.x && Vector3.Distance(transform.position,PlayerController.instance.transform.position)<=shootDistance){
                Flip();
                beenFlipped = false;
                anim.SetTrigger("Spit");
               Invoke("Shoot", .2f);
                hasShot = true;
            }else if(!hasShot && !beenFlipped && PlayerController.instance.transform.position.x  > transform.position.x && Vector3.Distance(transform.position,PlayerController.instance.transform.position)<=shootDistance){
                Flip();
                beenFlipped = true;
                anim.SetTrigger("Spit");
               Invoke("Shoot", .2f);
                hasShot = true;
            }


        }else{
            hasShot = false;
            if(Vector3.Distance(transform.position,PlayerController.instance.transform.position)>distanceToAttack){
        transform.position = Vector3.MoveTowards(transform.position,points[currentPoint].position,moveSpeed*Time.deltaTime);

        if(Vector3.Distance(transform.position,points[currentPoint].position)<0.5f){
            
            currentPoint++;
            if(currentPoint == points.Count){
                currentPoint = 0;
            }
        }

       if(transform.position.x<points[currentPoint].position.x && !beenFlipped){
           // theSR.flipX = true;
           Flip();
           beenFlipped = true;
        }else if(transform.position.x>points[currentPoint].position.x && beenFlipped){
            //theSR.flipX = false;
            beenFlipped = false;
            Flip();
        }
    }else{
        if(attackTarget == Vector3.zero){
            attackTarget = PlayerController.instance.transform.position;
        }

        transform.position = Vector3.MoveTowards(transform.position,attackTarget,chaseSpeed*Time.deltaTime);
        if(transform.position.x<attackTarget.x && !beenFlipped){
           // theSR.flipX = true;
            Flip();
           beenFlipped = true;
        }else if(transform.position.x>attackTarget.x && beenFlipped){
            //theSR.flipX = false;
               beenFlipped = false;
                Flip();

        }


        if(Vector3.Distance(transform.position,attackTarget)<=.1f){
            attackCounter = waitAfterAttack;
            attackTarget=Vector3.zero;
        }

    }
        }

    }


     public void SelfDestroy(){
        Destroy(instance.gameObject);

    }

      public void Shoot(){
        Instantiate(projectile,firePoint.position,firePoint.rotation);
    }


      private void Flip(){
        transform.Rotate(0f,180f,0f);  
        
        }



}
