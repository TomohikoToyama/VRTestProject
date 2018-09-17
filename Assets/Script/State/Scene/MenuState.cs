using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace VR
{
    public class MenuState :  IState
    {
        bool init = false; 
        private GameStateManager manager;
        public MenuState(GameStateManager GSM)
        {
            manager = GSM;
            Time.timeScale = 1;
            SoundManager.Instance.PlayBGM(0);


          
        }
        // Use this for initialization
        void Start()
        {
           
        }

        // Update is called once per frame
        public void StateUpdate()
        {
          
            
            //何らかのキーを押して画面遷移
            if (MenuObjectManager.Instance.startGame)
            {
                init = false;
                manager.SwitchState(new TestState(manager));

                SceneManager.LoadScene("Test");

            }
            
        }

        
    }
}