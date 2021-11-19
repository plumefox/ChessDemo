using System;
using System.Collections;
using System.Collections.Generic;
using ChessDemo.Character;
using ChessDemo.Skill;
using UnityEngine;

/* 
 * author:
 * createdTime:
 */
namespace ns 
{
    /// <summary>
    /// 
    /// </summary>

    public class TestFindEnemy : MonoBehaviour
    {
        /*
         * test
         * 测试技能索敌 技能反射
         *
         * 1 单攻技能 扇形和圆形
         * 2 群攻技能
         */
        // Start is called before the first frame update

        private CharacterSkillManager manager;
        //private SkillDeployer Deployer;
        
        public void OnGUI()
        {
            manager = GetComponent<ChessDemo.Skill.CharacterSkillManager>();
            if (GUILayout.Button("群攻"))
            {
                
                SkillData data = manager.PrepareSkill(1001);
                if (data != null)
                {
                    //Debug.Log("test：skilldata data id= "+data.skillID);
                    manager.GenerateSkill(data);
                }
                
            }

            if (GUILayout.Button("单攻"))
            {
                SkillData data = manager.PrepareSkill(1002);
                if (data != null)
                {
                    //Debug.Log("test：skilldata data id= "+data.skillID);
                    manager.GenerateSkill(data);
                }
            }
        }
    }
}