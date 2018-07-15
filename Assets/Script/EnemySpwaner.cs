using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VR
{
    public class EnemySpwaner : MonoBehaviour
    {
        public enum StageNum
        {
            FirstStage = 1,
            TestStage = 9,
        }


        float spawnTime;
        [SerializeField]
        StageManager SM;

        [SerializeField]
        GameObject enemy;
        GameObject player;
        // Use this for initialization
        void start()
        {
            SM = GameObject.FindGameObjectWithTag("StageManager").GetComponent<StageManager>();
            //enemy = GameObject.FindGameObjectWithTag("Enemy");
            player = GameObject.FindGameObjectWithTag("Player");
           
        }

        // Update is called once per frame
        void Update()
        {
            spawnTime += Time.deltaTime;
            Enemy();
            if (spawnTime > 2.0){
                    spawnTime = 0;
                    Instantiate(enemy);
                }
            
        }


        void Enemy(){

            Debug.Log(SM.GetFormatStage());
            Debug.Log(StageNum.TestStage.ToString());
            if ( SM.GetFormatStage() == StageNum.TestStage.ToString())
            {
                Debug.Log("テスト");
            }
        }

    }
}