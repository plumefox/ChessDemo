using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
 * author:
 * createdTime:
 */
namespace ChessDemo.Skill 
{
    /// <summary>
    /// 技能释放器
    /// 创建与使用分离。需要配合DeployerConfigFactory使用
    /// </summary>

    public abstract class SkillDeployer : MonoBehaviour
    {
        private SkillData skillData;
        private IAttackSelector selector;
        //影响效果数组
        private ImpactEffectBase[] impactArray;
        //由技能管理器提供
        public SkillData SKillData
        {
            get
            {
                return skillData;
            }
            set
            {
                skillData = value;
                //初始化
                InitDeployer();
            }
        }
        //创建算法对象
        private void InitDeployer()
        {
            //选区 有bug
            selector = DeployerConfigFactory.CreateAttackSelector(SKillData);
            Debug.Log("test:selector in SkillDeployer 2 = "+selector);
            //影响
            impactArray = DeployerConfigFactory.CreateImpactEffects(SKillData);

        }

        public void CalculateTargets()
        {
            Debug.Log("calculate Targets");
            skillData.attackTargets = selector.SelectTarget(skillData, transform);
            
        }
        
        public void ImpactTargets()
        {
            for (int i = 0; i < impactArray.Length; i++)
            {
                impactArray[i].Excute(this);
            }
          
        }

        public abstract void DeploySkill();


    }
}