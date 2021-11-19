using System;
using System.Collections;
using System.Collections.Generic;
using ChessDemo.Character;
using UnityEngine;
using UnityEngine.UI;
using Object = System.Object;


/* 
 * author:
 * createdTime:
 */
namespace ChessDemo.UI 
{
    /// <summary>
    /// 获取当前点击的角色的状态信息并显示在panel上
    /// </summary>

    public class AttributePanel : MonoBehaviour
    {
        private CharacterInputController obj;
        private CharacterStatusBase ch;
       
        private void OnEnable()
        {
            try
            {
                obj = GameManager.GetGM.selectedChess;

                if (obj != null)
                {
                    ch = obj.GetComponent<CharacterStatusBase>();
                    GetCharacterStatus();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Debug.Log("你已经是个成熟的面板了，自己想想为什么会报错");
                Console.WriteLine("你已经是个成熟的面板了，自己想想为什么会报错");
                throw;
            }
            
            
            
        }

        private void OnDisable()
        {
            
        }

        void GetCharacterStatus()
        {
            Debug.Log(transform.Find("HP").name);
            
            transform.Find("HP").Find("value").GetComponent<Text>().text = ch.Hp.ToString();
        }
    }
}