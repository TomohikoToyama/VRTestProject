using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VR {
    public class StageManager : MonoBehaviour
    {

        GameObject PS;
        GameObject Player;
        int currentState;
        TextMesh stateText;
        public enum STAGESTATE
        {
            READY = 0,
            ROAD = 1,
            BOSS = 2,
            STAY = 3,
            GAMEOVER = 4,
            CLEAR = 5

        }


        protected static StageManager instance;

        public static StageManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = (StageManager)FindObjectOfType(typeof(StageManager));

                    if (instance == null)
                    {
                        Debug.LogError("StageManager Instance Error");
                    }
                }

                return instance;
            }
        }

        // Use this for initialization
        void Start()
        {
            currentState = (int)STAGESTATE.READY;
            PS = GameObject.Find("PlayerSpawner");
            Player = GameObject.FindGameObjectWithTag("ActiveController");
            Player.transform.position = PS.transform.position;
            Player.transform.rotation = PS.transform.rotation;
            StartCoroutine(ReadyCoroutine());
        }

        // Update is called once per frame
        void Update()
        {
            //READYの時の処理
            if (currentState == (int)STAGESTATE.READY)
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

        public int GetCurrentState()
        {
            return currentState;
        }

        
        //非同期処理群
        #region
        IEnumerator ReadyCoroutine()
        {
            stateText = PS.transform.Find("StateText").GetComponent<TextMesh>();
            stateText.gameObject.SetActive(true);
          
            yield return new WaitForSeconds(3.0f);

            stateText.text = "GO!";


            stateText.gameObject.SetActive(false);
            currentState = (int)STAGESTATE.ROAD;
        }

        #endregion


    }
}
