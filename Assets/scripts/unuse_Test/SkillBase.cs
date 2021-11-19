using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

/*
 * 这个类是技能基类[SKILL BASE]
 * 后续技能实现 继承该基类
 * 该类规定了 技能的基本属性，计算伤害，计算克制关系等，技能特效一切通用函数
 */
/*
 *
 *废弃ing
 *
 * 
 */
public class SkillBase : MonoBehaviour
{
    // SKILL BASE CLASS
    private int _skill_Type;//技能类型
    private string _skill_Name;//技能名
    private string _skill_Description;//技能描述
    private int _skill_Attribute;//技能属性
    private float _skill_Damage;//技能伤害
    private float _skill_ConatinousDamage;//技能持续伤害
    private float _skill_ConatinousTurn;//持续回合
    private bool _skill_Status; //技能状态 on/off
    private float _skill_SuccessRate;//技能成功率
    private int _skill_BuffType;//buff类型 
    private int _skill_Level;//技能等级
    private int _skill_MaxTargetCount;//技能最大作用个数
    private int _skill_MinTargetCount;//技能最小作用个数
    private int _skill_MaxAttackRange;//技能最大范围
    private int _skill_MinAttackRange;//技能最小范围

    public SkillBase()
    {
        
    }

    //计算直接伤害
    public float Damage(float damageValue,float defenseValue=0,float shieldValue=0)
    {
        float result = damageValue - defenseValue -shieldValue;
        
        return result;
    }
    
    //生克系统 克制关系 1->2->3->4->5->1 6->7 7->6 互相克制还没有做
    public float GenerationRestriction(int attributeFrom,int attributeTarget)
    {
        float rate = 1;

        switch (attributeFrom - attributeTarget)
        {
            case -1 : rate = 1.5f; //克制
                break;
            case 1 : rate = 0.5f; //被克制
                break;
            default: break;
        }

        return rate;
    }

    //技能特效
    public void SkillAnimation()
    {
        //1 开始
        //2 结束
 
    }

    //技能音效
    public void SkillSound()
    {
        
    }

    public void SkillBuff()
    {
        
    }

    
    public int SkillType
    {
        get => _skill_Type;
        set => _skill_Type = value;
    }

    public string SkillName
    {
        get => _skill_Name;
        set => _skill_Name = value;
    }

    public string SkillDescription
    {
        get => _skill_Description;
        set => _skill_Description = value;
    }

    public int SkillAttribute
    {
        get => _skill_Attribute;
        set => _skill_Attribute = value;
    }

    public float SkillDamage
    {
        get => _skill_Damage;
        set => _skill_Damage = value;
    }

    public float SkillConatinousDamage
    {
        get => _skill_ConatinousDamage;
        set => _skill_ConatinousDamage = value;
    }

    public float SkillConatinousTurn
    {
        get => _skill_ConatinousTurn;
        set => _skill_ConatinousTurn = value;
    }

    public float SkillSuccessRate
    {
        get => _skill_SuccessRate;
        set => _skill_SuccessRate = value;
    }

    public int SkillBuffType
    {
        get => _skill_BuffType;
        set => _skill_BuffType = value;
    }

    public int SkillLevel
    {
        get => _skill_Level;
        set => _skill_Level = value;
    }

    public int SkillMaxTargetCount
    {
        get => _skill_MaxTargetCount;
        set => _skill_MaxTargetCount = value;
    }

    public int SkillMinTargetCount
    {
        get => _skill_MinTargetCount;
        set => _skill_MinTargetCount = value;
    }

    public int SkillMaxAttackRange
    {
        get => _skill_MaxAttackRange;
        set => _skill_MaxAttackRange = value;
    }

    public int SkillMinAttackRange
    {
        get => _skill_MinAttackRange;
        set => _skill_MinAttackRange = value;
    }
}
