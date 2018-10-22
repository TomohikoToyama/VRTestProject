using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VR
{
    public class ShotPattern_2 : MonoBehaviour
    {

        EnemyController EC;
        [SerializeField]
        int nowDif;
        GameObject shotObj;
        
        EnemyObjectManager EOM;
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
            EOM = GameObject.FindGameObjectWithTag("EnemyManager").GetComponent<EnemyObjectManager>();


        }

        // Update is called once per frame
        void Update()
        {
            Debug.Log(EOM + "ですよ"); 
            nowDif = 1;
            //nowDif = EC.GetDifficult();
            if (!EC.bShot )
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
            Debug.Log("EASY弾");
            EC.bShot = true;
            var aim = this.EC.Target.transform.position - this.transform.position;
            var look = Quaternion.LookRotation(aim);
            this.transform.localRotation = look;
            EOM.ShotBullet(shotObj,gameObject.transform.position, gameObject.transform.eulerAngles);
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
            EOM.ShotBullet(shotObj, gameObject.transform.position, gameObject.transform.eulerAngles += new Vector3(5f, 0, 0));
            EOM.ShotBullet(shotObj, gameObject.transform.position, gameObject.transform.eulerAngles + new Vector3(-5, 0, 0));

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
            EOM.ShotBullet(shotObj, gameObject.transform.position, gameObject.transform.eulerAngles);
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
            EOM.ShotBullet(shotObj, gameObject.transform.position, gameObject.transform.eulerAngles);
            EC.SetStock(1);
            yield return new WaitForSeconds(0.2f);


            EC.bShot = false;
        }
        #endregion
    }
}