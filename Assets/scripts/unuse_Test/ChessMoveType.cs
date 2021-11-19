using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
 * author:
 * createdTime:
 */
namespace ChessDemo.Common
{
    /// <summary>
    /// 棋子的移动方法，规定如何移动的，然后通过某种方式可以查到对应的移动方法，moveType.id 
    /// MoveType.Find(ch.moveTypeName)
    /// </summary>

    public class ChessMoveType 
    {

        public bool selectMoveType(int id)
        {
            switch (id)
            {
                case 1: return false;
            }

            return false;

        }
        
        
        public bool moveType1(int x1,int y1,int x2,int y2)
        {
            //移动方式1：隔一圈跳
            if (Mathf.Abs(x1 - x2)%2==1 && Mathf.Abs(y1-y2)%2 ==1)
            {
                return true;

            }

            if (Mathf.Abs(x1-x2) == 1 || Mathf.Abs(y1-y2)==1)
            {
                return true;

            }

            return false;

        }

        public bool moveType2(int x1,int y1,int x2,int y2)
        {
            //移动方式2：斜着走
            if (Mathf.Abs(x1 - x2) == Mathf.Abs(y1-y2) )
            {
                return true;

            }
            if (Mathf.Abs(x1-x2) == 1 || Mathf.Abs(y1-y2)==1)
            {
                return true;

            }

            return false;
        }
        
    }

}