using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VR {
    public class PlayerObjectManager : MonoBehaviour {
        //sceneStateの列挙
        enum typeScene
        {
            TitleState,
            MenuState,
            StageState,
            TestState,
        }

        GameObject Controller;  //コントローラー
        GameObject PUnit;       //プレイヤー機体
        GameObject obj;
        GameStateManager gsm;
        // Use this for initialization
        void Start() {
            gsm = GameObject.FindWithTag("GameStateManager").GetComponent<GameStateManager>();
        }

        // Update is called once per frame
        void Update() {

        }

        public void CreatePlayerUnit() {

            if (gsm.GetStateName() == typeScene.MenuState.ToString())
            {
                Controller = GameObject.FindGameObjectWithTag("ActiveController");
                PUnit = (GameObject)Resources.Load("Prefabs/A15-Beast");
                Debug.Log("P" + PUnit);
                obj = Instantiate(PUnit, Controller.transform.position, Quaternion.identity);
                obj.transform.parent = Controller.transform;
                Debug.Log("生成終了");
            }

        }

        public void DestroyPlayerUnit()
        {
            if( gsm.GetStateName() == typeScene.TestState.ToString() || gsm.GetStateName() == typeScene.StageState.ToString())
            {
                PUnit = GameObject.FindGameObjectWithTag("PlayerUnit");
                Destroy(PUnit);
            }
        }
    }

}