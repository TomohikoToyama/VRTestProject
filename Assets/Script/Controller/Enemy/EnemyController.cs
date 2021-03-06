﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VR
{
    public class EnemyController : EnemyStatus
    {
        
        enum currentState
        {
            None = 0,
            Act = 1,
            Attack = 2,
            Escape = 3,
            Death = 4
        }
        public GameObject shot;
        public bool bShot;
        GameObject ESobj;
        [SerializeField]
        public GameObject Target;
        [SerializeField]
        ParticleSystem explode;
        [SerializeField]
        ParticleSystem fire;
        public int dif;
        string PlayerUnit = "PlayerUnit";
        [SerializeField]
        EnemyStatus ES;
        
        GameObject LockField;   //ロックオン画像

        private int roadState = 1;
        private int bossState = 2;
        EnemyObjectManager EnemyOM;
        // Use this for initialization
        void Start()
        {
            Target = GameObject.FindGameObjectWithTag("Player");
            ES = gameObject.GetComponent<EnemyStatus>();
            explode.Stop();
            fire.Stop();
            ESobj = (GameObject)Resources.Load("Prefabs/EnmSphere");
            InitEnemy(30);
            LockField = transform.Find("Lock").gameObject;
            EnemyOM = GameObject.FindGameObjectWithTag("EnemyManager").GetComponent<EnemyObjectManager>();
            

        }

        // Update is called once per frame
        void Update()
        {
            Difficult = 1;
            if(State == (int)currentState.None) {


            }else if(State == (int)currentState.Act)
            {

            }else if(State == (int)currentState.Attack) {


            }
            else if(State == (int)currentState.Escape)
            {


            }else if(State == (int)currentState.Death)
            {

            }
            if (StageManager.Instance.AbleShoot())
            {
                if(Target == null)
                Target = GameObject.FindGameObjectWithTag("Player");

             //   ShotBullet();

                
            }
        }

        private void FixedUpdate()
        {
         
            
        }

        private void stateChange()
        {

        }
        public int GetDifficult()
        {
            
            return Difficult;
        }

       

        //敵機初期化処理
        private void InitEnemy(int _health)
        {
            State = (int)currentState.None;
            Health = _health;
            ShotStock = 15;
            Score = 100;
            Target = GameObject.FindGameObjectWithTag("Player");
        }

        //ロックオンされた処理
        public void Locked()
        {
            Lock = true;
            LockField.GetComponent<MeshRenderer>().enabled = true;
        }

        //ミサイル着弾でロックオン解除
        public void Unlock()
        {
            Lock = false;
            LockField.GetComponent<MeshRenderer>().enabled = false;
        }

        public int GetStock()
        {
            return ShotStock;
        }
        public void SetStock(int num)
        {
            ShotStock -= num;

        }

        //ロックオン済みか確認
        public bool CheckLock()
        {
            return Lock;
        }
        //弾を撃つ
        public void ShotBullet()
        {
            if (!bShot && ShotStock > 0)
                StartCoroutine(ShootBulletAndDestroyCoroutine());
        }

        //非同期処理群
        #region
        //ショットの非同期処理
        private IEnumerator ShootBulletAndDestroyCoroutine()
        {
            

            bShot = true;
            var aim = this.Target.transform.position - this.transform.position;
            var look = Quaternion.LookRotation(aim);
            this.transform.localRotation = look;
            //EnemyOM.ShotBullet(gameObject.transform.position, transform.eulerAngles);
            ShotStock -= 1;
            yield return new WaitForSeconds(0.2f);
           
           
            bShot = false;


        }

        //被弾時の処理
        private IEnumerator FireCoroutine(Collider shot)
        {
            fire.transform.position = shot.gameObject.transform.position;
            fire.transform.LookAt(shot.gameObject.transform);
            SoundManager.Instance.PlaySE(2);
            fire.Play();
            yield return new WaitForSeconds(0.3f);
            fire.Stop();
        }

        //破壊時の処理
        private IEnumerator ExplodeCoroutine()
        {
            explode.Play();
            SoundManager.Instance.PlaySE(1);
            yield return new WaitForSeconds(0.3f);
            if (Health <= 0)
            {
                Lock = false;
                explode.Stop();
                EnemyOM.Return(gameObject);
            }
           
            explode.Stop();
           
        }
            #endregion

            private void OnTriggerEnter(Collider other)
        {

            if (other.gameObject.tag == "Water")
                SoundManager.Instance.PlaySE(6);

            //プレイヤーの弾でHP減少
            if (other.gameObject.tag == "PlayerBullet")
            {
                //弾のショットから弾の威力を取得して威力分のダメージ

                if (other.gameObject.GetComponent<PlayerShot>() != null)
                {
                    int Damage = other.gameObject.GetComponent<PlayerShot>().Power;

                    ScoreManager.Instance.ScoreChange(Score /10); //
                    Health -= Damage;
                    StartCoroutine(FireCoroutine(other));
                }
                else if (other.gameObject.GetComponent<MissileMover>() != null && gameObject.GetInstanceID() == other.gameObject.GetComponent<MissileMover>().GetEnemy())
                {
                    int Damage = other.gameObject.GetComponent<MissileMover>().Power;
                    ScoreManager.Instance.ScoreChange(Score / 2); //
                    Health -= Damage;
                    Unlock();
                    StartCoroutine(ExplodeCoroutine());
                }


                //体力がなくなったら死亡処理
                if (Health <= 0)
                {
                    ScoreManager.Instance.ScoreChange(Score);
                    StartCoroutine(ExplodeCoroutine());
                }
            }
        }
    }
}