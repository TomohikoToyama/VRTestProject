﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VR
{
    public class ShotPattern_1 : MonoBehaviour
    {
        EnemyController EC;
        int nowDif;
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
            EC = gameObject.GetComponent<EnemyController>();
            nowDif = EC.GetDifficult();

        }

        // Update is called once per frame
        void Update()
        {
            if (!EC.bShot && EC.ShotStock > 0)
            {
                ShotBullet();
            }
        }



        private void ShotBullet()
        {
            if (nowDif == (int)difficult.easy)
                EasyShot();
            else if (nowDif == (int)difficult.normal)
                NormalShot();
            else if (nowDif == (int)difficult.hard)
                HardShot();
            else if (nowDif == (int)difficult.death)
                DeathShot();

        }


        //非同期処理群
        #region
        //ショットの非同期処理
        //難易度EASY
        private IEnumerator EasyShot()
        {
            EC.bShot = true;
            var aim = this.EC.Target.transform.position - this.transform.position;
            var look = Quaternion.LookRotation(aim);
            this.transform.localRotation = look;
            EnemyObjectManager.Instance.ShotBullet(gameObject.transform.position, gameObject.transform.eulerAngles);
            EC.ShotStock -= 1;
            yield return new WaitForSeconds(0.2f);


            EC.bShot = false;
        }

        //難易度NORMAL
        private IEnumerator NormalShot()
        {
            EC.bShot = true;
            var aim = this.EC.Target.transform.position - this.transform.position;
            var look = Quaternion.LookRotation(aim);
            this.transform.localRotation = look;
            EnemyObjectManager.Instance.ShotBullet(gameObject.transform.position, gameObject.transform.eulerAngles += new Vector3(5f, 0, 0));
            EnemyObjectManager.Instance.ShotBullet(gameObject.transform.position, gameObject.transform.eulerAngles + new Vector3(-5, 0, 0));

            EC.ShotStock -= 1;
            yield return new WaitForSeconds(0.2f);


            EC.bShot = false;
        }

        //難易度HARD
        private IEnumerator HardShot()
        {
            EC.bShot = true;
            var aim = this.EC.Target.transform.position - this.transform.position;
            var look = Quaternion.LookRotation(aim);
            this.transform.localRotation = look;
            EnemyObjectManager.Instance.ShotBullet(gameObject.transform.position, gameObject.transform.eulerAngles);
            EC.ShotStock -= 1;
            yield return new WaitForSeconds(0.2f);


            EC.bShot = false;
        }

        //難易度DEATH
        private IEnumerator DeathShot()
        {
            EC.bShot = true;
            var aim = this.EC.Target.transform.position - this.transform.position;
            var look = Quaternion.LookRotation(aim);
            this.transform.localRotation = look;
            EnemyObjectManager.Instance.ShotBullet(gameObject.transform.position, gameObject.transform.eulerAngles);
            EC.ShotStock -= 1;
            yield return new WaitForSeconds(0.2f);


            EC.bShot = false;
        }
        #endregion

    }
}