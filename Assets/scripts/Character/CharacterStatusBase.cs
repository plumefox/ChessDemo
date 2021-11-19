using System;
using System.Collections;
using System.Collections.Generic;
using ChessDemo.Common;
using UnityEngine;
//作为父类继承用
namespace ChessDemo.Character
{
    /// <summary>
    /// 角色状态基类
    /// 使用时继承该类
    /// </summary>

    public class CharacterStatusBase : MonoBehaviour
    {
        public CharacterAnimationParameter chPrarms;
        //数据封装
        public CharacterData ch;
        
        //计算伤害
        public void Damage(float val)
        {
            //如果存在shield 先扣除shield（不参与防御力减免）
            //扣减生命值前，先根据防御力和属性减免伤害
            if (Shield >=0)
            {
                val -= Shield;
            }
            val -= Defense;

            if (val>0)
            {
                Hp -= val;
            }

            if (Hp <=0)
            {
                Death();
            }
        }

        //死亡
        protected virtual void Death()
        {
            GetComponentInChildren<Animator>().SetBool(chPrarms.die,true);
        }

        protected virtual void Move()
        {
            GetComponentInChildren<Animator>().SetBool(chPrarms.run,true);
        }
        
        protected virtual void Jump()
        {
            //GetComponentInChildren<Animator>().SetBool(chPrarms.jump,true);
            
        }

        public virtual void ShowWalkableTiles()
        {
            
        }

        public virtual void CloseWalkableTiles()
        {
            
        }
        

        #region 基础属性的get和set
            public float BaseAtk
            {
                get
                {
                    return ch.baseAtk;
                }
                set
                {
                    ch.baseAtk = value;
                }
                
            }
            public float Defense
            {
                get
                {
                    return ch.defense;
                }
                set
                {
                    ch.defense = value;
                }
                
            }
            
            public float MaxHp
            {
                get
                {
                    return ch.maxHp;
                }
                set
                {
                    ch.maxHp = value;
                }
                
            }
            public float Hp
            {
                get
                {
                    return ch.hp;
                }
                set
                {
                    ch.hp = value;
                }
                
            }

            public float MaxSp
            {
                get
                {
                    return ch.maxSp;
                }
                set
                {
                    ch.maxSp = value;
                }
            }
            
            public float Sp
            {
                get
                {
                    return ch.sp;
                }
                set
                {
                    ch.sp = value;
                }
            }
            public int Shield
            {
                get
                {
                    return ch.shield;
                }
                set
                {
                    ch.shield = value;
                }
                
            }
            
            public int TurnMobility
            {
                get
                {
                    return ch.turnMobility;
                }
                set
                {
                    ch.turnMobility = value;
                }
                
            }
            
            public int Sight
            {
                get
                {
                    return ch.sight;
                }
                set
                {
                    ch.sight = value;
                }
                
            }
            
            public int Cost
            {
                get
                {
                    return ch.cost;
                }
                set
                {
                    ch.cost = value;
                }
                
            }
            
            public int Attribute
            {
                get
                {
                    return ch.attribute;
                }
                set
                {
                    ch.attribute = value;
                }
                
            }

            public int MoveTypeID
            {
                get
                {
                    return ch.moveTypeID;
                }
                set
                {
                    ch.moveTypeID = value;
                }
            }
            
            public int MoveRange
            {
                get
                {
                    return ch.moveRange;
                }
                set
                {
                    ch.moveRange = value;
                }
            }
            
            public int MoveSpeed
            {
                get
                {
                    return ch.moveSpeed;
                }
                set
                {
                    ch.moveSpeed = value;
                }
            }

        #endregion
        
        
    }
    
}

