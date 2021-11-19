using System.Collections;
using System.Collections.Generic;
using ChessDemo.Character;
using UnityEditor;
using UnityEngine;

/* 
 * author:
 * createdTime:
 */
namespace ChessDemo.Skill 
{
    /// <summary>
    /// damage
    /// </summary>

    public class DamageImpact : ImpactEffectBase
    {
        private SkillData data;
        public void Excute(SkillDeployer deployer)
        {
            data = deployer.SKillData;
            deployer.StartCoroutine(RepeatDamage(deployer));
        }

        public IEnumerator RepeatDamage(SkillDeployer deployer)
        {
            //计数器
            float count =0;
            do
            {
                OnceDamage();
                yield return new WaitForSeconds(data.skillIntervalTurn);
                count += data.skillIntervalTurn;
                deployer.CalculateTargets();//重新计算范围内敌人

            } while (count < data.skillDurationTime);
            
        }

        //单次伤害
        public void OnceDamage()
        {
            float atk = data.atkRatio * data.owner.GetComponent<ChessStatus>().BaseAtk;
            for (int i = 0; i < data.attackTargets.Length; i++)
            {
                var status = data.attackTargets[i].GetComponent<CharacterStatusBase>();
                status.Damage(atk);
            }
            //创建攻击特效
            
            
        }
        
    }

}