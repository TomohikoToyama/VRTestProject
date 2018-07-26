using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VR
{
    public class PlayerManager : MonoBehaviour
    {

        private int health;
        bool fMove;
        Vector3 playerPos;

        void start()
        {
           
        }


        // Update is called once per frame
        void Update()
        {

        }

        public void getPlayerInfo()
        {


        }

        public void setPlayerInfo()
        {


        }

        public void PlayerInit()
        {
            Debug.Log("start now");

            GameObject[] obj = GameObject.FindGameObjectsWithTag("Player");
            if (obj.Length > 1)
            {
                Debug.Log("test now");
                //既に存在してるなら削除
                Destroy(gameObject);
            }
            else
            {
                Debug.Log("NOproblem");
                //管理マネージャーはシーン遷移では破棄させない
                DontDestroyOnLoad(gameObject);
            }

        }


        public bool PlayerSpawner(bool spawn)
        {
            //スポーンしてないならスポーンフラグ立てて値返す
            if (!spawn)
            {
                spawn = true;
                return true;
            }

            return false;


        }
    }
}