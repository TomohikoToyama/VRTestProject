using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VR
{
    public class SoundManager : MonoBehaviour
    {
        protected static SoundManager instance;

        public static SoundManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = (SoundManager)FindObjectOfType(typeof(SoundManager));

                    if (instance == null)
                    {
                        Debug.LogError("SoundManager Instance Error");
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