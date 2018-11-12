using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace VR
{
    public class MissileMover : PoolObject
    {





        bool shotLimit;
        GameObject muzzle;
        GameObject target;
        private float speed = 30.0f;
        public float Speed { get { return speed; } set { speed = value; } }
        [SerializeField]
        private int power = 10; //ショットの攻撃力
        public int Power { get { return power; } set { power = value; } }
        private float limitTime = 2.0f;
        private float nowTime;
        bool Remain = true;

        //テスト用
        [SerializeField]
        GameObject playerRight;

        public override void Init()
        {
            muzzle = GameObject.FindGameObjectWithTag("PlayerMuzzle");
            nowTime = 0;
        }
        // Use this for initialization
        void Start()
        {

            muzzle = GameObject.FindGameObjectWithTag("PlayerMuzzle");
        }

   
        // Update is called once per frame
        void Update()
        {
            //ターゲット対象生存時、対象に向きながら追尾着弾
            if (target != null)
            {
                this.transform.position = Vector3.MoveTowards(this.transform.position, new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z), Speed * Time.deltaTime);
                var look = Quaternion.LookRotation(transform.position - this.transform.position);
                this.transform.localRotation = look;
            }

            //ターゲット対象が着弾前に死亡などなくなった場合は2秒で破棄
            if (target == null)
            {
                gameObject.GetComponent<Rigidbody>().velocity = transform.forward * Speed;
                nowTime += Time.deltaTime;
                if (nowTime >= limitTime)
                {
                    PlayerObjectManager.Instance.Return(gameObject);

                }

            }
        }
        //ターゲット対象をセット
        public void SetEnemy(GameObject enm)
        {
            target = enm;
        }

        //ターゲット対象名をゲット、着弾対象照合用
        public int GetEnemy()
        {
            return target.GetInstanceID();
        }
        //ターゲット対象に着弾した時、破棄する
        private void OnTriggerEnter(Collider other)
        {
            if (target != null && other.gameObject.GetInstanceID() == target.GetInstanceID())
                PlayerObjectManager.Instance.Return(gameObject);
        }



    }
}