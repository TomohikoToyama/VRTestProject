using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VR {
    public class StageScroll : MonoBehaviour {

        int RoadState = 1;
        GameObject player;
        GameObject enm1;
        GameObject enm2;
        float directionX = 0.0f;//X方向進行
        float directionY = 0.0f;//X方向進行
        float directionZ = 0.05f;//X方向進行
                                // Use this for initialization
        void Start() {
            player = GameObject.FindGameObjectWithTag("Player");
            enm1 = GameObject.Find("EnemySpower1");
            enm2 = GameObject.Find("EnemySpower2");
        }

        // Update is called once per frame
        void Update() {
            
        }

        private void FixedUpdate()
        {
            if (StageManager.Instance.GetCurrentState() == RoadState)
            {
                player.transform.Translate(directionX, directionY, directionZ);
                enm1.transform.Translate(directionX, directionY, directionZ);
                enm2.transform.Translate(directionX, directionY, directionZ);
            }
        }
    }
}