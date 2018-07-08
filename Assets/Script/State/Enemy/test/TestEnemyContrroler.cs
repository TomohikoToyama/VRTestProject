using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VR
{
    public class TestEnemyContrroler : EnemyAIFSM
    {
        public GameObject Bullet;
        private float health;

        //敵 FSMの初期化
        protected override void Initialize()
        {
            health = 30;

            shootCT = 0.5f;
            shootRate = 2.0f;

            GameObject objPlayer = GameObject.FindGameObjectWithTag("Player");
            playerTransform = objPlayer.transform;
            if (!playerTransform)
                Debug.Log("Playerタグのオブジェクトがないよ");

            //弾の発射点取得
            muzzle = gameObject.transform.GetChild(0).transform;
            bulletSpawnPoint = muzzle.GetChild(0).transform;

            //FSMを構築
            ConstructFSM();
        }

        //FSMを構築するメソッド
        private void ConstructFSM()
        {
            //ポイントリスト
            pointList = GameObject.FindGameObjectsWithTag("WandarPoint");

        }
    }
}