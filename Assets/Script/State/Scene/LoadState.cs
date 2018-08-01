using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace VR
{
    public class LoadState : MonoBehaviour,IState
    {
        private AsyncOperation async;
        private GameStateManager manager;

        public LoadState(GameStateManager GSM)
        {
            //初期化
            manager = GSM;
            Time.timeScale = 1;
        }
        public void StateUpdate()
        {
            Debug.Log("ロードシーン" + manager.GetStateName());
            StartCoroutine(SceneLoading(manager.GetStateName()));

        }


        private IEnumerator SceneLoading(string sceneName)
        {
            Debug.Log("テスト"+sceneName);
            // シーンの読み込みをする
            async = SceneManager.LoadSceneAsync(sceneName);
            async.allowSceneActivation = false;
            //　読み込みが終わるまで進捗状況をスライダーの値に反映させる
            while (!async.isDone)
            {
              
                yield return null;
            }
            Debug.Log("テスト終了" );
            manager.SwitchState(new MenuState(manager));
            async.allowSceneActivation = true;
        }

    }
}