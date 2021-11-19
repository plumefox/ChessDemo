using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ChessDemo.Skill
{
    /// <summary>
    /// 技能数据类
    /// 规定和技能相关的变量
    /// </summary>
    [Serializable] 
    public class SkillData
    {
        /// <summary>技能ID</summary>
        public int skillID;
        /// <summary>技能类型</summary>
        public int skillType;
        /// <summary>技能名称</summary>
        public string skillName;
        /// <summary>技能描述</summary>
        public string skillDescription;
        /// <summary>技能属性</summary>
        public int skillAttribute;
        /// <summary>技能冷却时间-回合</summary>
        public int skillCoolTime;
        /// <summary>技能冷却剩余时间-回合</summary>
        public int skillCoolRemain;
        /// <summary>技能持续回合</summary>
        public float skillDurationTime;
        /// <summary>技能伤害间隔</summary>
        public float skillIntervalTurn;
        /// <summary>技能成功率</summary>
        public float skillSuccessRate;
        /// <summary>技能消耗</summary>
        public int skillCost;
        /// <summary>攻击距离</summary>
        public float attackDistance;
        /// <summary>连击的下一个技能</summary>
        public int nextBatterID;
        /// <summary>攻击比率</summary>
        public float atkRatio;
        /// <summary>攻击目标tags</summary>
        public string[] attackTargetTags = {"Enemy"};
        /// <summary>攻击目标对象数组/summary>
        [HideInInspector] 
        public Transform[] attackTargets;
      
        /// <summary>技能影响</summary>
        public string[] skillImpactType = {"Cost", "Damage"};
        /// <summary>技能所属</summary>
        public GameObject owner;
        /// <summary>技能预制件名称</summary>
        public string skillPrefabName;
        /// <summary>预制件对象</summary>
        [HideInInspector] 
        public GameObject skillPrefab;
        /// <summary>动画名称</summary>
        public string skillAnimationName;
        /// <summary>受击特效名称</summary>
        public string hitFxName;
        /// <summary>受击特效预制件</summary>
        [HideInInspector]
        public GameObject hitFxPreFab;
        /// <summary>技能等级</summary>
        public int skillLevel;
        /// <summary>技能攻击类型 单攻 , 群攻</summary>
        public SkillAttackType skillAttackType;
        /// <summary>技能选择类型 长方形 圆形 十字</summary>
        public SkillSelectorType skillSelectorType;

        public int skillAngle;


    }

}
