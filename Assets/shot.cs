
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shot : MonoBehaviour {
    public float life_time = 2.0f;
    float time = 0f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        this.gameObject.transform.Translate(0.03f, 0, 0);
        time += Time.deltaTime;
        if (time > life_time)
        {
            Destroy(gameObject);
        }
    }
}
