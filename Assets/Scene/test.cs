using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour {

    SteamVR_LoadLevel ll;
    public string levelName;

    // Use this for initialization
    void Start()
    {
        ll = this.gameObject.GetComponent<SteamVR_LoadLevel>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SteamVR_LoadLevel.Begin("load");
        }
    }
}
