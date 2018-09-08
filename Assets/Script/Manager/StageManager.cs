using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
                       Debug.Log("StageManager Instance Error");
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
            PUnit = GameObject.FindGameObjectWithTag("PlayerUnit");
            Player = GameObject.FindGameObjectWithTag("ActiveController");
            Player.transform.position = PS.transform.position;
            PUnit.transform.rotation = Player.transform.rotation;
            PUnit.transform.Rotate(45,0,0);
            CameraText = GameObject.FindGameObjectWithTag("CameraText");
            RenderSettings.skybox = (Material)Resources.Load("Image/Material/Sky Material");
            GameObject[] model = GameObject.FindGameObjectsWithTag("Model");
            foreach (GameObject obj in model)
            {
                Renderer[] rnd = obj.GetComponentsInChildren<Renderer>();
                foreach(var rnds in rnd)
                {
                    rnds.enabled = false;
                }
            }
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

        #endregion


    }
}
