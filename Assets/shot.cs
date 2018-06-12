
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shot : MonoBehaviour {
    float limit = 10f;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
        float translation = Time.deltaTime * 10;
        transform.Translate(0, 0, translation);
        if (limit - Time.deltaTime > 0)
        {
            Destroy(this);
        }

    }
}
