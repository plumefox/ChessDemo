using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using Common;

/* 
 * author:
 * createdTime:
 */
namespace ChessDemo.Skill 
{
    /// <summary>
    /// 
    /// </summary>

    public class CharacterSkillSystem: MonoBehaviour
    {
        private CharacterSkillManager skillManager;
        private Animator anim;

        private void Start()
        {
            skillManager = GetComponent<CharacterSkillManager>();
            anim = GetComponentInChildren<Animator>();
        }
        
        public void AttackUseSkill(int skillId)
        {
            //准备技能
            SkillData skill = skillManager.PrepareSkill(skillId);
            if (skill == null) return;
            anim.SetBool(skill.skillAnimationName,true);
            
        }

        //使用随机技能
        public void UseRandomSkill()
        {
            var usableSkills = skillManager.skills.FindAll(s=>skillManager.PrepareSkill(s.skillID)!=null);
            if (usableSkills.Length == 0) return;
            int index = Random.Range(0, usableSkills.Length);
            AttackUseSkill(usableSkills[index].skillID);

        }
    }

}