using System.Collections;
using System.Collections.Generic;
using ChessDemo.Character;
using UnityEngine;

/* 
 * author:
 * createdTime:
 */
namespace ChessDemo.Skill 
{
    /// <summary>
    /// 消耗sp
    /// </summary>

    public class CostSpImpact : ImpactEffectBase
    {
        public void Excute(SkillDeployer deployer)
        {
            var status = deployer.SKillData.owner.GetComponent<CharacterStatusBase>();
            status.Sp -= deployer.SKillData.skillCost;

        }
    }

}