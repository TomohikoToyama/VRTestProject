using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace VR { 
public class TitleState : IState {

        private GameStateManager manager;

        public TitleState(GameStateManager GSM)
        {
            //初期化
            manager = GSM;
            Time.timeScale = 1;
        }

        //更新処理
        public void StateUpdate () {

            //何らかのキーを押して画面遷移
            if (Input.anyKey)
            {

                manager.SwitchState(new MenuState(manager));
                SceneManager.LoadScene("Menu");

            }
	    }
    }   
}