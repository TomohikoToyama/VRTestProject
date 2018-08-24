using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace VR
{
    public class MenuState :  IState
    {
        StageSelect SS;
        PlayerObjectManager PMO;
        bool select;
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
            PMO = GameObject.Find("ObjectManager").gameObject.GetComponent<PlayerObjectManager>();
        }

        // Update is called once per frame
        public void StateUpdate()
        {
            SS = GameObject.FindGameObjectWithTag("StageCard").GetComponent<StageSelect>();

            //何らかのキーを押して画面遷移
            if (SS.select)
            {

                manager.SwitchState(new TestState(manager));
                SceneManager.LoadScene("Test");

            }
        }

        
    }
}