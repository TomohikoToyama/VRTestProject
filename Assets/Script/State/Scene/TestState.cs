using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VR
{
    public class TestState : IState
    {
        private GameStateManager manager;
        public TestState(GameStateManager GSM)
        {
            //初期化
            manager = GSM;
            Time.timeScale = 0;
        }

        // Update is called once per frame
        public void StateUpdate()
        {

        }
    }
}
