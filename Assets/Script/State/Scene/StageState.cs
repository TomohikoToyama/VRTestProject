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