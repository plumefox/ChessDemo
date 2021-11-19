using System.Collections;
using System.Collections.Generic;
using ChessDemo.Character;
using UnityEngine;
using Common;

/* 
 * author:
 * createdTime:
 */
namespace ChessDemo.Skill
{
    /// <summary>
    /// 扇形/圆形选区
    /// </summary>

    public class SectorAttackSelector : IAttackSelector
    {
        public Transform[] SelectTarget(SkillData data, Transform skillTF)
        {
            Debug.Log("开始计算选区");
            //string[] data.attackTargetTags
            //获取目标
            List<Transform> targets = new List<Transform>();
            for (int i = 0; i < data.attackTargetTags.Length; i++)
            {
                GameObject[] tempObj = GameObject.FindGameObjectsWithTag(data.attackTargetTags[i]);
                targets.AddRange(tempObj.Select(s => s.transform));
            }
            
            
            //判断攻击范围
            targets = targets.FindAll(t => 
                Vector3.Distance(t.position, skillTF.position) <= data.attackDistance && 
                Vector3.Angle(skillTF.forward,t.position-skillTF.position)<= data.skillAngle/2);
            
            //筛选攻击对象
            targets = targets.FindAll(t => t.GetComponent<CharacterStatusBase>().Hp > 0);

            Transform[] result = targets.ToArray();
            //data.skillAttackType
            if (data.skillAttackType == SkillAttackType.@Group || result.Length == 0)
                return result;
            //单攻
            Transform min = result.GetMin(t => Vector3.Distance(t.position, skillTF.position));
            
            Debug.Log("min = "+min);
            return new Transform[] {min};


            //throw new System.NotImplementedException();
        }
    }

}