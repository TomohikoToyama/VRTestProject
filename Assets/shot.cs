
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shot : MonoBehaviour {
    public float life_time = 1.0f;
    float time = 0f;

   
    float shotSpeed = 10.0f;
    
    bool shotLimit;

    //テスト用
    [SerializeField]
    GameObject playerRight;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        
        time += Time.deltaTime;
        if (time < life_time)
        {

            this.gameObject.GetComponent<Rigidbody>().velocity = transform.forward * shotSpeed ;


        }
        else if (time > life_time)
        {


            Destroy(gameObject);
        }
    }

    
}
