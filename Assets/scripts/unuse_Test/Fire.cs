using System;
using System.Collections;
using System.Collections.Generic;
using Common;
using UnityEngine;

/* 
 * author:
 * createdTime:
 */
namespace ns 
{
    /// <summary>
    /// 
    /// </summary>
    
    public class Fire : MonoBehaviour
    {
        public GameObject skillPrefab;
        //public string key = new string("buttlet");
        
        /*
         * test
         */
        public void fire()
        {
            GameObjectPool.Instance.CreateObject("buttlet",skillPrefab,transform.position,transform.rotation);
            
        }

        private void OnGUI()
        {
            if (GUILayout.Button("shoot"))
            {
                fire();
            }
            if (GUILayout.Button("CLEAR"))
            {
                GameObjectPool.Instance.Clear("buttlet");
            }
        }
    }
}