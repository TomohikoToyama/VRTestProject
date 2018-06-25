using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace VR
{
    public class MenuState : IState
    {
        private GameStateManager manager;
        public MenuState(GameStateManager GSM)
        {
            manager = GSM;
            Time.timeScale = 0;
        }
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        public void StateUpdate()
        {

        }
    }
}