using System.Collections;
using System.Collections.Generic;
using ChessDemo.Inventory;
using ChessDemo.Item;
using UnityEngine;
using UnityEngine.EventSystems;

/* 
 * author:
 * createdTime:
 */
namespace ChessDemo.Inventory 
{
    /// <summary>
    /// 技能配置标题slot
    /// </summary>

    public class SkillConfigTitleSlot : Slot
    {
        //技能容量
        public int skillcapacity;

        //重写移入事件
        public override void OnPointerDown(PointerEventData eventData)
        {
            //判断移入的是不是模板 如果不是拒绝
            //移入模板以后 增加下方的格子数量 = 模板容量
            
            ItemTruly currentItemTruly = itemInSlot.GetComponent<ItemTruly>();
            if (itemInSlot.activeInHierarchy)
            {//格子有物体
                if (InventoryManager.Instance.isPicking)
                {//手上有物体
                    if (InventoryManager.Instance.pickItem.item is SkillTemplateItem)
                    {//类型符合
                        currentItemTruly.Exchange(InventoryManager.Instance.pickItem);
                    }
                    else
                    {
                        Debug.Log("类型不匹配");
                    }
                    
                    
                }
                else
                {//手上无
                    //鼠标右键按下
                    if (Input.GetMouseButton(1))
                    {
                        //寻找背包有没有空位
                        //如果有就放下
                        Slot emptySlot = InventoryManager.Instance.bag.FindEmptyItem();
                        if (emptySlot != null)
                        {
                            Debug.Log("背包有空位");
                            int _Amount = currentItemTruly.Amount;
                            emptySlot.SetItem(currentItemTruly.item);
                            currentItemTruly.ReduceAmount(currentItemTruly.Amount);
                            
                        }
                        else
                        {
                            Debug.Log("背包已满");
                        }
                    }

                    //鼠标左键按下
                    if (Input.GetMouseButton(0))
                    {
                        int _Amount = currentItemTruly.Amount;
                        //设置物体
                        InventoryManager.Instance.PickUpItem(currentItemTruly.item,_Amount);
                        currentItemTruly.ReduceAmount(currentItemTruly.Amount);
                        InventoryManager.Instance.skillPanel.RemoveAllSlots();
                        
                        
                    }
                    

                   
                    
                    
                    
                }
                
                
            }
            else
            {//格子没物体
                if (InventoryManager.Instance.isPicking)
                {
                    //手上有物体
                    if (InventoryManager.Instance.pickItem.item is SkillTemplateItem)
                    { //类型符合
                        //强转
                        SkillTemplateItem tmpTemplate = (SkillTemplateItem)InventoryManager.Instance.pickItem.item;
                        this.SetItem(InventoryManager.Instance.pickItem.item);
                        //增加技能容量的slot
                        
                        //print("技能容量 =" + tmpTemplate.skillCapacity);
                        InventoryManager.Instance.skillPanel.AddSlot(tmpTemplate.skillCapacity);
                        InventoryManager.Instance.PickDownItem();
                        
                    }
                }


               

            }
            
            
            
            
            
            
            
            
            
            
            
            
            
            

            
            
            
            
        }

        
    }

}