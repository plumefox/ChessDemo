using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/* 
 * author:
 * createdTime:
 */
namespace ns 
{
    /// <summary>
    /// 
    /// </summary>

    public class EnterGameButton : MonoBehaviour
    {
        private Button btn;
        // Start is called before the first frame update
        private void OnEnable()
        {
            btn = GetComponent<Button>();
            btn.onClick.AddListener(EnterGame);
        }

        private void EnterGame()
        {
            GameManager.LoadSceneName = "MainScene";
            SceneManager.LoadScene("LoadScene");
        }
    }
}