using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VR
{
    public class PlayerStatusController : MonoBehaviour
    {
        public int HP = 3;
        public int MaxHP = 5;
        public int missile = 5;             //ミサイルストック数
        public int Power = 5;               //ショットの威力
        public float missileCT = 2.0f;      //ミサイルチャージタイム
        public float invicibleTime = 2.0f;  //無敵時間
        public bool died = false;           //死亡
        public bool invicible = false;      //無敵
        public string playerName = "Charlotte";//プレイヤー名

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

    }
}
