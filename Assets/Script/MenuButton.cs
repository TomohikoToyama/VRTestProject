using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButton : MonoBehaviour {

    enum MenuType
    {
        Start,
        Practice,
        Option,
        Quit,
    }
    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }


    public void test (){

        if(GetMenuName() == MenuType.Start.ToString())
        {
            Debug.Log(GetMenuName());
        }else if (GetMenuName() == MenuType.Practice.ToString())
        {
            Debug.Log(GetMenuName());
        }else if (GetMenuName() == MenuType.Option.ToString())
        {
            Debug.Log(GetMenuName());
        }else if (GetMenuName() == MenuType.Quit.ToString())
        {
            Debug.Log(GetMenuName());
        }
    }

    //オブジェクト名を返す
    public string GetMenuName()
    {
        return gameObject.name;   
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Laser")
        {
            test();
        }
    }
}
