using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace VR
{
    public class LoadSceneMover : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        IEnumerator LoadScene()
        {

            AsyncOperation async = SceneManager.LoadScene("Menu");
            async.allowSceneActivation = false;    // シーン遷移をしない

            while (async.progress < 0.9f)
            {
                Debug.Log(async.progress);
                loadingText.text = (async.progress * 100).ToString("F0") + "%";
                loadingBar.fillAmount = async.progress;
                yield return new WaitForEndOfFrame();
            }

            Debug.Log("Scene Loaded");

            loadingText.text = "100%";
            loadingBar.fillAmount = 1;

            yield return new WaitForSeconds(1);

            async.allowSceneActivation = true;    // シーン遷移許可

        }

    }
}