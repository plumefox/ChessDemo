using System;
using System.Collections;
using System.Collections.Generic;
using ChessDemo.Inventory;
using ChessDemo.Skill;
using UnityEngine;

/* 
 * author:
 * createdTime:
 */
namespace ChessDemo.Item 
{
    /// <summary>
    /// 物品基类
    /// </summary>

    //[Serializable]
    public class ItemBase 
    {
        //物品id 主键
        public int itemID;
        //第几个该类型的物品
        public int number;
        //物品类型
        public ItemType itemType;
        //物品名
        public string itemName;
        //物品图片
        public string iconPath;

        public int capacity;
        //物品信息
        public string itemInfo;
        //物品价格
        public int buyPrice;
        public int salePrice;
        public Quaility quailityType;

        public virtual string GetTextContent()
        {
            string text = null;
            text = string.Format("Name: {0}\nID: {1}\nIconPath: {2}\n物品类型: {3}\n容量: {4}\n描述: {5}\n\n购买价格: {6}\n出售价格: {7}\n品质: {8} \n",
                itemName,itemID,iconPath,itemType.ToString(),capacity,itemInfo,buyPrice,salePrice,quailityType.ToString());

            return text;
        }

        public string itemTypeStr
        {
            set
            {
                itemType = (ItemType) System.Enum.Parse(typeof(ItemType), value);
            }
        }
        public string quailityTypeStr
        {
            set
            {
                quailityType = (Quaility) System.Enum.Parse(typeof(Quaility), value);
            }
        }
        
        
    }
           
    public enum ItemType 
    {
        Equipment,//装备
        Consumable,//消耗品
        EventItem,//事件
        Making
    }

    public enum Quaility
    {
        Common,
        Uncommon
    }

}