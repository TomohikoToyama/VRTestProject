using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace VR { 
public class TitleState : IState {

        private GameStateManager manager;
        private GameObject CameraText;
        public TitleState(GameStateManager GSM)
        {
            //初期化
            manager = GSM;
            Time.timeScale = 1;
            CameraText = GameObject.FindGameObjectWithTag("CameraText");
        }

        //更新処理
        public void StateUpdate () {

            //何らかのキーを押して画面遷移
            if (Input.anyKey)
            {
                CameraText.GetComponent <MeshRenderer>().enabled = false;
                manager.SwitchState(new MenuState(manager));
                SceneManager.LoadScene("Menu");

            }
	    }
    }   
}