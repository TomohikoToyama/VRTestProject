using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VR
{
    public class StageState : IState
    {
        private GameStateManager manager;

        public StageState(GameStateManager GSM)
        {
            manager = GSM;
            Time.timeScale = 0;
        }
        

        // Update is called once per frame
        public void StateUpdate()
        {

        }
    }
}