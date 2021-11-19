using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 角色数据格式
 */
namespace ChessDemo.Character
{
    [Serializable]
    public class CharacterData
    {
        /// <summary>
        /// 角色数据类
        /// 规定和角色相关的变量
        /// 已封装——通过CharacterStatusBase使用
        /// </summary>
        // [Tooltip("动画参数")] 
        // public CharacterAnimationParameter chParams;
      
        [Tooltip("最大生命值")]
        public float maxHp; //生命值
        [Tooltip("当前生命值")]
        public float hp;
        [Tooltip("最大sp值")]
        public float maxSp;//sp
        [Tooltip("当前sp值")]
        public float sp;//sp
        [Tooltip("基础攻击力")]
        public float baseAtk;//攻击力
        [Tooltip("防御力")]
        public float defense;//防御力
        [Tooltip("护盾值")]
        public int shield; //护盾
        [Tooltip("角色费用")]
        public int cost; //费用
        [Tooltip("角色属性")]
        public int attribute; //属性

        [Tooltip("移动类型id")]
        public int moveTypeID;
        [Tooltip("每回合可移动次数")]
        public int turnMobility;//每回合可移动次数
        [Tooltip("角色可见范围")]
        public int sight;//可见范围
        [Tooltip("角色移动力")]
        public int moveRange = 3;//移动力
        public float actTime; //动画时间
        [Tooltip("角色移动速度")]
        public int moveSpeed=5;
       
    }

    
    
}


