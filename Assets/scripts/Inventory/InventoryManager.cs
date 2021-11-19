using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using ChessDemo.Inventory;
using ChessDemo.Item;
using Common;
using UnityEngine;
using LitJson;
using UnityEngine.UI;
using Random = UnityEngine.Random;


/* 
 * author:
 * createdTime:
 */
namespace ChessDemo.Item 
{
    /// <summary>
    /// 背包管理器
    /// </summary>
    public class InventoryManager : MonoSingleton<InventoryManager>
    {
        //存储所有的item
        public List<ItemBase> itemList;
        public InfoList infoList;
        public BagPanel bag;
        public ItemTruly pickItem;
        public bool isPicking;
        public ToolTip toolTip;
        public SkillConfigPanel skillPanel;
        
        public class InfoList
        {
            public List<Consumable> consumableList;
            public List<Equipment> equipmentList;
            public List<EventItem> eventItemList;
            public List<Making> makingList;
            public List<SkillAttributeItem> skillAttributeItemList;
            public List<SkillTemplateItem> skillTemplateItemList;
            public List<SkillImpactItem> skillImpactItemList;
            public InfoList()
            {
                consumableList = new List<Consumable>();
                equipmentList = new List<Equipment>();
                eventItemList = new List<EventItem>();
                makingList = new List<Making>();
                skillAttributeItemList = new List<SkillAttributeItem>();
                skillTemplateItemList = new List<SkillTemplateItem>();
                skillImpactItemList = new List<SkillImpactItem>();
            }
        }


        //解析json 获取数据
        public void ParseJson()
        {
            //string jsonData = File.ReadAllText(Application.dataPath+"/StreamingAssets/" + "/item.json");
            TextAsset ta = Resources.Load<TextAsset>("Item");
            
            JsonReader jsonReader = new JsonReader(ta.text);
            infoList = JsonMapper.ToObject<InfoList>(jsonReader);

            //json获取完数据直接加入
            AddSumList();
        }
        //加入 itemlist
        public void AddSumList()
        {
            if (itemList == null) itemList = new List<ItemBase>();
            if (infoList.consumableList != null)
            {
                foreach (var item in infoList.consumableList)
                {
                    itemList.Add(item);
                }
            }
            if (infoList.equipmentList != null)
            {
                foreach (var item in infoList.equipmentList)
                {
                    itemList.Add(item);
                }
               
            }
            if (infoList.eventItemList != null)
            {
                foreach (var item in infoList.eventItemList)
                {
                    itemList.Add(item);
                }
            }
            if (infoList.makingList != null)
            {
                foreach (var item in infoList.makingList)
                {
                    itemList.Add(item);
                }
            }
            
            if (infoList.skillAttributeItemList != null)
            {
                foreach (var item in infoList.skillAttributeItemList)
                {
                    itemList.Add(item);
                }
            }
            if (infoList.skillImpactItemList != null)
            {
                foreach (var item in infoList.skillImpactItemList)
                {
                    itemList.Add(item);
                }
            }
            //模板
            if (infoList.skillTemplateItemList != null)
            {
                foreach (var item in infoList.skillTemplateItemList)
                {
                    //item.skillData.skillID = 1;
                    itemList.Add(item);
                }
            }
            
            //print(itemList.Count);
        }

        //通过id寻找item
        internal void GetItemById(int id,out ItemBase itemData)
        {
            itemData = null;
            foreach (var item in itemList)
            {
                if (item.itemID == id)
                {
                    itemData = item;
                    //print("2  getItemByid ");
                }
            }

        }

        //放下
        public void PickDownItem(int count = 1)
        {
            pickItem.ReduceAmount(count);
            if (pickItem.Amount <= 0)
            {
                isPicking = false;
                pickItem.gameObject.SetActive(false);
            }
        }

        //拿起的是数据,在鼠标处生成一个和格子内状态一模一样的
        public void PickUpItem(ItemBase item,int amount = 1)
        {
            isPicking = true;
            
            pickItem.SetItem(item,amount);
            pickItem.gameObject.SetActive(true);
            

           
        }

        public void Start()
        {
            ParseJson();
            pickItem = transform.Find("PickItem").GetComponent<ItemTruly>();
            toolTip =FindObjectOfType<ToolTip>();
            
            
        }
        

        //物品描述
        public void UpdateItemInfo(string description)
        {
            bag.transform.Find("ItemDescription").GetComponent<Text>().text = description;
            
        }

        public void testShowList()
        {
            foreach (var item in itemList)
            {
                //print(item.itemID);
            }
        }

        public void ShowToolTip(string content)
        {
            toolTip.Show(content);
        }
        
        public void HideToolTip()
        {
            toolTip.Hide();
        }

        public void OnGUI()
        {
            
            if (GUI.Button(new Rect(200,100,50,50),"testJson"))
            {
                //解析
                bag = GetComponentInChildren<BagPanel>();
                testShowList();
                
                //传送数据
                int v= Random.Range(1, itemList.Count+1);
                //print("1  v  = "+v);
                ItemBase item;
                bag.SetItem(v);
                
            }
        }
    }
}