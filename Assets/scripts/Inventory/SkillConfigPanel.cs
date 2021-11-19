using System.Collections;
using System.Collections.Generic;
using ChessDemo.Inventory;
using ChessDemo.Item;
using UnityEngine;
using UnityEngine.UI;

/* 
 * author:
 * createdTime:
 */
namespace ChessDemo.Inventory 
{
    /// <summary>
    /// 技能配置面板
    /// </summary>

    public class SkillConfigPanel : Inventory<SkillConfigPanel>
    {
        
        // 技能配置
        //有件点击或者拖动，可以把技能放到这里
        //根据传入的技能物品的技能容量，来设置slot的个数
        //title
        public SkillConfigTitleSlot skillConfigTitleSlot;
        //private CanvasGroup canvasGroup;

       
        
        
        protected override void Start()
        {
            //RefreshItem();
            base.Start();
            skillConfigTitleSlot = GetComponentInChildren<SkillConfigTitleSlot>();
            RemoveAllSlots();
            //canvasGroup = GetComponentInChildren<CanvasGroup>();
            
        }
        public override void AddSlot(int count = 1)
        {
            //增加的是下方的slot
            print(count);
            //base.AddSlot(count);
            //1 实例化
            for (int i = 0; i < count; i++)
            {
                GameObject obj = Instantiate(slotPrefab, transform.position, transform.rotation);
                //2 设置paraent 为content
                obj.transform.SetParent(grid.transform);
                SkillConfigSlot tempSlot = obj.transform.GetComponent<SkillConfigSlot>();
                SkillTemplateItem skillTemplate=(SkillTemplateItem) skillConfigTitleSlot.itemInSlot.GetComponent<ItemTruly>().item;

                if (skillTemplate.effectSlots != null)
                {
                    print("effect count = "+skillTemplate.effectSlots.Length);
                    if (i<skillTemplate.effectSlots.Length && skillTemplate.effectSlots[i] != null)
                    {//如果满足，就显示对应的效果
                        //tempSlot.gameObject.SetActive(true);
                        tempSlot.SetItem(skillTemplate.effectSlots[i]);
                    }

                }
                
            }
            
            RefreshItem();
            //判断有没有效果-》赋予数据
        }

        private void Update()
        {
            
        }
        
       
        
    }
}