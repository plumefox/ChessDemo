using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
 * author:
 * createdTime:
 */
namespace ChessDemo.Inventory 
{
    /// <summary>
    /// 角色的背包
    /// </summary>

    public class BagPanel : Inventory<BagPanel>
    {
        // Start is called before the first frame update
        

        // Update is called once per frame
        void Update()
        {
            
        }
        //******test
        public void OnGUI()
        {
            
            if (GUI.Button(new Rect(100,100,50,50),"获取子物体 主要是active false能不能获取到"))
            {
                print("slost list = "+slotList.Length);
                for (int i = 0; i < slotList.Length; i++)
                {
                    print(slotList[i].name);
                }
                
                Slot a = FindEmptyItem();

                if (a == null)
                {
                    print("找不到空物体");
                    
                }
                else
                {
                    print("找到空物体");
                }
            }

            if (GUI.Button(new Rect(300,100,50,50),"new slot"))
            {
                AddSlot();
            }
            
        
        }
    }
}