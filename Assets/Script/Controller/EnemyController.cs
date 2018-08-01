using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {


    private int health; //敵体力
    public int Health
    {
        get { return health;}
        private set{ health = value; }
    }


    // Use this for initialization
    void Start () {
        InitEnemy();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void InitEnemy()
    {
        Health = 10;

    }
    private void OnTriggerEnter(Collider other)
    {

        //プレイヤーの弾でHP減少
        if (other.gameObject.tag == "PlayerBullet")
        {

            Debug.Log("被弾した");
            Health -= 2;

            if (health <= 0)
            {
                Debug.Log("Dead State");
                Destroy(gameObject);

            }
        }
    }
}
