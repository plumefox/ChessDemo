using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
 * author:
 * createdTime:2021/2/17
 */
namespace ChessDemo.MoveType 
{
    /// <summary>
    /// movetype1
    /// </summary>

    public class MoveType1:MoveTypeBase
    {
        private int moveId = 1;
        private string moveTypeName ="跳格子的移动方式";
        private string moveTypeDescription ="对的，这就是个普普通通跳格子的移动方式";
        public int id
        {
            get
            {
                return moveId;
            }
            set
            {
                id = value;
            }
        }
        public string name
        {
            get
            {
                return moveTypeName;
            }
            set
            {
                name = value;
            }
        }
        public string description {
            get
            {
                return moveTypeDescription;
            }
            set
            {
                description = value;
            }
        }
    
        public bool CanMove(float x1, float y1, float x2, float y2)
        {
            //移动方式1：隔一圈跳
            if (Mathf.Abs(x1 - x2)%2==1 || Mathf.Abs(y1-y2)%2 ==1)
            {
                return true;
            }

            if (Mathf.Abs(x1-x2) == 1 || Mathf.Abs(y1-y2)==1)
            {
                return true;
            }
            return false;
            //throw new System.NotImplementedException();
        }
    }

}