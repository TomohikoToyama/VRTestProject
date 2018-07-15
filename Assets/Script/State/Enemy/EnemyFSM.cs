using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VR
{
    public class EnemyFSM : MonoBehaviour
    {

        protected Transform playerTransform; //プレイヤーの位置

        protected Vector3 destPos;                      //敵の到達地点

        protected float shootRate;      //敵弾の射撃速度
        protected float shootCT;         //弾のクールタイム

        //策敵する地点のリスト
        protected GameObject[] pointList;

        public Transform muzzle { get; set; }               //砲台
        public Transform bulletSpawnPoint { get; set; }     //弾発射位置

        protected virtual void Initialize() { }
        protected virtual void FSMUpdate() { }
        protected virtual void FSMFixedUpdate() { }

        // Use this for initialization
        void Start()
        {
            Initialize();
        }

        // Update is called once per frame
        void Update()
        {
            FSMUpdate();
        }

        void FixedUpdate()
        {
            FSMFixedUpdate();
        }

      

    }
}