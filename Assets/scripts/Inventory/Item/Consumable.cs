using System.Collections;
using System.Collections.Generic;
using ChessDemo.Item;
using UnityEngine;

/* 
 * author:
 * createdTime:
 */
namespace ChessDemo.Item  
{
    /// <summary>
    /// 
    /// </summary>

    public class Consumable : ItemBase
    {
        public override string GetTextContent()
        {
            string text =  base.GetTextContent();
            string newText = "" + "";
            return text + newText;
        }
    }

}