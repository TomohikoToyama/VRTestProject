using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VR
{
    public class ShotPattern_2 : MonoBehaviour
    {

        EnemyController EC;
        int nowDif;
        [SerializeField]
        GameObject shotObj;
        enum difficult
        {
            easy = 1,
            normal = 2,
            hard = 3,
            death = 4,
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
            if (!EC.bShot && EC.GetStock() > 0)
            {
                ShotBullet();
            }
        }

        private void ShotBullet()
        {
            if (nowDif == (int)difficult.easy)
                StartCoroutine(EasyShot());
            else if (nowDif == (int)difficult.normal)
                StartCoroutine(NormalShot());
            else if (nowDif == (int)difficult.hard)
                StartCoroutine(HardShot());
            else if (nowDif == (int)difficult.death)
                StartCoroutine(DeathShot());


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
            EnemyObjectManager.Instance.ShotBullet(shotObj,gameObject.transform.position, gameObject.transform.eulerAngles);
            EC.SetStock(1);
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
            EnemyObjectManager.Instance.ShotBullet(shotObj, gameObject.transform.position, gameObject.transform.eulerAngles += new Vector3(5f, 0, 0));
            EnemyObjectManager.Instance.ShotBullet(shotObj, gameObject.transform.position, gameObject.transform.eulerAngles + new Vector3(-5, 0, 0));

            EC.SetStock(1);
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
            EnemyObjectManager.Instance.ShotBullet(shotObj, gameObject.transform.position, gameObject.transform.eulerAngles);
            EC.SetStock(1); 
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
            EnemyObjectManager.Instance.ShotBullet(shotObj, gameObject.transform.position, gameObject.transform.eulerAngles);
            EC.SetStock(1);
            yield return new WaitForSeconds(0.2f);


            EC.bShot = false;
        }
        #endregion
    }
}