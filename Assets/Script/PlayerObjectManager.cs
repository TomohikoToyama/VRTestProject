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
        GameObject playerSpwaner;
        GameObject player;
        GameObject[] model;
        GameObject laser;
        GameObject laserObj;
        // Use this for initialization
        void Start() {
            gsm = GameObject.FindWithTag("GameStateManager").GetComponent<GameStateManager>();


            PUnit = (GameObject)Resources.Load("Prefabs/A15-Beast");
            laser = (GameObject)Resources.Load("Prefabs/Laser");
            laserObj = laser;
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


        //コントローラー表示処理
        public void AbleController()
        {
            Controller = GameObject.FindGameObjectWithTag("ActiveController");
            laserObj = Instantiate(laser, Controller.transform.position, Controller.transform.rotation);
            laserObj.transform.parent = Controller.transform;

            playerSpwaner = GameObject.Find("PlayerSpawner");
            player = GameObject.FindGameObjectWithTag("Player");
            player.transform.position = playerSpwaner.transform.position;
            model = GameObject.FindGameObjectsWithTag("Model");

            foreach (GameObject obj in model)
            {
                Renderer[] rnd = obj.GetComponentsInChildren<Renderer>();
                foreach (var rnds in rnd)
                {
                    rnds.enabled = true;
                }
            }

        }

        //コントローラー表示処理
        public void DisbleController()
        {
            Destroy(laserObj);
            playerSpwaner = GameObject.Find("PlayerSpawner");
            player = GameObject.FindGameObjectWithTag("Player");
            player.transform.position = playerSpwaner.transform.position;
            model = GameObject.FindGameObjectsWithTag("Model");

            foreach (GameObject obj in model)
            {
                Renderer[] rnd = obj.GetComponentsInChildren<Renderer>();
                foreach (var rnds in rnd)
                {
                    rnds.enabled = false;
                }
            }

        }

        //プレイヤー機体の処理
        #region
        public void CreatePlayerUnit() {

            if (gsm.GetStateName() == typeScene.Test.ToString())
            {
                Controller = GameObject.FindGameObjectWithTag("ActiveController");
                obj = Instantiate(PUnit, Controller.transform.position, Controller.transform.rotation);
                obj.transform.parent = Controller.transform;
                PUnit.transform.Rotate(45, 0, 0);
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

        #endregion

    }

}