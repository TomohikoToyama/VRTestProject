using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace VR
{
    public class MenuState : IState
    {
        private GameStateManager manager;
        public MenuState(GameStateManager GSM)
        {
            manager = GSM;
            Time.timeScale = 1;
        }
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        public void StateUpdate()
        {
            //何らかのキーを押して画面遷移
            if (Input.anyKey)
            {
                manager.SwitchState(new TestState(manager));
                SceneManager.LoadScene("Test");

            }
        }
    }
}