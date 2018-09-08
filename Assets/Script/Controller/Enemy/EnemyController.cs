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
        GameObject Target;
        [SerializeField]
        ParticleSystem explode;
        [SerializeField]
        ParticleSystem fire;
        string PlayerUnit = "PlayerUnit";
        
        GameObject LockField;   //ロックオン画像

        private int roadState = 1;
        private int bossState = 2;

        // Use this for initialization
        void Start()
        {

            explode.Stop();
            fire.Stop();
            ES = gameObject.GetComponent<EnemyStatus>();
            ESobj = (GameObject)Resources.Load("Prefabs/EnmSphere");
            Target = GameObject.FindGameObjectWithTag(PlayerUnit);
            InitEnemy(30);
            LockField = transform.Find("Lock").gameObject;
        }

        // Update is called once per frame
        void Update()
        {
            if (StageManager.Instance.AbleShoot())
            {
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
            ES.ShotStock = 20;
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
            yield return new WaitForSeconds(0.2f);
            var shotClone1 = Instantiate(ESobj,this.transform.position, this.transform.rotation);
            var aim = this.Target.transform.position - this.transform.position;
            var look = Quaternion.LookRotation(aim);
            this.transform.localRotation = look;
            ES.ShotStock -= 1;
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
            explode.Stop();
            if(ES.Health <= 0)
            Destroy(gameObject);
        }
            #endregion

            private void OnTriggerEnter(Collider other)
        {
            

            //プレイヤーの弾でHP減少
            if (other.gameObject.tag == "PlayerBullet")
            {
                //弾のショットから弾の威力を取得して威力分のダメージ

                if (other.gameObject.GetComponent<PlayerShot>() != null)
                {
                    int Damage = other.gameObject.GetComponent<PlayerShot>().Power;
                    
                    ES.Health -= Damage;
                    StartCoroutine(FireCoroutine(other));
                }
                else if (other.gameObject.GetComponent<MissileMover>() != null && gameObject.name == other.gameObject.GetComponent<MissileMover>().GetEnemy())
                {
                    int Damage = other.gameObject.GetComponent<MissileMover>().Power;
                    
                    ES.Health -= Damage;
                    Unlock();
                    StartCoroutine(ExplodeCoroutine());
                }


                //体力がなくなったら死亡処理
                if (ES.Health <= 0)
                {
                    StartCoroutine(ExplodeCoroutine());
                }
            }
        }
    }
}