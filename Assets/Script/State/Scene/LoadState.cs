using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace VR
{
    public class LoadState : IState
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
            SceneLoading(manager.FormatStateName());

        }


        private IEnumerator SceneLoading(string sneceName){

            // シーンの読み込みをする
            async = SceneManager.LoadSceneAsync(sneceName);
            //　読み込みが終わるまで進捗状況をスライダーの値に反映させる
            while (!async.isDone)
            {
              
                yield return null;
            }
            async.allowSceneActivation = true;
        }

    }
}