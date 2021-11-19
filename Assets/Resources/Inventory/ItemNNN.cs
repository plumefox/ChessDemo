using System.Collections;
using System.Collections.Generic;
using ChessDemo.Common;
using ChessDemo.Item;
using ChessDemo.Skill;
using UnityEngine;

/* 
 * author:
 * createdTime:
 */
namespace ChessDemo.Inventory 
{
    /// <summary>
    /// 物品类
    /// </summary>

    [CreateAssetMenu(fileName = "New Item",menuName = "Inventory/New Item")]
    public class ItemNNNN : ScriptableObject
    {
        //物品id 主键
        public int itemID;
        //物品类型
        //public BagClassification itemType;
        //物品名
        public string itemName;
        public Sprite itemImage;
        [TextArea]
        public string itemInfo;
        public int itemHeld;
        //影响效果列表
        public List<ImpactEffectBase> impactList;
        public ItemType itemType;

    }
    
    
}