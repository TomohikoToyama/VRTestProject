using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace VR
{
    public class MenuController : MonoBehaviour
    {
        MenuObjectManager MOM;
        MeshRenderer rnd;
        // Use this for initialization
        void Start()
        {
            MOM = GameObject.FindGameObjectWithTag("MenuManager").GetComponent<MenuObjectManager>();
            rnd = transform.Find("Select").GetComponent<MeshRenderer>();
            rnd.enabled = false; 
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Laser")
            {
                Debug.Log(gameObject.name);
                rnd.enabled = true;
                MOM.SetMenuObject(gameObject);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.tag == "Laser")
            {
                rnd.enabled = false;
                MOM.SetMenuObject(null);
                }
        }


    }
}