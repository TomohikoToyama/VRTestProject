
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
        if (time < 0.25f)
        {

            this.gameObject.transform.Translate(0.5f, 0, 0);

        }else if (time >= 0.25f)
        {
            this.gameObject.transform.Translate(-0.5f, 0, 0);

        }
        else if (time > 0.5f)
        {


            Destroy(gameObject);
        }
    }
}
