using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
 * author:
 * createdTime:
 */
namespace ChessDemo.Item 
{
    /// <summary>
    /// 技能配置面板 slot下的item
    /// </summary>

    public class SkillConfigItemTruly : ItemTruly
    {
        //重写更新
        public override void UpdateText()
        {
            //更新item下text
            AmountText.text = item.itemInfo;
            if (Amount >0)
            {
                
            }
            else
            {
                Dispose();
            }

        }

        public override void Start()
        {
            base.Start();
        }
    }

}