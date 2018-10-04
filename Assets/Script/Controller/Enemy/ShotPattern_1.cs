using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VR
{
    public class ShotPattern_1 : EnemyShot
    {
        EnemyController EC;
        enum difficult
        {
            easy   = 1,
            normal = 2,
            hard   = 3,
            death  = 4,
        }

       

        // Use this for initialization
        void Start()
        {
            EC = gameObject.Getcomponent<EnemyController>();

        }

        // Update is called once per frame
        void Update()
        {

        }



        public override void Init()
        {

        }

        //非同期処理群
        #region
        //ショットの非同期処理
        private IEnumerator EasyShot()
        {
            EC.bShot = true;
            var aim = this.Target.transform.position - this.transform.position;
            var look = Quaternion.LookRotation(aim);
            this.transform.localRotation = look;
            EnemyObjectManager.Instance.ShotBullet(gameObject.transform.position, gameObject.transform.eulerAngles);
            EC.ShotStock -= 1;
            yield return new WaitForSeconds(0.2f);


            bShot = false;
        }
            #endregion
        
    }
}