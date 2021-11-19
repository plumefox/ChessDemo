using System;
using System.Collections;
using System.Collections.Generic;
using ChessDemo.Character;
using Common;
using UnityEngine;

namespace ChessDemo.Skill
{
    /// <summary>
    /// 技能管理器
    /// </summary>
    
    public class CharacterSkillManager : MonoBehaviour
    {
        //技能列表
        public SkillData[] skills;
        private void Start()
        {
            for (int i = 0; i < skills.Length; i++)
            {
                InitSkill(skills[i]);
            }
            Debug.Log("skills[] 初始化ok 总共"+skills.Length+"条记录");
        }

        //初始化技能
        private void InitSkill(SkillData data)
        {
            //根据名字寻找预制件
            data.skillPrefab = ResourceManager.Load<GameObject>(data.skillPrefabName);
            data.owner = gameObject;

        }
        
        //技能释放条件：冷却 法力。。
        public SkillData PrepareSkill(int id)
        {
            //id -> 查找技能数据
            //skills.Find
            SkillData data = skills.Find(s => s.skillID == id);
            //获取当前角色sp
            //float sp = GetComponent<CharacterStatus>().;
            //判断条件 返回技能数据
            if (data != null && data.skillCoolRemain <=0 && 
                data.skillCost <= data.owner.GetComponent<CharacterStatusBase>().Sp)
            {
                Debug.Log("find the message");
                return data;
            }
            else
            {
                Debug.Log("Can not find ");
                return null;
            }
 
        }
        
        
        //生成技能
        public void GenerateSkill(SkillData data)
        {
            //创建技能预制件
            //GameObject thisSkill = Instantiate(data.skillPrefab, transform.position, transform.rotation);
            GameObject thisSkill =
                GameObjectPool.Instance.CreateObject(data.skillPrefabName, data.skillPrefab, transform.position,
                    transform.rotation);
            //传递技能数据
            SkillDeployer deployer = thisSkill.GetComponent<SkillDeployer>();
           
            deployer.SKillData = data;
            Debug.Log("test:deployer skill data id = "+deployer.SKillData.skillID);

            //执行技能
            deployer.DeploySkill();
            //销毁技能
            //Destroy(thisSkill,data.skillDurationTime);
            GameObjectPool.Instance.CollectObject(thisSkill,data.skillDurationTime);
            
            //开启技能冷却 1回合-1
            StartCoroutine(CoolTimeDown(data));
            

        }

        //组合技能
        public void ComposeSkill(SkillData data)
        {
            int index = 0;
            int maxLength = 3;
            //把技能和一些效果进行自己组合
            //1 长度
            //2 影响
            int length = data.skillImpactType.Length;
            if (length>maxLength)
            {
                return;
            }

            //对应位置拖拽赋值
            data.skillImpactType[index] = "test";
        }


        //技能冷却
        private IEnumerator CoolTimeDown(SkillData data)
        {
            //data.coolTime -> coolRemain
            data.skillCoolRemain = data.skillCoolTime;
            while (data.skillCoolRemain > 0)
            {
                yield return new WaitForSeconds(1);
                data.skillCoolRemain--;
            }

            

        }
    }

}

