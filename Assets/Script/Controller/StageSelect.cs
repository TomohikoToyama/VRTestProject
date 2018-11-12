using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VR
{
    public class StageSelect : MonoBehaviour
    {
        public bool done = false;
        public bool select = false;
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnTriggerEnter(Collider other)
        {
            gameObject.GetComponent<Renderer>().material.color = new Color(0.3f, 0.4f, 0.9f, 0.3f);
            select = SetSelect();
        }

        public bool SetSelect(){

            return true;
        }

        public bool SetDone()
        {

            return true;
        }
    }
}