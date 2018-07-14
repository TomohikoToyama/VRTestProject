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

        [SerializeField]
        StageManager SM;

        GameObject player;
        // Use this for initialization
        void Start()
        {

            player = GameObject.FindGameObjectWithTag("Player");
            Enemy();
        }

        // Update is called once per frame
        void Update()
        {

        }


        void Enemy(){

            Debug.Log(SM.FormatStage());
            Debug.Log(StageNum.TestStage.ToString());
            if ( SM.FormatStage() == StageNum.TestStage.ToString())
            {
                Debug.Log("テスト");
            }
        }

    }
}