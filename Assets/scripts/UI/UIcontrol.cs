using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
 * author:
 * createdTime:
 */
namespace ChessDemo.UI 
{
    /// <summary>
    /// 
    /// </summary>

    public class UIcontrol : MonoBehaviour
    {
        
       
        // Start is called before the first frame update

        private void Awake()
        {
            
            HideSkiiButtons();
            HideAttributePanel();

        }

        

        void Start()
        {
            
            
        }

        //隐藏技能按钮
        public void HideSkiiButtons()
        {
          
            transform.Find("SkillButtons").gameObject.SetActive(false);
            //Debug.Log("hide skills");
   
        }

        public void ShowSkiiButtons()
        {
            transform.Find("SkillButtons").gameObject.SetActive(true);
            
        }

        public void ShowUiButtons()
        {
            transform.Find("UIButtons").gameObject.SetActive(true);
        }

        //隐藏设置ui按钮
        public void HideUiButtons()
        {
            transform.Find("UIButtons").gameObject.SetActive(false);
            
        }

        public void ShowAttributePanel()
        {
            transform.Find("AttributePanel").gameObject.SetActive(true);
            
        }

        //隐藏属性显示
        public void HideAttributePanel()
        {
            transform.Find("AttributePanel").gameObject.SetActive(false);
        }
    }
}