using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VR
{
    public class PlayerShot : PoolObject
    {

        private float limitTime = 2.0f;
        private float shotSpeed = 30.0f;
        private float nowTime =  0.0f;
        private int power = 1; //ショットの攻撃力
        public int Power { get { return power; } set { power = value; } }
        private bool remain = true;
        public bool Remain { get { return remain; } set { remain = value; } }

        // Use this for initialization
        public override void Init()
        {
            nowTime = 0.0f;
        }

        // Update is called once per frame
        void Update()
        {
            gameObject.GetComponent<Rigidbody>().velocity = transform.forward * shotSpeed;
            nowTime += Time.deltaTime;
            if (nowTime >= limitTime)
            {

                PlayerObjectManager.Instance.Return(gameObject);
            }
        }


        //敵ショットのあたり判定
        private void OnTriggerEnter(Collider other)
        {

            if (other.gameObject.tag == "Enemy")
            {

                PlayerObjectManager.Instance.Return(gameObject);
            }

        }
    }
}