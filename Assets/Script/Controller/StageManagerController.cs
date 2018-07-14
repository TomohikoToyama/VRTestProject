using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace VR
{
    [Serializable]
    public class StageManagerController 
    {

        public string stagename;
        public IStageManagerController ismcon;
        //ゲームの状態を保持
        public StageManager sm;
        public StageManagerController()
        {
            sm = new StageManager();

        }
        public void SetStageManagerController(IStageManagerController ismcon)
        {
            this.ismcon = ismcon;
        }
        public string GetStageName()
        {

            string stagename = sm.activeStage.ToString();
            return stagename;
        }

    }
}