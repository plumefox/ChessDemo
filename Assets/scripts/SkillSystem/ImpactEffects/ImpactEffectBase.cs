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
    /// 影响效果接口
    /// </summary>

    public interface ImpactEffectBase
    {
        //执行影响效果
        void Excute(SkillDeployer deployer);

    }

}