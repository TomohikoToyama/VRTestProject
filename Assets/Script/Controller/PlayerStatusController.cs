using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

namespace VR
{
    public class PlayerStatusController : MonoBehaviour
    {
       
        public GameObject shot;

        // 弾丸発射点
        [SerializeField]
        public Transform muzzle;

        [SerializeField]
        public GameObject player;
        
        public GameObject missile;

        Controller Con;
        public int HP = 3;
        public int MaxHP = 5;
        public int missileStuck = 5;             //ミサイルストック数
        public int Power = 5;               //ショットの威力
        public float missileCT = 2.0f;      //ミサイルチャージタイム
        public float missileTimer = 0f;      //ミサイルチャージタイム
        public float shotCT = 0.1f;         //ショット用CT
        public float shotTimer = 0;         //ショット間隔用タイマー
        public float invicibleTime = 2.0f;  //無敵時間
        public bool died = false;           //死亡
        public bool invicible = false;      //無敵
        public string playerName = "Charlotte";//プレイヤー名

        // Use this for initialization
        void Start()
        {
            shot = (GameObject)Resources.Load("Prefabs/Sphere");
            missile = (GameObject)Resources.Load("Prefabs/missile");
          
        }

        // Update is called once per frame
        void Update()
        {
            shotTimer += Time.deltaTime;
            missileTimer += Time.deltaTime;
        }

        //弾を撃つ
        public void ShotBullet()
        {
            //ショットタイマーがCT以上なら弾を発射
            if (shotTimer >= shotCT) {
              shotTimer = 0.0f;
               
                  var shotClone =  Instantiate(shot, muzzle.transform.position, Quaternion.identity);

                shotClone.transform.position = muzzle.position;
                shotClone.transform.eulerAngles = player.transform.eulerAngles;
              

                Debug.Log("トリガーを深く引いた");
            }
        }

        //ミサイルロックオン
        public void Lockon()
        {


        }

        //ミサイル発射
        public void ShotMissile()
        {
            //ショットタイマーがCT以上なら弾を発射
            if (missileTimer >= missileCT)
            {
                missileTimer = 0.0f;
              var misslieClone =  Instantiate(missile, muzzle.transform.position, Quaternion.identity);
                misslieClone.transform.position = muzzle.position;
                misslieClone.transform.eulerAngles = player.transform.eulerAngles;
                
            }

        }

    }
}
