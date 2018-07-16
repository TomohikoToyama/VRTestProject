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


        float spawnTime;
        [SerializeField]
        StageManager SM;

        [SerializeField]
        GameObject enemy =null;
        GameObject player;
        // Use this for initialization
        void start()
        {
            SM = GameObject.FindGameObjectWithTag("StageManager").GetComponent<StageManager>();
            enemy = GameObject.FindGameObjectWithTag("Enemy");
            player = GameObject.FindGameObjectWithTag("SearchArea");
           
        }

        // Update is called once per frame
        void Update()
        {
            spawnTime += Time.deltaTime;
           
            
            
        }


        void Enemy(){

            var e1 = Instantiate(enemy, this.transform.position + new Vector3(5,5,5), this.transform.rotation);
            e1.tag = "target";
            var e2 = Instantiate(enemy, this.transform.position + new Vector3(0,0, 0), this.transform.rotation);
            var e3 = Instantiate(enemy, this.transform.position + new Vector3(-5, -5, -5), this.transform.rotation);
            var e4 = Instantiate(enemy, this.transform.position + new Vector3(10, 10, 10), this.transform.rotation);

            Debug.Log(SM.GetFormatStage());
            Debug.Log(StageNum.TestStage.ToString());
            if ( SM.GetFormatStage() == StageNum.TestStage.ToString())
            {
                Debug.Log("テスト");
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.tag == "SearchArea")
                Enemy();
        }

    }
}