using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace VR
{
    public class StageState : IState
    {
        PlayerStatusController PSC;
        GameObject Controller;
        GameObject PUnit;
        GameObject obj;
        PlayerObjectManager PMO;
        private GameStateManager manager;
        StageManager SM;

        public StageState(GameStateManager GSM)
        {
            manager = GSM;
            Time.timeScale = 1;
            InitTest();


        }
        

        // Update is called once per frame
        public void StateUpdate()
        {
            if (PSC.Died == true)
            {

                manager.SwitchState(new MenuState(manager));
                SceneManager.LoadScene("Menu");
            }else if (SM.GetClear())
            {
                //クリア演出後にメニューに遷移
                manager.SwitchState(new MenuState(manager));
                SceneManager.LoadScene("Menu");
            }
        }

        private void InitTest()
        {
            PMO = GameObject.Find("ObjectManager").gameObject.GetComponent<PlayerObjectManager>();
            PMO.CreatePlayerUnit();
            PSC = GameObject.FindGameObjectWithTag("PlayerUnit").GetComponent<PlayerStatusController>();
        }
    }
}