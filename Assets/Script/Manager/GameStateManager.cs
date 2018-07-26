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
        public IState nextState;
        public GameObject playerObj;
        public PlayerManager PM;

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
            playerObj = GameObject.FindGameObjectWithTag("Player");
            GameStateManagerInit();
            PlayerInit();
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

        //プレイヤー初期化
        public void PlayerInit()
        {
            PM = playerObj.GetComponent<PlayerManager>();
            PM.PlayerInit();
        }
        //
        public string FormatStateName()
        {
            return activeState.ToString();;
        }

    }

}