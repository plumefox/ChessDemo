using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/* 
 * author:
 * createdTime:
 */
namespace Common 
{
    /// <summary>
    /// 异步加载场景
    /// </summary>

    public class Loading : MonoBehaviour
    {
        
        private AsyncOperation async;

        private int progress;
        // Start is called before the first frame update
        void Start()
        {
            if (GameManager.LoadSceneName.Equals(""))
            {
                Debug.LogError("Can not find the loading scene");
            }

            StartCoroutine(loading());

        }

        IEnumerator loading()
        {
            async = SceneManager.LoadSceneAsync(GameManager.LoadSceneName);
            //加载完成后不会立即跳转
            async.allowSceneActivation = false;
            yield return async;
        }

        // Update is called once per frame
        void Update()
        {
            if (async != null)
            {
                progress = (int)async.progress * 100;
                Debug.Log(progress + "%");

                // if (async.isDone)
                // {
                    async.allowSceneActivation = true;
                // }
            }
            

        }
    }
}