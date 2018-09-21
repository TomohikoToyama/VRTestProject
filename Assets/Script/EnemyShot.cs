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
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

            gameObject.GetComponent<Rigidbody>().velocity = transform.forward * shotSpeed;
            nowTime += Time.deltaTime;
            if (nowTime >= limitTime)
            {
                EnemyObjectManager.Instance.Return(gameObject);
            }

        }

        //敵ショットのあたり判定
        private void OnTriggerEnter(Collider other)
        {
            if(other.tag == "PlayerUnit")
            EnemyObjectManager.Instance.Return(gameObject);
        }

        // Use this for initialization
        public override void Init()
        {
            nowTime = 0.0f;
        }


    }
}