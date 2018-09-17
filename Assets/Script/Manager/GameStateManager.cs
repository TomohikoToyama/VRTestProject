using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace VR
{
    public class GameStateManager : MonoBehaviour, IGameStateManagerController
    {

        //ゲームの状態を保持
        [SerializeField]
        public IState activeState;
        public IState nextState;
        public GameObject playerObj;
        public PlayerManager PM;
        MenuObjectManager MenuOM;
        PlayerObjectManager PlayerOM;
        StageManager StageM;
        Controller con;
        PlayerManager player;

        private bool stageInit;
        private bool menuInit;
        private string removeName = "VR.";     //state名を渡す時用にnamespaceの文字列を除去
        private string removeState = "State";     //state名を渡す時用にStateの文字列を除去

        public static GameStateManager instance;
        public static GameStateManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = (GameStateManager)FindObjectOfType(typeof(GameStateManager));

                    if (instance == null)
                    {
                        Debug.LogError("GameStateManager Instance Error");
                    }
                }

                return instance;
            }
        }

        void Start()
        {
            GameObject[] obj = GameObject.FindGameObjectsWithTag("GameStateManager");
            if (obj.Length > 1)
            {
                //既に存在してるなら削除
                Destroy(gameObject);
            }
            else
            {
                //管理マネージャーはシーン遷移では破棄させない
                DontDestroyOnLoad(gameObject);
            }

            PlayerOM = GameObject.FindGameObjectWithTag("PlayerObjectManager").GetComponent<PlayerObjectManager>();
            GameStateManagerInit();
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>().PlayerInit();

        }

        // Update is called once per frame
        void Update()
        {
            //activeStateがnullでないならactiveStateのStateUpdateメソッドを実行
            if (activeState != null)
                activeState.StateUpdate();

            SceneInit();

        }

        private void SceneInit(){



            if (GetStateName() == "Menu")
            {

                if (!menuInit && GetStateName() == SceneManager.GetActiveScene().name)
                {

                    PlayerOM.AbleController();
                    menuInit = true;
                    stageInit = false;

                }
            }
            else if (GetStateName() == "Test")
                {
                    if (!stageInit && GetStateName() == SceneManager.GetActiveScene().name)
                    {
                        PlayerOM.DisbleController();
                        PlayerOM.CreatePlayerUnit();
                        StageM = GameObject.FindGameObjectWithTag("StageManager").GetComponent<StageManager>();
                        StageM.InitAct(Callback);
                        SoundManager.Instance.PlayBGM(1);
                        menuInit = false;
                        stageInit = true;
                    }
                }
            
        }


        //ステイト切り替え
        public string SwitchState(IState newState)
        {
            activeState = newState;
            Debug.Log("現在のシーン" + activeState);
            return activeState.ToString();
        }

        //ステイト切り替え
        public string SetNextState(IState next)
        {
            nextState = next;
            Debug.Log("次のシーン" + nextState);
            return nextState.ToString();
        }

        //ゲームステイト初期化
        public void GameStateManagerInit()
        {
           
            activeState = new TitleState(this);

        }

        
        //現在のstate名を取得
        public string GetStateName()
        {
            return activeState.ToString().Replace(removeName, "").Replace(removeState,"");
        }



        public void Callback(string msg)
        {

            Debug.Log("Callback : " + msg); // Callback : おわったよ
        }
    }

}