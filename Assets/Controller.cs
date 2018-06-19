using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Controller : MonoBehaviour{

    [SerializeField]
    GameObject prefab;

    [SerializeField]
    GameObject player;
    GameObject _parent;
    bool shotLimit = false;

    // Use this for initialization
    void Start () {
        _parent = transform.root.gameObject;

    }
	
	// Update is called once per frame
	void Update () {
        var trackedObject = GetComponent<SteamVR_TrackedObject>();
        var device = SteamVR_Controller.Input((int)trackedObject.index);

        
        //左キー
        if (device.index == 3 && device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
        {
            device.TriggerHapticPulse(500);
            Instantiate(prefab, _parent.transform.position, Quaternion.identity);
            
            Debug.Log("トリガーを深く引いた");
        }

        if (device.index == 3 && device.GetTouchUp(SteamVR_Controller.ButtonMask.Trigger))
        {
            this.gameObject.transform.Translate(0, 0, -1f);
            Debug.Log("トリガーを離した");
        }


        if (device.index == 4 && device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
        {
            device.TriggerHapticPulse(500);
            Instantiate(prefab, _parent.transform.position, Quaternion.identity);
            this.gameObject.transform.Translate(0, 0, 1f);
            Debug.Log("トリガーを深く引いた");
        }

        if (device.index == 4 && device.GetTouchUp(SteamVR_Controller.ButtonMask.Trigger))
        {
            this.gameObject.transform.Translate(0, 0, -1f);
            Debug.Log("トリガーを離した");
        }

        if (device.GetPress(SteamVR_Controller.ButtonMask.Touchpad))
        {

            _parent.transform.Translate(0.05f * device.GetAxis().x, 0, 0.05f * device.GetAxis().y);
            Debug.Log("タッチパッドをクリックしている");
        }
     
      
        if (device.GetTouchUp(SteamVR_Controller.ButtonMask.Touchpad))
        {
            Debug.Log("タッチパッドを離した");
        }
        if (device.GetPressDown(SteamVR_Controller.ButtonMask.ApplicationMenu))
        {
          //  if (!PlayerManager.(true)) {
                this.transform.root.position = new Vector3(5, 1, 5);
                Debug.Log("メニューボタンをクリックした");
           // }
        }
        if (device.GetPressDown(SteamVR_Controller.ButtonMask.Grip))
        {
            Debug.Log("グリップボタンをクリックした");
        }

        if (device.GetTouch(SteamVR_Controller.ButtonMask.Trigger))
        {
            //Debug.Log("トリガーを浅く引いている");
        }
        if (device.GetPress(SteamVR_Controller.ButtonMask.Trigger))
        {
            //Debug.Log("トリガーを深く引いている");
        }
        if (device.GetTouch(SteamVR_Controller.ButtonMask.Touchpad))
        {
            _parent.transform.Translate(0.025f * device.GetAxis().x, 0, 0.025f * device.GetAxis().y);
            //Debug.Log("タッチパッドに触っている");
        }

    }
}
