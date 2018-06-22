using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VR
{
    public class GameStateManager : MonoBehaviour
    {

        //ゲームの状態を保持
        public IState activeState;
        protected static GameStateManager instance;
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
        // Use this for initialization
        void awake()
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
        }

        // Update is called once per frame
        void Update()
        {

        }


        //ゲームステイト初期化
        public void GameStateManagerInit()
        {
            activeState = new TitleState(this);

        }

    }

}