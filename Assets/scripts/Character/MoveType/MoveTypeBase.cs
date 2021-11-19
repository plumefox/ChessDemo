using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
 * author:lucy
 * createdTime:2021/2/17
 */
namespace ChessDemo.MoveType 
{
    /// <summary>
    /// movetype 接口
    /// </summary>

    public interface MoveTypeBase
    {
        int id
        {
            get;
            set;
        }

        string name
        {
            get;
            set;
        }

        string description
        {
            get;
            set;
        }
        
        bool CanMove(float x1,float y1,float x2,float y2);
    }

}