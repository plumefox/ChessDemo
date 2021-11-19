using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/* 
 * author:
 * createdTime:
 */
namespace ns 
{
    /// <summary>
    /// 
    /// </summary>

    public class LoadingTest : MonoBehaviour
    {
        // Start is called before the first frame update
    

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                GameManager.LoadSceneName = "MainScene";
                SceneManager.LoadScene("LoadScene");
            }
            
        }
    }
}