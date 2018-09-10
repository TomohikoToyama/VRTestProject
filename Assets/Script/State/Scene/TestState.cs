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
            InitTest();
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

        private void InitTest()
        {
            PMO = GameObject.Find("ObjectManager").gameObject.GetComponent<PlayerObjectManager>();
            PMO.CreatePlayerUnit();
            PUnit = GameObject.FindGameObjectWithTag("PlayerUnit");
            PSC = PUnit.GetComponent<PlayerStatusController>();
            SoundManager.Instance.PlayBGM(1);
        }
    }
}
