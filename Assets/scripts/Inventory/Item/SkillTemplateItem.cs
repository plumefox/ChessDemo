using System.Collections;
using System.Collections.Generic;
using ChessDemo.Skill;
using UnityEngine;

/* 
 * author:
 * createdTime:
 */
namespace ChessDemo.Item 
{
    /// <summary>
    /// 技能物体模板 对标技能数据 方便日后转换
    /// </summary>

    public class SkillTemplateItem : SkillEquipItem
    {
        
        //技能数据，到时候看看能不能配置写进去
        public SkillData skillData;
        //属性的容量,可能用于属性组合 。目前没用
        public int skillAttributeCapacity = 1;
        //存储放入的数据
        //public List<SkillEquipItem> effectSlots;
        public SkillEquipItem[] effectSlots;
        
        public override string GetTextContent()
        {
            string text =  base.GetTextContent();
            string newText = string.Format("绑定技能id: {0}\n属性装配容量: {1}\n",skillData.skillID,skillAttributeCapacity);
            
            if (effectSlots != null)
            {
                newText += "----装配效果----\n";
                for (int i = 0; i < effectSlots.Length; i++)
                {
                    if (effectSlots[i]!=null)
                    {
                        newText += effectSlots[i].skillInfo+"\n";
                    }
                    else
                    {
                        newText += "---------\n";
                    }

                }
            }
            
            return text + newText;
        }

        public SkillTemplateItem()
        {
            skillData = new SkillData();
            //effectSlots = new List<SkillEquipItem>();
            skillData.skillID = 1;
        }

        //增加效果
        public void AddEffectByIndex(SkillEquipItem item,int index)
        {
            if (skillCapacity > 0 && effectSlots == null)
            {
                effectSlots = new SkillEquipItem[skillCapacity];
                Debug.Log("新的 skilleffect length = "+effectSlots.Length);
            }
            
            effectSlots[index] = item;
        }

        //删除效果
        public void RemoveEffectByIndex(int index)
        {
            effectSlots[index] = null;
        }
        
        //清空效果
        public void RemoveAllEffects()
        {
            for (int i = 0; i < effectSlots.Length; i++)
            {
                effectSlots[i] = null;
            }
        }

    }

}