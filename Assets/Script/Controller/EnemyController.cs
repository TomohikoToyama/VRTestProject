﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VR
{
    public class EnemyController : MonoBehaviour
    {
        EnemyStatusController ESC;
        public GameObject shot;
        bool bShot;
        GameObject ESobj;
        GameObject Target;
        string PlayerUnit = "PlayerUnit";

        // Use this for initialization
        void Start()
        {
            ESC = gameObject.GetComponent<EnemyStatusController>();
            ESobj = (GameObject)Resources.Load("Prefabs/EnmSphere");
            Target = GameObject.FindGameObjectWithTag(PlayerUnit);
            InitEnemy(10);

        }

        // Update is called once per frame
        void Update()
        {
            ShotBullet();
        }

        //敵機初期化処理
        private void InitEnemy(int _health)
        {
            ESC.Health = _health;

        }

        //弾を撃つ
        public void ShotBullet()
        {
            if (!bShot)
                StartCoroutine(ShootBulletAndDestroyCoroutine());
        }

        //ショットの非同期処理
        private IEnumerator ShootBulletAndDestroyCoroutine()
        {
            
           

            bShot = true;
            yield return new WaitForSeconds(0.2f);
            var shotClone1 = Instantiate(ESobj,this.transform.position, this.transform.rotation);
            var aim = this.Target.transform.position - this.transform.position;
            var look = Quaternion.LookRotation(aim);
            this.transform.localRotation = look;
            bShot = false;
            Debug.Log("たまたま");


        }

        private void OnTriggerEnter(Collider other)
        {
            

            //プレイヤーの弾でHP減少
            if (other.gameObject.tag == "PlayerBullet")
            {
                //弾のショットから弾の威力を取得して威力分のダメージ

                if (other.gameObject.GetComponent<PlayerShot>() != null)
                {
                    int Damage = other.gameObject.GetComponent<PlayerShot>().Power;

                    Debug.Log("ショットに被弾した");
                    ESC.Health -= Damage;
                }else if (other.gameObject.GetComponent<MissileMover>() != null)
                {
                    int Damage = other.gameObject.GetComponent<MissileMover>().Power;

                    Debug.Log("ミサイルに被弾した");
                    ESC.Health -= Damage;
                }


                //体力がなくなったら死亡処理
                if (ESC.Health <= 0)
                {
                    Debug.Log("Dead State");
                    Destroy(gameObject);

                }
            }
        }
    }
}