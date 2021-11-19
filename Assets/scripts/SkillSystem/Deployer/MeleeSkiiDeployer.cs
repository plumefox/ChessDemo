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
    /// 近身释放器
    /// </summary>

    public class MeleeSkiiDeployer : SkillDeployer
    {
        
        public override void DeploySkill()
        {
            transform.SetParent(SKillData.owner.transform);
            Debug.Log("近身释放 选区算法执行");
            //执行选区算法
            CalculateTargets();
            
            //执行影响算法
            ImpactTargets();
        }
    }
}