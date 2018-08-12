using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace VR
{
    public class TestState : MonoBehaviour ,IState
    {
        PlayerStatusController PSC;
        GameObject Controller;
        GameObject PUnit;
        GameObject obj;
        private GameStateManager manager;
        public TestState(GameStateManager GSM)
        {
            //初期化
            manager = GSM;
            Time.timeScale = 1;

        }

        // Update is called once per frame
        public void StateUpdate()
        {
           if(PSC == null)
            InitTest();
            if (PSC.Died == true)
            {
                Destroy(obj);
                manager.SwitchState(new MenuState(manager));
                SceneManager.LoadScene("Menu");
            }
        }

        private void InitTest()
        {
            Controller = GameObject.FindGameObjectWithTag("ActiveController");
            PUnit = (GameObject)Resources.Load("Prefabs/A15-Beast");
            Debug.Log("P" + PUnit);
            obj = Instantiate(PUnit, Controller.transform.position, Quaternion.identity);
            obj.transform.parent = Controller.transform;
            PSC = obj.GetComponent<PlayerStatusController>();
        }
    }
}
