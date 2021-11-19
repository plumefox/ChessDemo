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
    /// 装备类型的技能
    /// </summary>

    public class SkillEquipItem : Equipment
    {
        //技能的id
        //public int skillID;
        public SkillEquipItemType skillEquipItemType;
        //技能的装配容量
        public int skillCapacity;
        //就是技能的描述,区别于普通的描述
        public string skillInfo;
        
        public string skillEquipItemTypeStr
        {
            set
            {
                skillEquipItemType = (SkillEquipItemType) System.Enum.Parse(typeof(SkillEquipItemType), value);
            }
        }
        
        public override string GetTextContent()
        {
            string text =  base.GetTextContent();
            string newText = string.Format("技能类型: {0}\n技能装配容量: {1}\n技能描述: {2}\n",skillEquipItemType.ToString(),skillCapacity,skillInfo);
            return text + newText;
        }
    }
    
    public enum SkillEquipItemType
    {
        Template,
        Attribute,
        Impact,
    }

}