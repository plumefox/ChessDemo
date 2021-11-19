using System;
using System.Collections;
using System.Collections.Generic;
using ChessDemo.Item;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.EventSystems;

/* 
 * author:
 * createdTime:
 */
namespace ChessDemo.Inventory 
{
    /// <summary>
    /// 技能配置panel的slot
    /// </summary>

    public class SkillConfigSlot : Slot
    {
        //可装备技能的类型
        //public SkillEquipItem skillEquipItem;
        // public virtual void SetItem(ItemBase item)
        // {
        //     //获取物体，active or disable
        //     itemInSlot = transform.Find("item").gameObject;
        //     itemInSlot.SetActive(true);
        //     itemInSlot.GetComponent<ItemTruly>().SetItem(item);
        // }
        
        //点击事件
        public override void OnPointerDown(PointerEventData eventData)
        {
            
            ItemTruly currentItemTruly = itemInSlot.GetComponent<ItemTruly>();
            //获得点击格子所在的序列号
            int selfIdex = transform.GetSiblingIndex();
            Debug.Log("我是第"+selfIdex+"个孩子");
            
            //格子里有物体
            if (itemInSlot.activeInHierarchy)
            {
                print("技能盒子里有物体");
                if (InventoryManager.Instance.isPicking)
                {//手上有物体

                    //如果是技能装备 且是属性或者影响物品
                    if (InventoryManager.Instance.pickItem.item is SkillAttributeItem)
                    {
                        //如果是属性
                        if (InventoryManager.Instance.pickItem.Amount == 1)
                        {//手上只有一个才能放下，交换
                            
                            //获得信息----强转加入
                            SkillTemplateItem skillTemplate=(SkillTemplateItem) InventoryManager.Instance.skillPanel.skillConfigTitleSlot.itemInSlot.GetComponent<ItemTruly>().item;
                            //skillTemplate.effectSlots.Remove((SkillAttributeItem) currentItemTruly.item);
                            skillTemplate.RemoveEffectByIndex(selfIdex);
                            skillTemplate.AddEffectByIndex((SkillAttributeItem)InventoryManager.Instance.pickItem.item,selfIdex);
                            //skillTemplate.effectSlots.Add((SkillAttributeItem)InventoryManager.Instance.pickItem.item);
                            
                            currentItemTruly.Exchange(InventoryManager.Instance.pickItem);
                            
                        }
                        
                    }
                    else if(InventoryManager.Instance.pickItem.item is SkillImpactItem)
                    {
                        //如果是影响
                        if (InventoryManager.Instance.pickItem.Amount == 1)
                        {//手上只有一个才能放下，交换
                            //获得信息----强转加入
                            SkillTemplateItem skillTemplate=(SkillTemplateItem) InventoryManager.Instance.skillPanel.skillConfigTitleSlot.itemInSlot.GetComponent<ItemTruly>().item;
                            //skillTemplate.effectSlots.Remove((SkillAttributeItem) currentItemTruly.item);
                            //skillTemplate.effectSlots.Add((SkillImpactItem)InventoryManager.Instance.pickItem.item);
                            skillTemplate.RemoveEffectByIndex(selfIdex);
                            skillTemplate.AddEffectByIndex((SkillImpactItem)InventoryManager.Instance.pickItem.item,selfIdex);
                            
                            
                            
                            currentItemTruly.Exchange(InventoryManager.Instance.pickItem);
                        }
                        
                        
                    }
                    else
                    {
                        Debug.Log("类型不匹配");
                    }
                    
                   
                }
                else
                {//手上没有物体 取出
                    
                    if (Input.GetMouseButton(0))
                    {//左键按下
                        int _Amount = currentItemTruly.Amount;
                        //print("Amount = "+_Amount);
                        SkillTemplateItem skillTemplate=(SkillTemplateItem) InventoryManager.Instance.skillPanel.skillConfigTitleSlot.itemInSlot.GetComponent<ItemTruly>().item;
                        skillTemplate.RemoveEffectByIndex(selfIdex);

                        
                        //skillTemplate.effectSlots.Remove((SkillAttributeItem) currentItemTruly.item);
                        
                        //设置物体
                        InventoryManager.Instance.PickUpItem(currentItemTruly.item,_Amount);
                        currentItemTruly.ReduceAmount(currentItemTruly.Amount);
                    }
                    
                    if (Input.GetMouseButton(1))
                    {//右键按下
                        Debug.Log("右键按下没写");
                    }
                    
                }
                
            }
            else
            {//格子没物体
                print("技能盒子里没有物体");
                if (InventoryManager.Instance.isPicking)
                {//手上有物体
                    if (InventoryManager.Instance.pickItem.item is SkillImpactItem)
                    {//效果
                        //激活并且放下
                        this.SetItem(InventoryManager.Instance.pickItem.item);
                        //获得信息----强转加入
                        SkillTemplateItem skillTemplate=(SkillTemplateItem) InventoryManager.Instance.skillPanel.skillConfigTitleSlot.itemInSlot.GetComponent<ItemTruly>().item;
                        skillTemplate.AddEffectByIndex((SkillImpactItem)InventoryManager.Instance.pickItem.item,selfIdex);
                        
                        InventoryManager.Instance.PickDownItem();
                        
                    }
                    else if(InventoryManager.Instance.pickItem.item is SkillAttributeItem)
                    {//属性
                        //激活并且放下
                        this.SetItem(InventoryManager.Instance.pickItem.item);
                        //获得信息----强转加入
                        SkillTemplateItem skillTemplate=(SkillTemplateItem) InventoryManager.Instance.skillPanel.skillConfigTitleSlot.itemInSlot.GetComponent<ItemTruly>().item;
                        skillTemplate.AddEffectByIndex((SkillAttributeItem)InventoryManager.Instance.pickItem.item,selfIdex);
                        InventoryManager.Instance.PickDownItem();
                    }
                    else
                    {
                        Debug.Log("类型不匹配 请放入技能属性，或者技能效果");
                    }
                    
                    
                }
                
                
            }
            
        }
        
       
    }
}