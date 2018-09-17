using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
namespace VR {
    public class StageManager : MonoBehaviour
    {
        [SerializeField]
        public Material[] stageText;
        GameObject PS;
        GameObject Player;
        GameObject PUnit;
        private GameObject CameraText;
        int currentState;
        TextMesh stateText;
        Material stageSkybox;
        GameObject playerCamera;
        private bool stateAct;
        private bool gameEnd;
        public bool initEnd;
        public bool GameEnd { get { return gameEnd; } set { gameEnd = value; } }
        public delegate void onComplete(string msg);
        public enum STAGESTATE
        {
           
            READY = 0,
            ROAD = 1,
            BOSS = 2,
            STAY = 3,
            GAMEOVER = 4,
            CLEAR = 5,
            NONE  = 9
        }

        public int progress;

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
                       Debug.Log("StageManager Instance Error");
                    }
                }

                return instance;
            }
        }

        // Use this for initialization
        void Start()
        {
           // InitAct();

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
                progress++;
                if (progress >= 751)
                    progress = 0;

            }
            //ボス戦の時の処理
            else if (currentState == (int)STAGESTATE.BOSS)
            {

            }
            //ゲームオーバーの時の処理
            else if (currentState == (int)STAGESTATE.GAMEOVER)
            {
                if(!stateAct)
                StartCoroutine(GameOverCoroutine());
            }//ステージクリアの時の処理
            else if (currentState == (int)STAGESTATE.CLEAR)
            {

            }


        }
      

        public void InitAct(onComplete callback)
        {
            
            // スコア表示数字のRenderer取得
            Renderer[] rend = GameObject.FindGameObjectWithTag("ScoreManager").GetComponentsInChildren<Renderer>();

          
                foreach (var col in rend)
                {
                    col.enabled = true;
                }
               
            currentState = (int)STAGESTATE.READY;
            CameraText = GameObject.FindGameObjectWithTag("CameraText");
            RenderSettings.skybox = (Material)Resources.Load("Image/Material/Sky Material");
            initEnd = true;
            StartCoroutine(ReadyCoroutine());
            progress = 0;
        }

        public bool AbleShoot()
        {
            if (currentState == (int)STAGESTATE.ROAD || currentState == (int)STAGESTATE.BOSS)
            {
                return true;
            }
            return false;
        }
        public int GetCurrentState()
        {
            return currentState;
        }

        public void SetGameOver()
        {
            currentState = (int)STAGESTATE.GAMEOVER;
        }
        //非同期処理群
        #region

        //開始時の処理
        IEnumerator ReadyCoroutine()
        {
            CameraText.GetComponent<Renderer>().material = stageText[0];
            CameraText.GetComponent<MeshRenderer>().enabled = true;
            CameraText.GetComponent<Renderer>().material = stageText[1];
             yield return new WaitForSeconds(3.0f);

            CameraText.GetComponent<Renderer>().material = stageText[2];
            yield return new WaitForSeconds(1.0f);

            CameraText.GetComponent<MeshRenderer>().enabled = false;
            currentState = (int)STAGESTATE.ROAD;
        }


        //ゲームオーバー時の処理
        IEnumerator GameOverCoroutine()
        {

            stateAct = true;
            var soundInstance = SoundManager.Instance;
            soundInstance.StopBGM();
            yield return new WaitForSeconds(1.0f);
            CameraText.GetComponent<Renderer>().material = stageText[3];
            CameraText.GetComponent<MeshRenderer>().enabled = true;
           soundInstance.PlaySE(5);

            yield return new WaitForSeconds(3.0f);
            GameObject.FindGameObjectWithTag("CameraText").GetComponent<MeshRenderer>().enabled = false;
            yield return new WaitForSeconds(1.0f);
            currentState = (int)STAGESTATE.NONE;
            


            // スコア表示数字のRenderer取得
            Renderer[] rend = GameObject.FindGameObjectWithTag("ScoreManager").GetComponentsInChildren<Renderer>();

            foreach (var col in rend)
            {
                col.enabled = false;
            }
            GameEnd = true;
            stateAct = false;
        }
        #endregion


    }
}
