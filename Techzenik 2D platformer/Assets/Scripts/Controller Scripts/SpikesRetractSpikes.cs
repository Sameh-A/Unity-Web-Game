using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesRetractSpikes : MonoBehaviour
{

     private Animator anim; 
   //  public SpikesRetractSpikes instance;
     public bool is_retracted;
     public bool start_retract;
    // Start is called before the first frame update
     void Awake(){
        //  instance = this;
      }
    
    void Start()
    {
         anim=GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Retract(){
         if(is_retracted){
                is_retracted = false;
                anim.SetTrigger("extend");

            }else{
                 is_retracted = true;
                anim.SetTrigger("retract");
            }
    }
}
