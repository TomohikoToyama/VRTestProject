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
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}