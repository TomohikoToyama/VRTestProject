using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VR
{
    public class EnemyObjectManager : MonoBehaviour
    {
        protected static EnemyObjectManager instance;
        public static EnemyObjectManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = (EnemyObjectManager)FindObjectOfType(typeof(EnemyObjectManager));

                    if (instance == null)
                    {
                        Debug.Log("MenuObjectManager Instance Error");
                    }
                }

                return instance;
            }
        }

        private const int maxBullet = 256;
        private List<GameObject> poolBulletList = new List<GameObject>(maxBullet); //通常弾用


        [SerializeField]
        private GameObject PoolBullet;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        //弾のオブジェクトプール
        public GameObject ShotBullet(Vector3 position, Vector3 forward)
        {
            GameObject obj;
            for (int i = 0; i < poolBulletList.Count; i++)
            {
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
            obj = (GameObject)Instantiate(PoolBullet, position, transform.rotation);
            obj.SetActive(true);
            obj.transform.position = position;
            obj.transform.eulerAngles = forward;
            obj.GetComponent<PoolObject>().Init();
            poolBulletList.Add(obj);
            return obj;
        }




        public void Return(GameObject obj)
        {

            obj.SetActive(false);

        }

    }
}