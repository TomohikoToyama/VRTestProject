using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace VR
{
    public class MenuState :  IState
    {
        bool init = false; 
        StageSelect SS;
        PlayerObjectManager PMO;
        bool select;
        GameObject PS;
        GameObject Player;
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
            SS = GameObject.FindGameObjectWithTag("StageCard").GetComponent<StageSelect>();

            if (!init)
            {
                PS = GameObject.Find("PlayerSpawner");
                Player = GameObject.FindGameObjectWithTag("Player");
                Player.transform.position = PS.transform.position;
                GameObject[] model = GameObject.FindGameObjectsWithTag("Model");

                foreach (GameObject obj in model)
                {
                    Renderer[] rnd = obj.GetComponentsInChildren<Renderer>();
                    foreach (var rnds in rnd)
                    {
                        rnds.enabled = true;
                    }
                }
                init = true;
            }
            /*
            //何らかのキーを押して画面遷移
            if (SS.done )
            {
                init = false;
                manager.SwitchState(new TestState(manager));

                SceneManager.LoadScene("Test");

            }
            */
        }

        
    }
}