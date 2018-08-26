using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VR {
    public class TestStage :  IStage{
        // Skyboxのマテリアル
        
        private Material skybox;
        PlayerStatusController PSC;
        private StageManager manager;
        public TestStage(StageManager SM)
        {
            manager = SM;
            Time.timeScale = 1;
            // Skyboxを変更する
            //var SB = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Skybox>();
            RenderSettings.skybox = Resources.Load("Prefabs/Skybox") as Material;
        }
        void Start()
        {
            
        }
        

        // Update is called once per frame
        public void StageUpdate()
        {
            
           
        }



    }
}