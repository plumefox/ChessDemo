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
    /// 
    /// </summary>

    public class Equipment : ItemBase
    {
        public EquipmentType equipmentType;
        
        public string equipmentTypeStr
        {
            set
            {
                equipmentType = (EquipmentType) System.Enum.Parse(typeof(EquipmentType), value);
            }
        }
        
        public override string GetTextContent()
        {
            string text =  base.GetTextContent();
            string newText = "装备类型: "+equipmentType.ToString()+"\n";
            return text + newText;
        }
    }

    public enum EquipmentType
    {
        Weapen,
        Skill
    }

}