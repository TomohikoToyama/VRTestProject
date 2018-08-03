using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VR {
    public class TestStage :  IStage{

        PlayerStatusController PSC;
        private StageManager manager;
        public TestStage(StageManager SM)
        {
            manager = SM;
            Time.timeScale = 1;
        }
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        public void StageUpdate()
        {
            
           
        }



    }
}