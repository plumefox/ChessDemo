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
    /// 攻击选区的接口
    /// </summary>

    public interface IAttackSelector
    {
        //搜索目标 skillTF 技能所在物体的变换组件
        Transform[] SelectTarget(SkillData data,Transform skillTF);
        
        
        

    }
}