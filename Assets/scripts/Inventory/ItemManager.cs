using System.Collections;
using System.Collections.Generic;
using ChessDemo.Inventory;
using ChessDemo.Item;
using ChessDemo.Skill;
using Common;
using UnityEngine;

/* 
 * author:
 * createdTime:
 */
// namespace ns 
// {
//     /// <summary>
//     /// 物品管理器
//     /// </summary>
//
//     public class ItemManager : MonoSingleton<ItemManager>
//     {
//
//         //字典嵌套
//         public Dictionary<string, object> dic;
//         //存储 skillitem的dic key = item.id
//         public Dictionary<string, List<SkillItem>> skillItemDic;
//         //public Dictionary<string, SkillData[]> sItemDictst;
//         public List<SkillItem> skillItemList = new List<SkillItem>();
//         
//         public override void Init()
//         {
//             base.Init();
//             dic = new Dictionary<string, object>();
//             skillItemDic = new Dictionary<string, List<SkillItem>>();
//             
//             dic.Add("skill",skillItemDic);
//             skillItemDic.Add("1",skillItemList);
//         }
//
//         public void AddItem()
//         {
//             string itemTypekey = "";
//             string itemIdkey = "";
//
//             if (dic.ContainsKey(itemTypekey))
//             {
//                 var itemDic = dic[itemTypekey];
//                 
//             }
//
//         }
//
//         //为指定物品增加物品效果
//         public void AddImpactEffect(Item item,ImpactEffectBase impact)
//         {
//             item.impactList.Add(impact);
//         }
//         
//         //删除效果
//         public void RemoveImpactEffect(Item item,ImpactEffectBase impact)
//         {
//             item.impactList.Remove(impact);
//         }
//         
//     }
// }