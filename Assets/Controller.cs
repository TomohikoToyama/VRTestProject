using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
namespace VR
{
    public class Controller : MonoBehaviour
    {

        [SerializeField]
        public GameObject shot;

        [SerializeField]
        GameObject missile;

        [SerializeField]
        PlayerStatusController PSC;

        // 弾丸発射点
        [SerializeField]
        public Transform muzzle;
        public float cool_time = 0.05f;
        [SerializeField]
        public GameObject player;
        GameObject _parent;
        bool shotLimit = false;

        // Use this for initialization
        void Start()
        {
            _parent = transform.root.gameObject;

        }

        // Update is called once per frame
        void Update()
        {
            var trackedObject = GetComponent<SteamVR_TrackedObject>();
            var device = SteamVR_Controller.Input((int)trackedObject.index);



            //右キー
            if (device.GetPress(SteamVR_Controller.ButtonMask.Trigger))
            {

                 PSC.ShotBullet();
               

            }

            if (device.GetTouchUp(SteamVR_Controller.ButtonMask.Trigger))
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

                Debug.Log("メニューボタンをクリックした");
                // }
            }
            if (device.GetPressDown(SteamVR_Controller.ButtonMask.Grip))
            {
                this.transform.root.position = new Vector3(5, 1, 5);
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
}