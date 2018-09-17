using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VR
{
    public class EnemySpwaner : MonoBehaviour
    {
        public enum StageNum
        {
            FirstStage = 1,
            TestStage = 9,
        }

        private string place;
        public float nowTime;
        public float spawnTime = 5.0f;

        [SerializeField]
        StageManager SM;

        [SerializeField]
        GameObject enemy =null;
        GameObject player;
        // Use this for initialization
        void start()
        {
            SM = GameObject.FindGameObjectWithTag("StageManager").GetComponent<StageManager>();
            enemy = (GameObject)Resources.Load("Prefabs/EnemyShip");
           
        }

        // Update is called once per frame
        void Update()
        {
            nowTime += Time.deltaTime;
            if (StageManager.Instance.progress >= 750)
                StartCoroutine(Enemy());


        }


         private IEnumerator Enemy(){

            nowTime = 0;
            var e1 = Instantiate(enemy, this.transform.position + new Vector3(5,0,5), this.transform.rotation);
            SoundManager.Instance.PlaySE(6);
            yield return new WaitForSeconds(0.3f);
            var e2 = Instantiate(enemy, this.transform.position + new Vector3(0,0, 0), this.transform.rotation);
            SoundManager.Instance.PlaySE(6);
            yield return new WaitForSeconds(0.3f);
            var e3 = Instantiate(enemy, this.transform.position + new Vector3(-5, 0, -5), this.transform.rotation);
            SoundManager.Instance.PlaySE(6);
            yield return new WaitForSeconds(0.3f);
            var e4 = Instantiate(enemy, this.transform.position + new Vector3(10, 0, 10), this.transform.rotation);
            SoundManager.Instance.PlaySE(6);
            yield return new WaitForSeconds(0.3f);


        }

        private void OnTriggerEnter(Collider other)
        {
        }

    }
}