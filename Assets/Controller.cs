using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
namespace VR
{
    public class Controller : MonoBehaviour
    {
        //sceneStateの列挙
        enum typeScene
        {
            TitleState,
            MenuState,
            StageState,
            TestState,
        }

        GameStateManager gsm;

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
            gsm = GameObject.FindWithTag("GameStateManager").GetComponent<GameStateManager>();
            Debug.Log(gsm);
        }

        // Update is called once per frame
        void Update()
        {
            var trackObj = GetComponent<SteamVR_TrackedObject>();
            var device = SteamVR_Controller.Input((int)trackObj.index);
            var touchX = device.GetAxis().x;
            var touchY = device.GetAxis().y;

            //トリガーキー押した時の挙動
            if (device.GetPress(SteamVR_Controller.ButtonMask.Trigger))
            {
                PressTrigger();
            }
            
            //トリガー離した時の挙動
            if (device.GetTouchUp(SteamVR_Controller.ButtonMask.Trigger))
            {
                UpTrigger();
            }
            
            //タッチパッドを押した時の挙動
            if (device.GetPress(SteamVR_Controller.ButtonMask.Touchpad))
            {
                PressTouch(touchX, touchY);
            }

            //タッチパッドを離した時の挙動
            if (device.GetTouchUp(SteamVR_Controller.ButtonMask.Touchpad))
            {
                UpTouch();
            }

            //メニューボタン押下時の挙動
            if (device.GetPressDown(SteamVR_Controller.ButtonMask.ApplicationMenu))
            {
                PressMenu();
            }
            //グリップボタン押下時の挙動
            if (device.GetPressDown(SteamVR_Controller.ButtonMask.Grip))
            {
                PressGrip();
            }

           
        }

        //ボタンの処理内容群
        #region
        //トリガーを押した時の処理
        private void PressTrigger()
        {
            Debug.Log("テスト" +typeScene.TestState.ToString());
            //テストシーンならショットを撃つ
            if (gsm.GetStateName() != null && gsm.GetStateName() == typeScene.TestState.ToString())
                PSC.ShotBullet();
        }

        //トリガーを離した時の処理
        private void UpTrigger()
        {

        }

        //タッチパッドを押した時の処理
        private void PressTouch(float X, float Y)
        {
            _parent.transform.Translate(0.05f * X, 0, 0.05f * Y);
        }

        //タッチパッドを離した時の処理
        private void UpTouch()
        {
            //テストシーンならショットを撃つ
            if (gsm.GetStateName() != null && (gsm.GetStateName() == typeScene.TestState.ToString() || gsm.GetStateName() == typeScene.StageState.ToString()) )
                PSC.ShotMissile();

        }

        //メニューボタンを押した時の処理
        private void PressMenu()
        {

        }

        //グリップを押した時の処理
        private void PressGrip()
        {
            this.transform.root.position = new Vector3(5, 1, 5);
        }
        #endregion

    }
}