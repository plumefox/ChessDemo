using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;

/* 
 * author:
 * createdTime:2021/2/20
 */
namespace ChessDemo.Skill 
{
    /// <summary>
    /// 释放器配置
    /// 创建与使用分离。需要配合SkillDeployer使用
    /// </summary>

    public class DeployerConfigFactory 
    {
        public static IAttackSelector CreateAttackSelector(SkillData data)
        {
            //skillData.skillSelectorType
            //选区对象命名规则 ChessDemo.Skill.SkillType.{0}
            string classNameSelector = string.Format("ChessDemo.Skill.{0}"+"AttackSelector",data.skillSelectorType);
            return CreateObject<IAttackSelector>(classNameSelector);
            
            
        }
        
        public static ImpactEffectBase[] CreateImpactEffects(SkillData data)
        {
            ImpactEffectBase[] imapcts = new ImpactEffectBase[data.skillImpactType.Length];
            //影响效果命名规范：ChessDemo.Skill.ImpactType.{0}
            for (int i = 0; i < data.skillImpactType.Length; i++)
            {
                string classNameImpact = string.Format("ChessDemo.Skill.{0}"+"Impact",data.skillImpactType[i]);

                imapcts[i] = CreateObject<ImpactEffectBase>(classNameImpact);
            }
            return imapcts;
        }
        
        private static T CreateObject<T>(string className)where T:class
        {
            Debug.Log("反射创建对象 "+className);
            Type type = Type.GetType(className);
            //反射创建对象
            return Activator.CreateInstance(type) as T;
        }

    }

}