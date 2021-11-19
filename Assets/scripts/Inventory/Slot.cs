using System;
using System.Collections;
using System.Collections.Generic;
using ChessDemo.Inventory;
using ChessDemo.Item;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/* 
 * author:
 * createdTime:
 */
namespace ChessDemo.Inventory 
{
    /// <summary>
    /// 格子信息
    /// 层级结构
    /// slot
    ///  ----item --Image
    ///           --Number
    /// </summary>

    public class Slot : MonoBehaviour,IPointerDownHandler,IPointerEnterHandler,IPointerExitHandler
    {
       
        //按钮
        public Button btn;

        //public GameObject itemPrefab;
        //格子里的物品
        public GameObject itemInSlot;
        
        private bool isShowInfo;

        public void SetItem(ItemBase item,int amount =1)
        {
            //获取物体，active or disable
            itemInSlot = transform.Find("item").gameObject;
            itemInSlot.SetActive(true);
            itemInSlot.GetComponent<ItemTruly>().SetItem(item,amount);
            
        }

        //public virtual void SetItem(ItemBase item) {}


        //显示物品信息
        public void ItemOnclicked()
        {
            if (itemInSlot != null)
            {
                string info = itemInSlot.GetComponent<ItemTruly>().item.itemInfo;
                InventoryManager.Instance.UpdateItemInfo(info);
                
            }
        }

        public void Awake()
        {
            btn = GetComponentInChildren<Button>();
            //itemInSlot = transform.GetChild()
            
        }
        public void OnEnable()
        {
            btn.onClick.AddListener(ItemOnclicked); 
        }
        
        public void OnPointerEnter(PointerEventData eventData)
        {
            //print("in");
            //isShowInfo = true;
            string content =null;
            if (itemInSlot.activeInHierarchy)
            {
                content = itemInSlot.GetComponent<ItemTruly>().item.GetTextContent();
                InventoryManager.Instance.ShowToolTip(content);
            }
            
            
            
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            //print("out");
            //isShowInfo = false;
            InventoryManager.Instance.HideToolTip();
        }

        

        public virtual void OnPointerDown(PointerEventData eventData)
        {
            if (itemInSlot.activeInHierarchy)
            {
                //格子里有物体
                ItemTruly currentItemTruly = itemInSlot.GetComponent<ItemTruly>();
                
                if (InventoryManager.Instance.isPicking)
                {
                    //手上有物体 -- 交换
                    if (currentItemTruly.item.itemID == InventoryManager.Instance.pickItem.item.itemID)
                    {//id相同 累加
                        
                        if (Input.GetKey(KeyCode.LeftControl))
                        {
                            //按下ctrl 一个一个放下去
                            if (currentItemTruly.item.capacity - currentItemTruly.Amount > 0)
                            {
                                currentItemTruly.AddAmount(); 
                                InventoryManager.Instance.PickDownItem();
                            }
                            
                        }
                        else if (currentItemTruly.Amount + InventoryManager.Instance.pickItem.Amount > currentItemTruly.item.capacity)
                        {//加进去会超过上限 ==》不可能全部放下
                            int remainCapacity = currentItemTruly.item.capacity - currentItemTruly.Amount;
                            if (remainCapacity > 0)
                            {
                                //InventoryManager.Instance.pickItem.Amount
                                //有剩余容量 
                                currentItemTruly.AddAmount(remainCapacity); 
                                InventoryManager.Instance.PickDownItem(remainCapacity);
                            }
                            else
                            {//装不下啦
                                return;
                            }
                        }
                        else
                        {//没有超过上限
                            currentItemTruly.AddAmount(InventoryManager.Instance.pickItem.Amount);
                            InventoryManager.Instance.PickDownItem(InventoryManager.Instance.pickItem.Amount);
                        }
                        
                    }
                    else
                    {
                        //id不同 交换
                        currentItemTruly.Exchange(InventoryManager.Instance.pickItem);
                    }
                    
                }
                else
                {
                    //手上没有物品,把当前物品的数据拿出来
                    ItemBase item = currentItemTruly.item;
                    if (Input.GetKey(KeyCode.LeftControl))
                    {
                        //取出一半
                        int _Amount = (currentItemTruly.Amount+1) /2;
                        InventoryManager.Instance.PickUpItem(item,_Amount);
                        currentItemTruly.ReduceAmount(_Amount);
                       
                    }
                    else
                    {
                        //全部取出来
                        int _Amount = currentItemTruly.Amount;
                        //设置物体
                        InventoryManager.Instance.PickUpItem(item,_Amount);
                        currentItemTruly.ReduceAmount(currentItemTruly.Amount);
                    }
                }
                
                //手上无物体 拿起
                
            }
            else
            {
                //格子里没有物体,但是手上有
                if (InventoryManager.Instance.isPicking)
                {
                    if (Input.GetKey(KeyCode.LeftControl))
                    {
                        //激活并且放下
                        this.SetItem(InventoryManager.Instance.pickItem.item);
                        InventoryManager.Instance.PickDownItem();
                    }
                    else
                    {
                        this.SetItem(InventoryManager.Instance.pickItem.item,InventoryManager.Instance.pickItem.Amount);
                        InventoryManager.Instance.PickDownItem(InventoryManager.Instance.pickItem.Amount);
                    }
                   
                   
                    // itemInSlot.GetComponent<ItemTruly>().SetItem(InventoryManager.Instance.pickItem.item,InventoryManager.Instance.pickItem.Amount);
                    
                }
               

            }

        }
        
        
        public void OnGUI()
        {
            float Offset = 20;
            float offy = 15;
            GUIStyle _gui = new GUIStyle();
            _gui.normal.textColor = Color.red;
            ItemBase item = itemInSlot.GetComponent<ItemTruly>().item;
            if (isShowInfo && itemInSlot.activeInHierarchy)
            {
                //名字
                GUI.Label(new Rect(Input.mousePosition.x+ Offset,Screen.height - Input.mousePosition.y,100,100),"Name :"+item.itemName,_gui);
                //id
                GUI.Label(new Rect(Input.mousePosition.x+ Offset,Screen.height - Input.mousePosition.y+offy,100,100),"ID :"+item.itemID.ToString(),_gui);
                GUI.Label(new Rect(Input.mousePosition.x+ Offset,Screen.height - Input.mousePosition.y+offy*2,100,100),"Icon :"+item.iconPath,_gui);
                GUI.Label(new Rect(Input.mousePosition.x+ Offset,Screen.height - Input.mousePosition.y+offy*3,200,100),"容量 :"+item.capacity.ToString(),_gui);
                GUI.Label(new Rect(Input.mousePosition.x+ Offset,Screen.height - Input.mousePosition.y+offy*4,100,100),"买入价 :"+item.buyPrice.ToString(),_gui);
                GUI.Label(new Rect(Input.mousePosition.x+ Offset,Screen.height - Input.mousePosition.y+offy*5,100,100),"卖出价 :"+item.salePrice.ToString(),_gui);
                GUI.Label(new Rect(Input.mousePosition.x+ Offset,Screen.height - Input.mousePosition.y+offy*6,100,100),"品质 :"+item.quailityType,_gui);
                
            }
         
        }
    }
    
}