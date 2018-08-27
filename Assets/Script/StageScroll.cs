using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageScroll : MonoBehaviour {

    GameObject player;
    float directionX = 1.0f;//X方向進行
    float directionY = 0.0f;//X方向進行
    float directionZ = 0.0f;//X方向進行
    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player") ;
	}
	
	// Update is called once per frame
	void Update () {
		player.transform.Translate(directionX, directionY, directionZ);
    }
}
