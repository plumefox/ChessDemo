using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ChessDemo.Item;
using Common;
using UnityEngine;
using UnityEngine.UI;

/* 
 * author:lucy
 * createdTime:
 */
namespace ChessDemo.Inventory 
{
    /// <summary>
    /// 背包 
    /// </summary>

    //[CreateAssetMenu(fileName = "new Inventory",menuName = "Inventory/New Inventory")]
    //派生类也是单例
    public abstract class Inventory<T> : MonoSingleton<T> where T:MonoSingleton<T>
    {
        //slot的集合
        public Slot[] slotList;
        private CanvasGroup canvasGroup;
        private float tarAlpha = 1;
        public GameObject slotPrefab;
        protected GridLayoutGroup grid;
        private const int fadeSpeed = 2;

        
        public void SetItem(int id)
        {
            ItemBase itemData;
            //通过id获取item
            InventoryManager.Instance.GetItemById(itemData: out itemData,id:id);
            //print("3  setItem ");
            SetItem(itemData);
        }

        public void SetItem(ItemBase item, int amount = 1)
        {
            if (item.capacity != 1)
            {
                //寻找同一个叠加
                //print("4  SetItem2 ");
                Slot slot = FindSameItem(item.itemID);

                if (slot != null)
                {
                    ItemTruly itemTruly = slot.transform.GetChild(0).GetComponent<ItemTruly>();
                    itemTruly.AddAmount();
                    
                }
                else
                {
                    //寻找空格子
                    Slot emptySlot = FindEmptyItem();
                    if (emptySlot!= null)
                    {
                        emptySlot.SetItem(item);
                    }
                    else
                    {
                        Debug.Log("背包满了");
                    }
                    
                }


            }
            else
            {
                //capacity = 1的情况
                //寻找空格子
                Slot emptySlot = FindEmptyItem();
                if (emptySlot!= null)
                {
                    emptySlot.SetItem(item);
                }
                else
                {
                    Debug.Log("背包满了");
                }
                
                
                
            }
            
            
        }

        //寻找id相同的物体
        public Slot FindSameItem(int id)
        {
            foreach (var slot in slotList)
            {
                //如果有item 且id相同
                if (slot.transform.GetChild(0).gameObject.activeInHierarchy)
                {
                    ItemTruly itemTruly =  slot.transform.GetChild(0).GetComponent<ItemTruly>();
                    if (itemTruly.item.itemID == id && itemTruly.Amount < itemTruly.item.capacity)
                    {
                        //print("5  FindSameItem ");
                        return slot;
                    }
                }
                
            }

            return null;
        }

        //寻找空物体
        public Slot FindEmptyItem()
        {
            foreach (var slot in slotList)
            {
                if (!slot.transform.GetChild(0).gameObject.activeInHierarchy)
                {
                    return slot;
                }
            }

            return null;
        }

        //增加格子
        public virtual void AddSlot(int count = 1)
        {
            
            //1 实例化
            for (int i = 0; i < count; i++)
            {
                GameObject obj = Instantiate(slotPrefab, transform.position, transform.rotation);
                //2 设置paraent 为content
                obj.transform.SetParent(grid.transform);
            }

            RefreshItem();

        }

        //删除指定的格子
        public virtual void RemoveSlot(int index)
        {
            int length = slotList.Length;
            if (index >= length)
            {
                return;
            }
            Destroy(slotList[index]);
            RefreshItem();

        }

        //删除所有的格子
        public virtual void RemoveAllSlots()
        {
            Debug.Log("slot length  = "+slotList.Length);
            for (int i = 1; i < slotList.Length; i++)
            {
                Destroy(slotList[i].gameObject);
            }
            RefreshItem();
        }

        public void RefreshItem()
        {
            slotList = GetComponentsInChildren<Slot>();
        }

        protected virtual void Start()
        {
            //slotList = GetComponentsInChildren<Slot>();
            RefreshItem();
            canvasGroup = GetComponentInChildren<CanvasGroup>();
            grid = GetComponentInChildren<GridLayoutGroup>();
            // print("canvas"+canvasGroup.name);
            // print("slot:"+slotList.Length);
            // print("grid"+grid.name);
        }

        private void Update()
        {
            //渐变
            if (canvasGroup.alpha != tarAlpha)
            {
               canvasGroup.alpha = Mathf.Lerp(canvasGroup.alpha, tarAlpha, Time.deltaTime * fadeSpeed);
               if (Mathf.Abs(canvasGroup.alpha - tarAlpha)< 0.05f)
               {
                   canvasGroup.alpha = tarAlpha;
                   canvasGroup.blocksRaycasts = canvasGroup.alpha == 0 ? false : true;
               }
            }
        }

        public void Show()
        {
            tarAlpha = 1;
        }

        public void Hide()
        {
            tarAlpha = 0;
        }
        
        
       
    }
    
   
}