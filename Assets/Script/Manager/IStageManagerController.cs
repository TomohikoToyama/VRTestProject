using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VR
{
    public interface IStageManagerController
    {

        void StageManagerInit();
        string SwitchState(IState istate);

    }
}