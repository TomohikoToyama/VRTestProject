using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VR
{
    public interface IGameStateManagerController
    {

        void GameStateManagerInit();
        string SwitchState(IState istate);
      
    }
}
