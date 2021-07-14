using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetSpikesRetract : MonoBehaviour
{
     public static resetSpikesRetract instance;
     public SpikesRetractSpikes[] allSpikes;

     void Awake(){
         instance = this;
     }
    // Start is called before the first frame update
    void Start()
    {
          allSpikes = FindObjectsOfType<SpikesRetractSpikes>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


      public void resetAllSpikes()
    {
        for (int i = 0; i < allSpikes.Length; i++)
        {
            if(allSpikes[i].start_retract && !allSpikes[i].is_retracted){
            allSpikes[i].Retract();
            }else if(!allSpikes[i].start_retract && allSpikes[i].is_retracted){
                allSpikes[i].Retract();
            }
        }
    }
}
