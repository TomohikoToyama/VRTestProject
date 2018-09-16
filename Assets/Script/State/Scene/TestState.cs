using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace VR
{
    public class TestState :IState
    {
        PlayerStatusController PSC;
        PlayerObjectManager PMO;
        GameObject PUnit;
        private GameStateManager manager;
        public TestState(GameStateManager GSM)
        {
            //初期化
            manager = GSM;
            Time.timeScale = 1;
            
        }

        // Update is called once per frame
        public void StateUpdate()
        {
            

            if (StageManager.Instance.GameEnd == true)
            {
                StageManager.Instance.GameEnd = false;
                manager.SwitchState(new MenuState(manager));
                SceneManager.LoadScene("Menu");
            }
        }

       
    }
}
