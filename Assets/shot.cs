﻿
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shot : MonoBehaviour {
    private float lifeTime ;
    private float limitTime = 2.0f;
    private float shotSpeed = 20.0f;
  
    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        
        gameObject.GetComponent<Rigidbody>().velocity = transform.forward * shotSpeed ;
        lifeTime += Time.deltaTime;
        
        if(lifeTime >= limitTime)
        {
            lifeTime = 0f;
            Destroy(gameObject);
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
            Destroy(gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "RangeArea")
            Destroy(gameObject);
    }

}
