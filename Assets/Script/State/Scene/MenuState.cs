﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace VR
{
    public class MenuState :  IState
    {
        StageSelect SS;
        bool select;
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
            SS = GameObject.FindGameObjectWithTag("StageCard").GetComponent<StageSelect>();

            //何らかのキーを押して画面遷移
            if (Input.anyKey)
            {

                manager.SwitchState(new StageState(manager));
                SceneManager.LoadScene("Stage");

            }
        }

        
    }
}