using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace VR
{
    public class ResultState : IState
    {
        private GameStateManager manager;

        public ResultState(GameStateManager GSM)
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

        }
    }
}
