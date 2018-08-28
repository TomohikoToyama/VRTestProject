using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VR {
    public class StageManager : MonoBehaviour
    {

        PlayerSpawner PS;
        int currentState;
        enum STAGESTATE
        {
            READY       = 0,
            ROAD        = 1,
            BOSS        = 2,
            GAMEOVER    = 3,
            CLEAR       = 4

        }
        // Use this for initialization
        void Start()
        {
            currentState = (int)STAGESTATE.READY;
        }

        // Update is called once per frame
        void Update()
        {
            //READYの時の処理
            if(currentState == (int)STAGESTATE.READY)
            {


            }
            //道中の時の処理
            else if (currentState == (int)STAGESTATE.ROAD)
            {

            }
            //ボス戦の時の処理
            else if (currentState == (int)STAGESTATE.BOSS)
            {

            }
            //ゲームオーバーの時の処理
            else if (currentState == (int)STAGESTATE.GAMEOVER)
            {

            }//ステージクリアの時の処理
            else if (currentState == (int)STAGESTATE.CLEAR)
            {

            }


        }





    }
}
