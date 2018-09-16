using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VR {
    public class PlayerObjectManager : MonoBehaviour {
        //sceneStateの列挙
        enum typeScene
        {
            Title,
            Menu,
            Stage,
            Test,
        }

        GameObject Controller;  //コントローラー
        GameObject PUnit;       //プレイヤー機体
        GameObject obj;
        int bulletLimit = 20;
        GameObject[] playerBullet = new GameObject[20];
        GameStateManager gsm;
        // Use this for initialization
        void Start() {
            gsm = GameObject.FindWithTag("GameStateManager").GetComponent<GameStateManager>();
        }

        // Update is called once per frame
        void Update() {

        }

        public void LoadBullet()
        {
            for (int i = 0; i < bulletLimit; i++)
            {
                //var shotClone1 = Instantiate(shot, muzzleone.transform.position, player.transform.rotation);
                //playerBullet[i] = 
            }
        }

        //プレイヤーショットの処理
        public void CreateBullet(GameObject obj)
        {

        }

        public void DestroyBullet(GameObject obj)
        {

        }



        //プレイヤー機の処理
        public void LoadPlayerUnit()
        {

        }

        public void CreatePlayerUnit() {

            if (gsm.GetStateName() == typeScene.Test.ToString())
            {
                Controller = GameObject.FindGameObjectWithTag("ActiveController");
                PUnit = (GameObject)Resources.Load("Prefabs/A15-Beast");
                Debug.Log("P" + PUnit);
                obj = Instantiate(PUnit, Controller.transform.position, Quaternion.identity);
                obj.transform.parent = Controller.transform;
                Debug.Log("生成終了");
            }

        }

        public void DestroyPlayerUnit()
        {
            if( gsm.GetStateName() == typeScene.Test.ToString() || gsm.GetStateName() == typeScene.Stage.ToString())
            {
                PUnit = GameObject.FindGameObjectWithTag("PlayerUnit");
                Destroy(PUnit);
            }
        }
    }

}