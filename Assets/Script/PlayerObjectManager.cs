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
        protected static PlayerObjectManager instance;

        public static PlayerObjectManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = (PlayerObjectManager)FindObjectOfType(typeof(PlayerObjectManager));

                    if (instance == null)
                    {
                        Debug.Log("MenuObjectManager Instance Error");
                    }
                }

                return instance;
            }
        }
        GameObject Controller;  //コントローラー
        GameObject PUnit;       //プレイヤー機体
        GameObject obj;
        private const int maxBullet = 20;
        private const int maxMissile = 10;
        [SerializeField]
        GameObject bulletPrefab;
        GameStateManager gsm;
        GameObject playerSpwaner;
        GameObject player;
        GameObject[] model;
        GameObject laser;
        GameObject laserObj;
        private List<GameObject> poolBulletList =  new List<GameObject>(maxBullet); //通常弾用
        [SerializeField]
        private GameObject PoolBullet;


        private List<GameObject> poolMissileList = new List<GameObject>(maxMissile); //ミサイル用
        [SerializeField]
        private GameObject PoolMissile;


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


     
        public GameObject ShotBullet(Vector3 position, Vector3 forward)
        {
            GameObject obj;
            for (int i = 0; i < poolBulletList.Count; i++) {
                obj = poolBulletList[i];
                if (obj.activeInHierarchy == false)
                {
                    obj.GetComponent<PoolObject>().Init();
                    obj.gameObject.SetActive(true);
                    obj.transform.position = position;
                    obj.transform.eulerAngles = forward;
                    return obj;
                }
            }
                obj = (GameObject)Instantiate(PoolBullet, position, PUnit.transform.rotation);
                obj.SetActive(true);
                obj.transform.position = position;
                obj.transform.eulerAngles = forward;
                obj.GetComponent<PoolObject>().Init();
                poolBulletList.Add(obj);
                return obj;
        }


        public GameObject ShotMissile(Vector3 position, Vector3 forward, GameObject target)
        {
            GameObject obj;
            for (int i = 0; i < poolMissileList.Count; i++)
            {
                obj = poolMissileList[i];
                if (obj.activeInHierarchy == false)
                {
                    obj.GetComponent<PoolObject>().Init();
                    
                    obj.gameObject.SetActive(true);
                    obj.transform.position = position;
                    obj.transform.eulerAngles = forward;
                    obj.GetComponent<MissileMover>().SetEnemy(target);
                    return obj;
                }
            }
            obj = (GameObject)Instantiate(PoolMissile, position, PUnit.transform.rotation);
            obj.SetActive(true);
            obj.transform.position = position;
            obj.transform.eulerAngles = forward;
            obj.GetComponent<PoolObject>().Init();
            poolMissileList.Add(obj);

            obj.GetComponent<MissileMover>().SetEnemy(target);
            return obj;
        }

        public void Return(GameObject obj)
        {

                obj.SetActive(false);
            
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
            poolBulletList.Clear();
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