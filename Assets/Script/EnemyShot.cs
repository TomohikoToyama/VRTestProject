using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VR
{
    public class EnemyShot : PoolObject
    { 
        private float nowTime = 0.0f;
        private float limitTime = 3.0f;
        private float shotSpeed = 25.0f;
        private int power = 1; //ショットの攻撃力
        public int Power { get { return power; } set { power = value; } }
        private bool remain = true;
        public bool Remain { get { return remain; } set { remain = value; } }
        public GameObject Target;
        bool hormig;
        // Use this for initialization
        void Start()
        {
            Target = GameObject.FindGameObjectWithTag("PlayerUnit");
        }

        // Update is called once per frame
        void Update()
        {

            nowTime += Time.deltaTime;
            if (nowTime >= limitTime)
            {
                EnemyObjectManager.Instance.Return(gameObject);
            }

        }


        private void FixedUpdate()
        {
            
            if ((this.transform.position - Target.transform.position).magnitude > 10f) {


                hormig = true;

            }

            if (hormig)
            {
                // var aim = this.Target.transform.position - this.transform.position;
                //var look = Quaternion.LookRotation(aim);
                //this.transform.localRotation = look;
            }

            gameObject.GetComponent<Rigidbody>().velocity = transform.forward * shotSpeed;
            gameObject.transform.position += new Vector3(0,0, 0.05f);

        }

        //敵ショットのあたり判定
        private void OnTriggerEnter(Collider other)
        {
            if(other.tag == "PlayerUnit")
            EnemyObjectManager.Instance.Return(gameObject);
            else if(other.tag == "BackGround")
                EnemyObjectManager.Instance.Return(gameObject);
        }

        // Use this for initialization
        public override void Init()
        {
            nowTime = 0.0f;
        }


    }
}