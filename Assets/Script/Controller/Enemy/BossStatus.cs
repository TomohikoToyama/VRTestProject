using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VR
{
    public class BossStatus : MonoBehaviour
    {
        private string type;               // 敵名
        public string Type { get { return type; } set { type = value; } }
        private string weapon;    // 攻撃種類
        public string Weapon { get { return weapon; } set { weapon = value; } }
        private int phase;      //戦闘形態
        public int Phase { get { return phase; } set { phase = value; } }
        private string atkPattern;    // 攻撃パターン
        public string AtkPattern { get { return atkPattern; } set { atkPattern = value; } }
        private string movePattern;    // 移動パターン
        public string MovePattern { get { return movePattern; } set { movePattern = value; } }
        private int state;              //状態
        public int State { get { return state; } set { state = value; } }
        private int health;          // 体力
        public int Health { get { return health; } set { health = value; } }
        private int shotStock;          // 体力
        public int ShotStock { get { return shotStock; } set { shotStock = value; } }
        private float posX;       // 座標X
        public float PosX { get { return posX; } set { posX = value; } }
        private float posY;       // 座標Y
        public float PosY { get { return posY; } set { posY = value; } }
        private float posZ;       // 座標Z
        public float PosZ { get { return posZ; } set { posZ = value; } }
        private int score;          // スコア
        public int Score { get { return score; } set { score = value; } }
        private string item;    // 落下アイテム
        public string Item { get { return item; } set { item = value; } }
        private bool lockOn;    // ロックオン判定
        public bool Lock { get { return lockOn; } set { lockOn = value; } }
        private int difficult;    // ロックオン判定
        public int Difficult { get { return difficult; } set { difficult = value; } }

        

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
