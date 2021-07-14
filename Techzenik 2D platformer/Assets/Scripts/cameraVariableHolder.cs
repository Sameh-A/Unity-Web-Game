using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraVariableHolder : MonoBehaviour
{
      public float moveSpeed;
      public int currentPoint;
     public List<Transform> points;
         public cameraVariableHolder instance;
    public Transform cameraEnemy;
    public bool Chase;
   
    
    public bool isMoving;

       public float moveTime,waitTime;
    public float moveCount,waitCount;
    public bool facingLeft;
    // Start is called before the first frame update
    void Start()
    {
        instance=this;
        moveCount =moveTime;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
