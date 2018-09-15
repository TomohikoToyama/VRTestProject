using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
namespace VR
{
    public class MenuObjectManager : MonoBehaviour
    {

        protected static MenuObjectManager instance;

        public static MenuObjectManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = (MenuObjectManager)FindObjectOfType(typeof(MenuObjectManager));

                    if (instance == null)
                    {
                        Debug.Log("MenuObjectManager Instance Error");
                    }
                }

                return instance;
            }
        }

        enum Menu
        {

            start = 0,
            Option = 1,
            Exit = 2
        }
        GameObject[] menuGroup = new GameObject[3];
        GameObject[] stageGroup = new GameObject[5];
        string nowSelect;
        MeshRenderer[] menuRender;
        MeshRenderer[] stageRender;

        // Use this for initialization
        void Start()
        {
            InitMenu();
        }

        // Update is called once per frame
        void Update()

        {

        }

        //初期処理
        private void InitMenu()
        {

            menuGroup[0] = GameObject.Find("Start");
            menuGroup[1] = GameObject.Find("Option");
            menuGroup[2] = GameObject.Find("Exit");
            for (int i = 0; i < menuGroup.Length; i++)
            {
                Debug.Log(menuGroup[i]);
                menuGroup[i].GetComponent<MeshRenderer>();
            }
            stageGroup[0] = GameObject.Find("StageOne");

        }

        private void AbleMenu()
        {

        }

        private void DisableMenu()
        {

        }

        public void SetMenuObject(GameObject obj)
        {
            if (obj != null)
            {
                nowSelect = obj.name;
                Debug.Log(nowSelect);
            } else if (obj == null)
            {

            }
        }

        public void PressController(){


            Debug.Log("おせてるお");
            if(nowSelect == Menu.start.ToString())
            {

            }
            else if (nowSelect == Menu.Option.ToString())
            {

            }
            else if (nowSelect == Menu.Exit.ToString())
            {
    #if UNITY_EDITOR
                EditorApplication.isPlaying = false;
        #elif UNITY_STANDALONE
      Application.Quit();
                    #endif
            }
        }

    }
}