using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManagerLight : MonoBehaviour
{
    public List<Transform>[] enemiesPoints;
    private LightBulbController[] lightbulb;
    private EnemyController[] cameraEnemy;
    public static EnemyManagerLight instance;
    public int numOfLightBulb;
    public int numOfCamera;
    public GameObject enemyLightBulb;
    public GameObject enemyCamera;


    // Start is called before the first frame update
      void Awake()
    {
        instance = this;
    }
    
    void Start()
    {

        lightbulb = FindObjectsOfType<LightBulbController>();
        cameraEnemy = FindObjectsOfType<EnemyController>();
        numOfLightBulb = lightbulb.Length;
        numOfCamera = cameraEnemy.Length;
        enemiesPoints = new List<Transform>[lightbulb.Length+cameraEnemy.Length];

        for(int i = 0;i<lightbulb.Length+cameraEnemy.Length;i++){
             if(i < lightbulb.Length){
                 enemiesPoints[i] = lightbulb[i].points;
             }
              else{
                  enemiesPoints[i] = cameraEnemy[i-(lightbulb.Length)].points;
              
             
            }
         }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RespawnEnemies(){
      LightBulbController[] lightBulbDestroy = FindObjectsOfType<LightBulbController>();
      EnemyController[] cameraDestroy = FindObjectsOfType<EnemyController>();

    for(var i = 0 ; i < lightBulbDestroy.Length ; i ++)
     {
        
         Destroy(lightBulbDestroy[i].gameObject);
            Debug.Log("EM not working1");

     }

    for(var i = 0 ; i < cameraDestroy.Length ; i ++)
     {
        
         Destroy(cameraDestroy[i].gameObject);
         Debug.Log("EM not working");
        

     }
     for(int i = 0; i<enemiesPoints.Length;i++){  
           if(i< numOfLightBulb){
                
                GameObject enemyObj = (GameObject) Instantiate(enemyLightBulb,enemiesPoints[i][0].position,Quaternion.Euler(0f,0f,0f));
                LightBulbController enemy = enemyObj.GetComponent<LightBulbController>();
                enemy.points = enemiesPoints[i];
                Debug.Log("EM not working2");
         
               
            }else if (i< numOfCamera+numOfLightBulb){
                GameObject enemyObj = (GameObject) Instantiate(enemyCamera,enemiesPoints[i][0].position,Quaternion.Euler(0f,0f,0f));
                EnemyController enemy = enemyObj.GetComponent<EnemyController>();
                enemy.points = enemiesPoints[i];
                Debug.Log("EM not working3");
           
        }

    }


  }




}

