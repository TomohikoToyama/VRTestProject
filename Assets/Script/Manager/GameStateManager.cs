using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VR
{
    public class GameStateManager : MonoBehaviour , IGameStateManagerController
    {

        //ゲームの状態を保持
        [SerializeField]
        public IState activeState;

        public GameStateManagerController gsmcon;
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
            GameStateManagerInit();
        }
        // Use this for initialization
        void awake()
        {

           
        }

        // Update is called once per frame
        void Update()
        {
            //activeStateがnullでないならactiveStateのStateUpdateメソッドを実行
            if (activeState != null)
                activeState.StateUpdate();
        }



        //ステイト切り替え
        public string SwitchState(IState newState)
        {
            activeState = newState;
            Debug.Log("現在のシーン" + activeState);
            return activeState.ToString();
        }

        //ゲームステイト初期化
        public void GameStateManagerInit()
        {
           
            activeState = new TestState(this);

        }

    }

}