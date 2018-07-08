using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCtrl : MonoBehaviour {

    private int health = 10;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
   
    private void OnTriggerEnter(Collider other)
    {

        //プレイヤーの弾でHP減少
        if (other.gameObject.tag == "PlayerBullet")
        {

            Debug.Log("被弾した");
            health -= 2;

            if (health <= 0)
            {
                Debug.Log("Dead State");
                Destroy(gameObject);

            }
        }
    }
}
