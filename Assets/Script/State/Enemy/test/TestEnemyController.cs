using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VR
{
    public class TestEnemyController : EnemyAIFSM
    {
        public GameObject Bullet;
        private float health;
        [SerializeField]
        public GameObject objPlayer;
        //敵 FSMの初期化
        protected override void Initialize()
        {
            health = 30;

            shootCT = 0.0f;
            shootRate = 2.0f;
            Debug.Log("オブジェクトとったよ");
            GameObject objPlayer = GameObject.FindGameObjectWithTag("Player_Right");
            playerTransform = objPlayer.transform;
            if (!playerTransform) { 
            Debug.Log("Playerタグのオブジェクトがないよ");
             }
            Debug.Log(playerTransform);
            //弾の発射点取得
            muzzle = gameObject.transform.GetChild(0).transform;
            bulletSpawnPoint = muzzle.GetChild(0).transform;

            //FSMを構築
            ConstructFSM();

        }

        //更新
        protected override void FSMUpdate()
        {
            //ショットのCT処理
            shootCT += Time.deltaTime;
        }

        //stateの更新
        protected override void FSMFixedUpdate()
        {

            CurrentState.Reason(playerTransform, transform);
            CurrentState.Act(playerTransform, transform);
        }
        //FSMを構築するメソッド
        private void ConstructFSM()
        {
            //ポイントリスト
            pointList = GameObject.FindGameObjectsWithTag("WandarPoint");

            Transform[] waypoints = new Transform[pointList.Length];
            int i = 0;
            foreach(GameObject obj in pointList){

                waypoints[i] = obj.transform;
                i++;
            }


            //戦闘圏外stateの遷移


            //攻撃stateの遷移
            AttackMode attack = new AttackMode(waypoints);
            attack.AddTransition(Transition.LostPlayer, FSMStateID.Pullout);
            attack.AddTransition(Transition.NoHealth, FSMStateID.Dead);
        }

        //状態の遷移
        public void SetTransition(Transition tran)
        {
            PerformTransition(tran);
        }
        //弾の衝突判定
        void OnConllisionEnter(Collision collision)
        {
            //プレイヤーの弾でHP減少
            if (collision.gameObject.tag == "PlayerBullet")
            {
                health -= 2;

                if (health <= 0)
                {
                    Debug.Log("Dead State");
                    SetTransition(Transition.NoHealth);

                }
            }

        }

        //爆発処理
        public void Explode()
        {
            float rndX = Random.Range(10.0f, 30.0f);
            float rndZ = Random.Range(10.0f, 30.0f);
            for (int i = 0; i < 3; i++)
            {

                this.gameObject.GetComponent<Rigidbody>().AddExplosionForce(10000.0f, transform.position - new Vector3(rndX, 10.0f, rndZ), 40.0f, 10.0f);
                this.gameObject.GetComponent<Rigidbody>().velocity = transform.TransformDirection(new Vector3(rndX, 20.0f, rndZ));
            }

            Destroy(gameObject, 1.5f);
        }

        //弾発射
        public void ShootBullet()
        {
            if (shootCT >= shootRate)
            {
                Instantiate(Bullet, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
                shootCT = 0.0f;
            }
        }
    }
}