using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesRetractButton : MonoBehaviour
{
      private Animator anim;
      public SpikesRetractSpikes[] spikes;

    // Start is called before the first frame update
    void Start()
    {
          anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

       private void OnTriggerEnter2D(Collider2D other){
             if(other.tag == "Player"){  
            anim.SetTrigger("press");
            for(int i = 0; i<spikes.Length;i++){
                  spikes[i].Retract();
            }
             }
       }
}
