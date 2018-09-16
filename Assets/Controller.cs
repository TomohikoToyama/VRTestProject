using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.SceneManagement;
namespace VR
{
    public class Controller : MonoBehaviour
    {
        //sceneStateの列挙
        enum typeScene
        {
            Title,
            Menu,
            Stage,
            Test,
        }

        GameStateManager gsm;

        [SerializeField]
        public GameObject shot;

        [SerializeField]
        GameObject missile;

        [SerializeField]
        PlayerStatusController PSC;

        StageSelect SS;
        // 弾丸発射点
        [SerializeField]
        public Transform muzzle;
        public float cool_time = 0.05f;
        [SerializeField]
        public GameObject player;
 
        GameObject _parent;
        bool shotLimit = false;

        bool waitInput = false;
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
         
            //操作可能時、入力を受け付ける
            if(!waitInput)
                Act();



        }

        private void InitController()
        {
            if (GameObject.FindGameObjectWithTag("PlayerUnit") != null && gsm.GetStateName() != null && (gsm.GetStateName() == typeScene.Test.ToString() || gsm.GetStateName() == typeScene.Stage.ToString()))
                PSC = GameObject.FindGameObjectWithTag("PlayerUnit").GetComponent<PlayerStatusController>();

           
        }

        //コントローラーの操作
        private void Act()
        {
            var trackObj = GetComponent<SteamVR_TrackedObject>();
            var device = SteamVR_Controller.Input((int)trackObj.index);
            var touchX = device.GetAxis().x;
            var touchY = device.GetAxis().y;

            //トリガーキー押した時の挙動
            if (device.GetPress(SteamVR_Controller.ButtonMask.Trigger))
            {
                if (PSC == null)
                    InitController();

                   PressTrigger();



            }
            //トリガー離した時の挙動
            if (device.GetTouchUp(SteamVR_Controller.ButtonMask.Trigger))
            {
                if (PSC == null)
                    InitController();
                UpTrigger();
            }

            //タッチパッドを押した時の挙動
            if (device.GetPress(SteamVR_Controller.ButtonMask.Touchpad))
            {
                if (PSC == null)
                    InitController();
                PressTouch(touchX, touchY);
            }

            //タッチパッドを離した時の挙動
            if (device.GetTouchUp(SteamVR_Controller.ButtonMask.Touchpad))
            {
                if (PSC == null)
                    InitController();
                UpTouch();
            }

            //メニューボタン押下時の挙動
            if (device.GetPressDown(SteamVR_Controller.ButtonMask.ApplicationMenu))
            {
                if (PSC == null)
                    InitController();
                PressMenu();
            }
            //グリップボタン押下時の挙動
            if (device.GetPressDown(SteamVR_Controller.ButtonMask.Grip))
            {
                if (PSC == null)
                    InitController();
                PressGrip();
            }
        }

        //ボタンの処理内容群
        #region
        //トリガーを押した時の処理
        private void PressTrigger()
        {
            //テストシーンならショットを撃つ
            if ( gsm.GetStateName() == typeScene.Test.ToString() && gsm.GetStateName() == SceneManager.GetActiveScene().name)
            {
                if(StageManager.Instance.AbleShoot())
                PSC.ShotBullet();
            }
            if (gsm.GetStateName() == typeScene.Menu.ToString() &&  gsm.GetStateName() == SceneManager.GetActiveScene().name)
                MenuObjectManager.Instance.PressController();

        }

        //トリガーを離した時の処理
        private void UpTrigger()
        {

        }

        //タッチパッドを押した時の処理
        private void PressTouch(float X, float Y)
        {
            _parent.transform.Translate(0.05f * X, 0, 0.05f * Y);
            if (gsm.GetStateName() == typeScene.Test.ToString() && gsm.GetStateName() == SceneManager.GetActiveScene().name)
                PSC.Lockon();
        }

        //タッチパッドを離した時の処理
        private void UpTouch()
        {
            //テストシーンならミサイルを撃つ
            if (gsm.GetStateName() != null && (gsm.GetStateName() == typeScene.Test.ToString() || gsm.GetStateName() == typeScene.Stage.ToString()))
            {
                StartCoroutine(PSC.ShotMissile());
            }

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