// using System;
// using System.Collections;
// using System.Collections.Generic;
// using ChessDemo.Inventory;
// using ChessDemo.Item;
// using Common;
// using ns;
// using UnityEngine;
// using UnityEngine.UI;
// /* 
//  * author:
//  * createdTime:
//  */
// namespace ChessDemo.Inventory 
// {
//     /// <summary>
//     /// 背包管理器 单例
//     /// 背包管理器维护两个list
//     /// gameobject类型的显示列表和int类型的id，数据来自itemManger
//     /// </summary>
//
//     public class InventoryUIManager : MonoSingleton<InventoryUIManager>
//     {
//         //存游戏物体
//         public List<GameObject> slotList = new List<GameObject>();
//         //存物品的id str
//         public List<string> idList = new List<string>();
//         
//         //public List<int> l = new List<int>();
//         //背包 但是现在不需要，改别的存储 字典
//         public Inventory myBag;
//         //gird
//         public GameObject slotGrid;
//         //slot预制体
//         public GameObject emptySlot;
//         
//         public Text itemInformation;
//         
//         public override void Init()
//         {
//             base.Init();
//             //inventoryManager = new InventoryManager();
//             
//         }
//
//         private void OnEnable()
//         {
//             //读取数据
//             
//             //刷新显示
//             RefreshItem();
//         }
//
//         /*public static void CreateNewItem(Item item)
//         {
//             Debug.Log(InventoryManager.Instance.slotPreb);
//             Debug.Log(InventoryManager.Instance.slotGrid);
//             Slot newItem = Instantiate(InventoryManager.Instance.slotPreb,InventoryManager.Instance.slotGrid.transform.position,Quaternion.identity);
//             newItem.gameObject.transform.SetParent(InventoryManager.Instance.slotGrid.transform);
//             newItem.slotItem = item;
//             print(item.itemImage);
//             newItem.slotImage.sprite = item.itemImage;
//             newItem.slotNum.text = item.itemHeld.ToString();
//         }*/
//
//         public void UpdateItemInfo(string description)
//         {
//             InventoryUIManager.Instance.itemInformation.text = description;
//             
//         }
//
//         public static void RefreshItem()
//         {
//             for (int i = 0; i < InventoryUIManager.Instance.slotGrid.transform.childCount; i++)
//             {
//                 if (InventoryUIManager.Instance.slotGrid.transform.childCount == 0)
//                     break;
//                 Destroy(InventoryUIManager.Instance.slotGrid.transform.GetChild(i).gameObject);
//                 InventoryUIManager.Instance.slotList.Clear();
//             }
//
//             for (int i = 0; i < InventoryUIManager.Instance.myBag.itemList.Count; i++)
//             {
//                 InventoryUIManager.Instance.slotList.Add(Instantiate(InventoryUIManager.Instance.emptySlot));
//                 InventoryUIManager.Instance.slotList[i].transform.SetParent(InventoryUIManager.Instance.slotGrid.transform);
//                 //InventoryManager.Instance.slotList[i].GetComponent<Slot>().SetupSlot(InventoryManager.Instance.myBag.itemList[i]);
//                 InventoryUIManager.Instance.slotList[i].GetComponent<Slot>().SetupSlot(InventoryUIManager.Instance.myBag.itemList[i]);
//                 //CreateNewItem(InventoryManager.Instance.myBag.itemList[i]);
//             }
//         }
//     
//         public static void AddNewItem(Inventory inventory,ItemNNNN thisItem)
//         {
//             //如果不包含或者类型是技能
//             if (!inventory.itemList.Contains(thisItem)
//                 ||thisItem.itemType == ItemType.Equipment)
//             {
//                 //寻找空位加入
//                 if (!FindEmptyToInsert(inventory, thisItem))
//                 {
//                     //失败
//                     Debug.Log("inventory is full");
//                     return;
//                 }
//                 //inventory.itemList.Add(thisItem);
//                 //InventoryManager.CreateNewItem(thisItem);
//             }
//             else 
//             {
//                 
//                 //thisItem.itemHeld += 1;
//             }
//             
//             InventoryUIManager.RefreshItem();
//         }
//
//         //寻找空位并加入
//         private static bool FindEmptyToInsert(Inventory inventory, ItemNNNN thisItem)
//         {
//             for (int i = 0; i < inventory.itemList.Count; i++)
//             {
//                 if (inventory.itemList[i] == null)
//                 {
//                     inventory.itemList[i] = thisItem;
//                     return true;
//                 }
//             }
//
//             return false;
//         }
//         
//        
//     }
// }