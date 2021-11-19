using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
 * author:
 * createdTime:
 */
namespace ChessDemo.MoveType 
{
    /// <summary>
    /// 
    /// </summary>

    public class MoveType2 : MoveTypeBase
    {
        private int moveId = 2;
        private string moveTypeName ="这是斜着走";
        private string moveTypeDescription ="就是沿着格子斜着走啦";
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