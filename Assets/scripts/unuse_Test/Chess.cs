using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChessDemo.Character
{
    public class Chess : MonoBehaviour
    {
        private int turnMobility;//每回合可移动次数
        private int sight;//可见范围
        private int moveRange = 3;//移动力
        
        private float damage;//攻击力
        private float defense;//防御力
        private float hp; //生命值
        private int shield; //护盾
        private int cost; //费用
        private int attribute; //属性
        private float actTime; //动画时间
        private int moveSpeed=5;

        public Chess()
        {
            damage = 0;
            
        }

        public Chess(Chess chess)
        {
            Damage = chess.Damage;
            Defense = chess.Defense;
            Hp = chess.Hp;
            Shield = chess.Shield;
            Cost = chess.Cost;
            Attribute = chess.Attribute;
            Sight = chess.Sight;
            TurnMobility = chess.TurnMobility;
            MoveRange = chess.MoveRange;

        }
        private void OnMouseDown()
        {
           // GameManager.GetGM.selectedChess = this;
            //Debug.Log("click me");
            ShowWalkableTiles();
        }

        //move函数用于控制移动
        public void Move(Transform _trans)
        {
            //transform.position = Vector2.MoveTowards(transform.position, new Vector2(_trans.position.x, _trans.position.y),moveSpeed * Time.deltaTime);
            transform.position = _trans.position;//直接在指定位置出现
            ResetTileColor();
        }
        
        void ShowWalkableTiles()
        {
            Tile tile;
            for (int i = 0; i < GameManager.GetGM.Tiles.Count; i++)
            {
                float distX = Mathf.Abs(transform.position.x - GameManager.GetGM.Tiles[i].transform.position.x);
                float distY = Mathf.Abs(transform.position.y - GameManager.GetGM.Tiles[i].transform.position.y);
                //Debug.Log(GameManager.GetGM.Tiles[i].name);

                if (distX + distY <= moveRange)
                {
                    tile = GameManager.GetGM.Tiles[i].GetComponent<Tile>();
                    //Debug.Log(tile.canWalk);
                    
                    if (tile.canWalk)
                    {
                        //Debug.Log("I can walk");
                        tile.HighListTile();
                    }
                    
                }
            }
            
        }

        private void ResetTileColor()
        {
            for (int i = 0; i < GameManager.GetGM.Tiles.Count; i++)
            {
                GameManager.GetGM.Tiles[i].GetComponent<Tile>().ResetTileStatus();
            }
        }

        public float Damage
        {
            get
            {
                return damage;
            }
            set
            {
                damage = value;
            }
            
        }
        
        public float Defense
        {
            get
            {
                return defense;
            }
            set
            {
                defense = value;
            }
            
        }
        
        public float Hp
        {
            get
            {
                return hp;
            }
            set
            {
                hp = value;
            }
            
        }
        
        public int Shield
        {
            get
            {
                return shield;
            }
            set
            {
                shield = value;
            }
            
        }
        
        
        public int TurnMobility
        {
            get
            {
                return turnMobility;
            }
            set
            {
                turnMobility = value;
            }
            
        }
        
        public int Sight
        {
            get
            {
                return sight;
            }
            set
            {
                sight = value;
            }
            
        }
        
        public int Cost
        {
            get
            {
                return cost;
            }
            set
            {
                cost = value;
            }
            
        }
        
        public int Attribute
        {
            get
            {
                return attribute;
            }
            set
            {
                attribute = value;
            }
            
        }

        public int MoveRange
        {
            get
            {
                return moveRange;
            }
            set
            {
                moveRange = value;
            }
        }

        //public float Hp {get => hp; set => hp = value; }

    }

    
}
