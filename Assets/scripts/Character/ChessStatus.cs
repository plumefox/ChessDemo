using System;
using System.Collections;
using System.Collections.Generic;
using ChessDemo.MoveType;
using UnityEngine;

/* 
 * author:
 * createdTime:
 */
namespace ChessDemo.Character 
{
    /// <summary>
    /// 棋子状态类
    /// </summary>

    public class ChessStatus : CharacterStatusBase
    {
        private void Start()
        {
            //Death();
            Jump();
        }

        protected override void Death()
        {
            base.Death();
        }

        protected override void Move()
        {
            base.Move();
        }

        protected override void Jump()
        {
            base.Jump();
        }
        
        public override void ShowWalkableTiles()
        {
            Tile tile;
            //获得移动类型id
            //int moveTypeID = GetComponent<CharacterStatusBase>().MoveTypeID;
            int moveRange = base.MoveRange;
            MoveTypeManager moveType = GetComponent<MoveTypeManager>();
            moveType.MoveTypeId = base.MoveTypeID;
            
            for (int i = 0; i < GameManager.GetGM.Tiles.Count; i++)
            {
                float targetX = GameManager.GetGM.Tiles[i].transform.position.x;
                float targetY = GameManager.GetGM.Tiles[i].transform.position.y;
                
                float distX = Mathf.Abs(transform.position.x - targetX);
                float distY = Mathf.Abs(transform.position.y - targetY);
                
                //满足1移动类型 2移动力
                 if (moveType.CanMove(transform.position.x, transform.position.y, targetX, targetY)
                     && distX <= moveRange && distY <= moveRange)
                 {
                     tile = GameManager.GetGM.Tiles[i].GetComponent<Tile>();
                     if (tile.canWalk)
                     {
                         //Debug.Log("I can walk");
                         tile.HighListTile();
                     }
                     
                     
                 }
            }
            
        }
        
        //关闭自身移动范围
        public override void CloseWalkableTiles()
        {
            for (int i = 0; i < GameManager.GetGM.Tiles.Count; i++)
            {
                GameManager.GetGM.Tiles[i].GetComponent<Tile>().ResetTileStatus();
            }
        }
    }
}