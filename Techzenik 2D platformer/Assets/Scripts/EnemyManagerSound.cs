using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManagerSound : MonoBehaviour
{
    public List<Transform>[] enemiesPoints;
    private TambourineController[] tambourineList;
    private EnemyController[] bellList;
    private EnemyMegaphone[] megaphoneList;
    private AlarmController[] alarmList;
    public static EnemyManagerSound instance;
    public int numOfTambourine;
    public int numOfBell;
    public int numOfMegaphone;
    public int numOfAlarm;
    public GameObject enemyTambourine;
    public GameObject enemyBell;
    public GameObject enemyMegaphone;
    public GameObject enemyAlarm;


    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }

    void Start()
    {

        tambourineList = FindObjectsOfType<TambourineController>();
        bellList = FindObjectsOfType<EnemyController>();
        megaphoneList = FindObjectsOfType<EnemyMegaphone>();
        alarmList = FindObjectsOfType<AlarmController>();
        numOfTambourine = tambourineList.Length;
        numOfBell = bellList.Length;
        numOfMegaphone = megaphoneList.Length;
        numOfAlarm = alarmList.Length;
        enemiesPoints = new List<Transform>[tambourineList.Length + bellList.Length + megaphoneList.Length + alarmList.Length];

        for (int i = 0; i < tambourineList.Length + bellList.Length + megaphoneList.Length + alarmList.Length; i++)
        {
            if (i < tambourineList.Length)
            {
                enemiesPoints[i] = tambourineList[i].points;
            }
            else if (tambourineList.Length <= i && i< bellList.Length + tambourineList.Length)
            {
                enemiesPoints[i] = bellList[i - (tambourineList.Length)].points;
            }
            else if(tambourineList.Length + bellList.Length <= i && i< megaphoneList.Length + bellList.Length + tambourineList.Length)
            {
                enemiesPoints[i] = megaphoneList[i - (tambourineList.Length + bellList.Length)].points;
            }
            else if (tambourineList.Length + bellList.Length + megaphoneList.Length <= i && i < alarmList.Length + megaphoneList.Length + bellList.Length + tambourineList.Length)
            {
                enemiesPoints[i] = alarmList[i - (tambourineList.Length + bellList.Length + megaphoneList.Length)].points;
            }
        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RespawnEnemies()
    {
        TambourineController[] tambourineDestroy = FindObjectsOfType<TambourineController>();
        EnemyController[] bellDestroy = FindObjectsOfType<EnemyController>();
        EnemyMegaphone[] megaphoneDestroy = FindObjectsOfType<EnemyMegaphone>();
        AlarmController[] alarmDestroy = FindObjectsOfType<AlarmController>();

        for (var i = 0; i < tambourineDestroy.Length; i++)
        {

            Destroy(tambourineDestroy[i].gameObject);
            Debug.Log("EM not working1");

        }

        for (var i = 0; i < bellDestroy.Length; i++)
        {

            Destroy(bellDestroy[i].gameObject);
            Debug.Log("EM not working");


        }
        for (var i = 0; i < megaphoneDestroy.Length; i++)
        {

            Destroy(megaphoneDestroy[i].gameObject);
            Debug.Log("EM not working");


        }
        for (var i = 0; i < alarmDestroy.Length; i++)
        {

            Destroy(alarmDestroy[i].gameObject);
            Debug.Log("EM not working");


        }

        for (int i = 0; i < enemiesPoints.Length; i++)
        {
            if (i < numOfTambourine)
            {

                GameObject enemyObj = (GameObject)Instantiate(enemyTambourine, enemiesPoints[i][0].position, Quaternion.Euler(0f, 0f, 0f));
                TambourineController enemy = enemyObj.GetComponent<TambourineController>();
                enemy.points = enemiesPoints[i];
                Debug.Log("EM not working2");


            }
            else if (i < numOfBell + numOfTambourine)
            {
                GameObject enemyObj = (GameObject)Instantiate(enemyBell, enemiesPoints[i][0].position, Quaternion.Euler(0f, 0f, 0f));
                EnemyController enemy = enemyObj.GetComponent<EnemyController>();
                enemy.points = enemiesPoints[i];
                Debug.Log("EM not working3");

            }
            else if (i < numOfMegaphone + numOfBell + numOfTambourine)
            {
                GameObject enemyObj = (GameObject)Instantiate(enemyMegaphone, enemiesPoints[i][0].position, Quaternion.Euler(0f, 0f, 0f));
                EnemyMegaphone enemy = enemyObj.GetComponent<EnemyMegaphone>();
                enemy.points = enemiesPoints[i];
                Debug.Log("EM not working3");

            }
            else if (i < numOfAlarm + numOfMegaphone + numOfBell + numOfTambourine)
            {
                GameObject enemyObj = (GameObject)Instantiate(enemyAlarm, enemiesPoints[i][0].position, Quaternion.Euler(0f, 0f, 0f));
                AlarmController enemy = enemyObj.GetComponent<AlarmController>();
                enemy.points = enemiesPoints[i];
                Debug.Log("EM not working3");

            }

        }


    }




}
