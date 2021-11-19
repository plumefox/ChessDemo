using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/* 
 * author:
 * createdTime: 2021/2/27
 */
namespace ChessDemo.Item 
{
    /// <summary>
    /// item under slot
    /// 格子中的物品类 操作 显示 自己的图片 数量 和 更新
    /// </summary>

    public class ItemTruly : MonoBehaviour
    {

        public ItemBase item;
        //数量
        private int amount;
        protected Image itemSprite;
        private Text amountText;

        public Sprite testSprite;
        
        public ItemTruly()
        {
            //amount = 1;
            
        }
        

        public int Amount
        {
            get => amount;
            set
            {
                // if (amount == value)
                // {
                //     return;
                // }
                amount = value;
                UpdateText();

            }
        }
        //item 图片
        public Image ItemSprite
        {
            get
            {
                if (itemSprite == null)
                {
                    itemSprite = GetComponentInChildren<Image>();
                }

                return itemSprite;
            }
            //set => itemSprite = value;
        }

        public Text AmountText
        {
            get
            {
                if (amountText == null)
                {
                    amountText = GetComponentInChildren<Text>();
                }

                return amountText;
            }
            //set => amountText = value;
        }

        //更新描述
        public virtual void UpdateText()
        {
            AmountText.text = Amount.ToString();
            if (Amount > 0)
            {
                if (Amount == 1)
                {
                    HideText();
                }
                else
                {
                    ShowText();
                }
            }
            else
            {
                Debug.Log("父为 "+transform.parent.name+"的"+transform.name+" 由于amount = 0 关闭 ");
                Dispose();
            }
        }

        //隐藏text
        public void HideText()
        {
            AmountText.gameObject.SetActive(false);
        }
        //显示text
        public void ShowText()
        {
            AmountText.gameObject.SetActive(true);
        }

        //增加数量
        public bool AddAmount(int count = 1)
        {
            //如果超过容量
            if (Amount+count > item.capacity)
            {
                Debug.Log("单位格子容量已经上限");
                return false;
            }
            Amount += count;
            return true;

        }

        //减少数量
        public void ReduceAmount(int count = 1)
        {
            Amount -= count;
        }

        //物品设置
        public void SetItem(ItemBase itemBase,int count = 1)
        {
            if (item == null)
            {
                item = new ItemBase();
            }
            item = itemBase;
            
            string path = item.iconPath;
            Amount = count;
            SetSprite(path);
            UpdateText();
            

        }
        public void SetSprite(string path)
        {
            ItemSprite.sprite = Resources.Load<Sprite>(path);
        }

        //物品销毁
        public void Dispose()
        {
            //isShowInfo = false;
            //Destroy(this.gameObject);
            gameObject.SetActive(false);
            
        }

        //物品交换
        public virtual void Exchange(ItemTruly itemTruly)
        {
            ItemBase exChangeItem = itemTruly.item;
            int count = itemTruly.amount;
            itemTruly.SetItem(item,amount);
            this.SetItem(exChangeItem,count);
            
        }

        //******test
        public virtual void Start()
        {
            //初始化
            item = new ItemBase();
            ItemSprite.sprite = testSprite;
            amountText = GetComponentInChildren<Text>();
            AmountText.text = "";
            Amount = 1;
            ItemSprite.raycastTarget = false;
            //Debug.Log("初始化");
            Dispose();
            Debug.Log("父为 "+transform.parent.name+"的"+transform.name+" 由于初始化 关闭 ");
        }
        
        

        public void OnGUI()
        {
            if (GUILayout.Button("add amount"))
            {
                AddAmount();
                print(Amount);
            }
            
            if (GUILayout.Button("-- amout"))
            {
                AddAmount(-1);
            }
            
            if (GUILayout.Button("set amount 1"))
            {
                Amount = 1;
            }
        }

        
    }
}