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
    /// 技能物品属性
    /// </summary>

    public class SkillAttributeItem : SkillEquipItem
    {
        //属性
        public SkillAttribute skillAttribute;
        
        public string SkillAttributeTypeStr
        {
            set
            {
                skillAttribute = (SkillAttribute) System.Enum.Parse(typeof(SkillAttribute), value);
            }
        }
        
        public override string GetTextContent()
        {
            string text =  base.GetTextContent();
            string newText = string.Format("技能属性: {0}\n",skillAttribute.ToString());
            return text + newText;
        }

    }

    public enum SkillAttribute
    {//金母水火土
        Metal,
        Wood,
        Water,
        Fire,
        Earth
        
    }

}