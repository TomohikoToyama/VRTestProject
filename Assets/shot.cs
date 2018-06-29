
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shot : MonoBehaviour {
    public float life_time = 0.5f;
    float time = 0f;

    float forwardTime;
    
    bool shotLimit;
    

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        
        time += Time.deltaTime;
        if (time < 0.5f)
        {

            this.gameObject.GetComponent<Rigidbody>().velocity = transform.forward * 1.0f;


        }
        else if (time > 0.5f)
        {


            Destroy(gameObject);
        }
    }

    
}
