using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VR
{
    public class EnemyController : MonoBehaviour
    {
        EnemyStatus ES;
        public GameObject shot;
        bool bShot;
        GameObject ESobj;
        [SerializeField]
        GameObject Target;
        [SerializeField]
        ParticleSystem explode;
        [SerializeField]
        ParticleSystem fire;
        
        string PlayerUnit = "PlayerUnit";
        
        GameObject LockField;   //ロックオン画像

        private int roadState = 1;
        private int bossState = 2;
        EnemyObjectManager EnemyOM;
        // Use this for initialization
        void Start()
        {

            explode.Stop();
            fire.Stop();
            ES = gameObject.GetComponent<EnemyStatus>();
            ESobj = (GameObject)Resources.Load("Prefabs/EnmSphere");
            InitEnemy(30);
            LockField = transform.Find("Lock").gameObject;
            EnemyOM = GameObject.FindGameObjectWithTag("EnemyObjectManager").GetComponent<EnemyObjectManager>();

        }

        // Update is called once per frame
        void Update()
        {
            if (StageManager.Instance.AbleShoot())
            {
                if(Target == null)
                Target = GameObject.FindGameObjectWithTag("Player");

                ShotBullet();
                var aim = this.Target.transform.position - this.transform.position;
                var look = Quaternion.LookRotation(aim);
                this.transform.localRotation = look;
            }
        }

        //敵機初期化処理
        private void InitEnemy(int _health)
        {
            ES.Health = _health;
            ES.ShotStock = 15;
            ES.Score = 100;
            Target = GameObject.FindGameObjectWithTag("Player");
        }

        //ロックオンされた処理
        public void Locked()
        {
            ES.Locked = true;
            LockField.GetComponent<MeshRenderer>().enabled = true;
        }

        //ミサイル着弾でロックオン解除
        public void Unlock()
        {
            ES.Locked = false;
            LockField.GetComponent<MeshRenderer>().enabled = false;
        }

    

        //ロックオン済みか確認
        public bool CheckLock()
        {
            return ES.Locked;
        }
        //弾を撃つ
        public void ShotBullet()
        {
            if (!bShot && ES.ShotStock > 0)
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
            EnemyOM.ShotBullet(gameObject.transform.position, gameObject.transform.eulerAngles);
            ES.ShotStock -= 1;
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
            if (ES.Health <= 0)
            {
                ES.Locked = false;
                explode.Stop();
                Destroy(gameObject);
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

                    ScoreManager.Instance.ScoreChange(ES.Score/10); //
                    ES.Health -= Damage;
                    StartCoroutine(FireCoroutine(other));
                }
                else if (other.gameObject.GetComponent<MissileMover>() != null && gameObject.name == other.gameObject.GetComponent<MissileMover>().GetEnemy())
                {
                    int Damage = other.gameObject.GetComponent<MissileMover>().Power;
                    ScoreManager.Instance.ScoreChange(ES.Score / 2); //
                    ES.Health -= Damage;
                    Unlock();
                    StartCoroutine(ExplodeCoroutine());
                }


                //体力がなくなったら死亡処理
                if (ES.Health <= 0)
                {
                    ScoreManager.Instance.ScoreChange(ES.Score);
                    StartCoroutine(ExplodeCoroutine());
                }
            }
        }
    }
}