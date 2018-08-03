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
        public Transform muzzleone;

        // 弾丸発射点
        [SerializeField]
        public Transform muzzletwo;

        [SerializeField]
        public GameObject player;
        
        public GameObject missile;

        Controller Con;

        private int health = 3;      // 現在体力
        public int  Health { get { return health; } set { health = value; } }
        private int maxhealth = 3;   // 最大体力
        public int Maxhealth { get { return maxhealth; } set { maxhealth = value; } }

        public int missileStuck = 5;             //ミサイルストック数
        public int Power = 5;               //ショットの威力
        public float missileCT = 2.0f;      //ミサイルチャージタイム
        public float missileTimer = 0f;      //ミサイルチャージタイム
        public float shotCT = 0.01f;         //ショット用CT
        public float shotTimer = 0;         //ショット間隔用タイマー
        public float invicibleTime = 2.0f;  //無敵時間
        private bool died = false;           //死亡
        public  bool Died { get { return died; } set { died = value; } }
        public bool invicible = false;      //無敵
        public string playerName = "Charlotte";//プレイヤー名
        bool bShot;

        // Use this for initialization
        void Start()
        {
            shot = (GameObject)Resources.Load("Prefabs/Sphere");
            missile = (GameObject)Resources.Load("Prefabs/missile");
        }

        // Update is called once per frame
        void Update()
        {
            missileTimer += Time.deltaTime;
        }

        //弾を撃つ
        public void ShotBullet()
        {
            if(!bShot)
            StartCoroutine(ShootBulletAndDestroyCoroutine());
        }

        //ショットの非同期処理
        private IEnumerator ShootBulletAndDestroyCoroutine()
        {
            bShot = true;
            yield return new WaitForSeconds(0.1f);
            var shotClone1 = Instantiate(shot, muzzleone.transform.position, player.transform.rotation);
           // shotClone1.transform.eulerAngles = player.transform.eulerAngles;
            bShot = false;
           
          
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
              var misslieClone =  Instantiate(missile, muzzleone.transform.position, Quaternion.identity);
                misslieClone.transform.position = muzzleone.position;
                misslieClone.transform.eulerAngles = player.transform.eulerAngles;
                
            }

        }


        //あたり判定処理
        private void OnTriggerEnter(Collider other)
        {


            //プレイヤーの弾でHP減少
            if (other.gameObject.tag == "EnemyShot")
            {
                //弾のショットから弾の威力を取得して威力分のダメージ

                if (other.gameObject.GetComponent<EnemyShot>() != null)
                {
                    int Damage = other.gameObject.GetComponent<EnemyShot>().Power;

                    Debug.Log("ショットに被弾した");
                    Health -= Damage;
                }
                else if (other.gameObject.GetComponent<MissileMover>() != null)
                {
                    int Damage = other.gameObject.GetComponent<MissileMover>().Power;

                    Debug.Log("ミサイルに被弾した");
                    Health -= Damage;
                }


                //体力がなくなったら死亡処理
                if (health <= 0)
                {
                    Debug.Log("Dead State");
                    Died = true;

                }
            }
        }

    }
}
