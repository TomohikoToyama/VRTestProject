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
        private const int maxBullet = 20;
        [SerializeField]
        GameObject bulletPrefab;
        GameStateManager gsm;
        GameObject playerSpwaner;
        GameObject player;
        GameObject[] model;
        GameObject laser;
        GameObject laserObj;
        private readonly Queue<PoolObject> poolBulletQueue =  new Queue<PoolObject>(maxBullet); //通常弾用
        [SerializeField]
        private PoolObject PoolBullet;

        private readonly Queue<PoolObject> poolMissileQueue = new Queue<PoolObject>(maxBullet); //通常弾用

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



        public T Place<T>(Vector3 position, Vector3 forward) where T : PoolObject
        {
            return (T)Place(position, forward);
        }

        public PoolObject Place(Vector3 position, Vector3 forward)
        {
            PoolObject obj;
            if (poolBulletQueue.Count > 0)
            {
                obj = poolBulletQueue.Dequeue();
                obj.gameObject.SetActive(true);
                obj.transform.position = position;
                obj.transform.eulerAngles = forward;
                obj.Init();
            }
            else
            {
                obj = Instantiate(PoolBullet, position, PUnit.transform.rotation);
                obj.transform.eulerAngles = forward;
                obj.Pool = this;
                obj.Init();
            }
            return obj;
        }
     
       
      
        public void Return(PoolObject obj)
        {
            obj.gameObject.SetActive(false);
            poolBulletQueue.Enqueue(obj);
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