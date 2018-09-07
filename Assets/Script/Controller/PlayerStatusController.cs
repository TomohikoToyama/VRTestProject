using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

namespace VR
{
    public class PlayerStatusController : MonoBehaviour
    {
        [SerializeField]
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

        [SerializeField]
        public GameObject LockLaser;

        MissileMover MS;

        bool missileShotting;

        Controller Con;
        private int score;  //スコア
        public int Score { get { return score; } set { score = value; } }
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
        [SerializeField]
        private bool died = false;           //死亡
        public  bool Died { get { return died; } set { died = value; } }
        public bool invicible = false;      //無敵
        public string playerName = "Charlotte";//プレイヤー名
        bool bShot;
        private float interval = 0.1f;
        private GameObject child;
        private int lockNum;
        [SerializeField]
        ParticleSystem explode;
        [SerializeField]
        ParticleSystem fire;
        GameObject Targetting;
        GameObject targetObj;
        Vector3 origin;
        Vector3 direction;
        float sphereRadius = 1.0f;
        Queue<GameObject> queueENemy = new Queue<GameObject>();
        void Start()
        {
            explode.Stop();
            fire.Stop();
            shot = (GameObject)Resources.Load("Prefabs/Sphere");
            missile = (GameObject)Resources.Load("Prefabs/missile");
            Targetting = transform.Find("Targetting").gameObject;

        }

        // Update is called once per frame
        void Update()
        {
            missileTimer += Time.deltaTime;
        }

        //弾を撃つ
        public void ShotBullet()
        {
            if(!bShot && (StageManager.Instance != null && StageManager.Instance.AbleShoot() ))
            StartCoroutine(ShootBulletAndDestroyCoroutine());
        }

        //非同期処理群
        #region
        
        //ショットの非同期処理
        private IEnumerator ShootBulletAndDestroyCoroutine()
        {
            bShot = true;
            yield return new WaitForSeconds(0.15f);
            SoundManager.Instance.PlaySE(0);
            var shotClone1 = Instantiate(shot, muzzleone.transform.position, player.transform.rotation);
           // shotClone1.transform.eulerAngles = player.transform.eulerAngles;
            bShot = false;
           
          
        }


        //被弾時に無敵化処理
        private IEnumerator IsInvicible()
        {
            invicible = true;

            var count = 0;
            //無敵状態を可視化するための演出処理
            var renderBody = transform.Find("Body").gameObject.GetComponent<Renderer>();
            var renderFrontLeg = transform.Find("Front_Leg").gameObject.GetComponent<Renderer>();
            var renderLeftLeg = transform.Find("L_Leg").gameObject.GetComponent<Renderer>();
            var renderRightLeg = transform.Find("R_leg").gameObject.GetComponent<Renderer>();
            while (count < 20)
            {
                renderBody.enabled = !renderBody.enabled;
                renderFrontLeg.enabled = !renderFrontLeg.enabled;
                renderLeftLeg.enabled = !renderLeftLeg.enabled;
                renderRightLeg.enabled = !renderRightLeg.enabled;
                yield return new WaitForSeconds(interval);
                count ++;

            }
            renderRightLeg.enabled = true ;
            renderFrontLeg.enabled = true;
            renderLeftLeg.enabled = true;
            renderRightLeg.enabled = true;

            invicible = false;
            
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
            explode.Stop();
            StageManager.Instance.SetGameOver();
            yield return new WaitForSeconds(3.0f);
            Died = true;
            Destroy(gameObject);
        }
        #endregion

        //ミサイルロックオン
        public void Lockon()
        {
               //ミサイル発射中はロックオン不可
            if (!missileShotting && (StageManager.Instance != null && StageManager.Instance.AbleShoot())) { 
                if (Targetting != null)
                    Targetting.GetComponent<MeshRenderer>().enabled = true;

                //Rayの作成
                origin = transform.position;
                direction = transform.forward;
                Ray ray = new Ray(origin, direction);

                //Rayが当たったオブジェクトの情報
                RaycastHit hit;


                //Rayを飛ばす距離
                float distance = 1000.0f;
                //Raycast(ray, out hit, distance))

                if (Physics.SphereCast(origin ,sphereRadius ,direction ,out hit ,distance))
                {
                    //対象のオブジェクト
                    GameObject hitObj = hit.collider.gameObject;
                    //Rayが当たったオブジェクトのtagがPlayerだったら
                    if (hitObj.tag == "Enemy")
                    {
                        var EC = hitObj.GetComponent<EnemyController>();

                        //ロックオン済みの場合は何もしない
                        if (EC.CheckLock())
                        {

                        }
                        else
                        {
                            lockNum ++;
                            queueENemy.Enqueue(hit.collider.gameObject);
                            EC.Locked();
                            SoundManager.Instance.PlaySE(3);
                        }
    
                     }
                }
             }
        }


        //ミサイル発射
        public IEnumerator ShotMissile()
        {
            Targetting.GetComponent<MeshRenderer>().enabled = false;

            if (!missileShotting && StageManager.Instance.AbleShoot())
            {
                //ロックオン数の数だけミサイル発射
                if (lockNum > 0)
                {
                    for (int i = 0; i < lockNum; i++)
                    {
                        missileShotting = true;
                        
                        targetObj = queueENemy.Dequeue();
                        if (targetObj != null)
                        {
                            SoundManager.Instance.PlaySE(4);
                            var misslieClone = Instantiate(missile, muzzleone.transform.position, Quaternion.identity);
                            misslieClone.transform.position = muzzleone.position;
                            misslieClone.transform.eulerAngles = player.transform.eulerAngles;
                            MS = misslieClone.GetComponent<MissileMover>();
                            MS.SetEnemy(targetObj);
                        }
                        targetObj = null;
                        yield return new WaitForSeconds(0.1f);
                    }
                    lockNum = 0;
                    missileShotting = false;
                }

            }
        }

        

        //あたり判定処理
        private void OnTriggerEnter(Collider other)
        {

            
            //プレイヤーの弾でHP減少
            if (other.gameObject.tag == "EnemyShot" || other.gameObject.tag == "Enemy")
            {
                //弾のショットから弾の威力を取得して威力分のダメージ
                if (!invicible)
                {
                    StartCoroutine( FireCoroutine(other) );
                    //ダメージ時に連続ヒット防止に無敵化処理
                    StartCoroutine(IsInvicible());
                    //敵ショット
                     
                        Health --;
                    
                }

                //体力がなくなったら死亡処理
                if (health <= 0)
                {
                    StartCoroutine(ExplodeCoroutine() );
                   

                }
            }
        }

    }
}
