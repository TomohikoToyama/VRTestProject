using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VR {
    public class StageScroll : MonoBehaviour {

        int RoadState = 1;
        GameObject player;
        float directionX = 0.0f;//X方向進行
        float directionY = 0.0f;//X方向進行
        float directionZ = 0.1f;//X方向進行
                                // Use this for initialization
        void Start() {
            player = GameObject.FindGameObjectWithTag("Player");
        }

        // Update is called once per frame
        void Update() {
            if(StageManager.Instance.GetCurrentState() == RoadState)
            player.transform.Translate(directionX, directionY, directionZ);
        }
    }
}