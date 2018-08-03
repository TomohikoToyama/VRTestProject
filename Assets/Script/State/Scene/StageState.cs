using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace VR
{
    public class StageState : IState
    {
        PlayerStatusController PSC;
        private GameStateManager manager;

        public StageState(GameStateManager GSM)
        {
            manager = GSM;
            Time.timeScale = 0;
        }
        

        // Update is called once per frame
        public void StateUpdate()
        {
            if (PSC.Died == true)
            {

                manager.SwitchState(new MenuState(manager));
                SceneManager.LoadScene("Menu");
            }
        }
    }
}