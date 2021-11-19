using System;
using System.Collections;
using System.Collections.Generic;
using ChessDemo.MoveType;
using ChessDemo.Skill;
using ChessDemo.UI;
using ns;
using UnityEngine;
using UnityEngine.UI;

/* 
 * author:
 * createdTime:
 */
namespace ChessDemo.Character 
{
    /// <summary>
    /// 角色输入控制器
    /// </summary>
    [RequireComponent(typeof(CharacterMoter),typeof(ChessStatus))]
    public class CharacterInputController : MonoBehaviour
    {
        private CharacterMoter characterMoter;
        private Animator animator;
        private CharacterStatusBase status;
        public GameObject myBag;
        private bool isOpenBag;
        public GameObject skillConfig;
        private bool isOpenSkillConfig;
        

        private Button[] buttons;
        //查找组件
        private void Awake()
        {
            characterMoter = GetComponent<CharacterMoter>();
            status = GetComponent<CharacterStatusBase>();
            animator = GetComponentInChildren<Animator>();
            buttons = FindObjectsOfType<Button>();
        }

        //注册事件
        private void OnEnable()
        {
            //btn1.onClick.AddListener(OnMoveStart);

            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].onClick.AddListener(OnBtnClick);
            }
        }
        //注销事件
        private void OnDisable()
        {
            //btn1.onClick.RemoveListener(OnMoveEnd);
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].onClick.RemoveListener(OnBtnClick);
                
            }
            
        }

        private void Update()
        {
            openMyBag();
            openSkillConfig();
            OnMove();


        }

        private void OnBtnClick()
        {
            //点击事件
            Debug.Log("click click click");
            //获取当前点击的对象
            GameObject selectedButton = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;
            print(selectedButton.name);
            
            if (selectedButton.name == "attack")
            {
                SkillData a = GetComponent<Skill.CharacterSkillManager>().PrepareSkill(1002);
                GetComponent<Skill.CharacterSkillManager>().GenerateSkill(a);
                animator.SetBool(status.chPrarms.attack,true);
               
            }

            if (selectedButton.name == "move")
            {
                OnMove();
            }
            
            
            
        }
        
        private void OnBtnEnd()
        {
            //点击事件
            Debug.Log("end end end");
            //animator.SetBool(status.chPrarms.attack,false);
            
        }

        private void OnMoveStart()
        {
            Debug.Log("run run run");
            //status = GetComponent<CharacterStatus>();
            animator.SetBool(status.chPrarms.run,true);
            
        }

        private void OnMoveEnd()
        {
            animator.SetBool(status.chPrarms.run,false);
            
        }


        //点击两次取消选中
        private void OnMouseDown()
        {
            if (GameManager.GetGM.selectedChess == this)
            {
                GameManager.GetGM.selectedChess = null;
                
                // GameManager.GetGM.gameUI.HideAttributePanel();
                // GameManager.GetGM.gameUI.HideSkiiButtons();
                status.CloseWalkableTiles();
            }
            else
            {
                GameManager.GetGM.selectedChess = this;
                // GameManager.GetGM.gameUI.ShowAttributePanel();
                // GameManager.GetGM.gameUI.ShowSkiiButtons();
                status.ShowWalkableTiles();
            }
            
        }
        
        //按下角色 触发,显示可移动的格子
        private void OnMove()
        {
            //鼠标左键按下
            if (Input.GetMouseButtonDown(0))
            { 
                //射线检测
                RaycastHit2D floorhit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
                
                if (floorhit)
                {
                    Debug.Log("shexzian 1");
                    if (floorhit.transform.gameObject.layer == LayerMask.NameToLayer("floor"))
                    {
                        Debug.Log(floorhit.transform.position);
                        characterMoter.Move(floorhit.transform);
                    }
                }

            }
     
            //character.ShowWalkableTiles();
        }

        private void openMyBag()
        {
            isOpenBag = myBag.activeSelf;
            if (Input.GetKeyDown(KeyCode.I))
            {
                isOpenBag = !isOpenBag;
                myBag.SetActive(isOpenBag);
            }
            
        }
        
        private void openSkillConfig()
        {
            isOpenSkillConfig = skillConfig.activeSelf;
            if (Input.GetKeyDown(KeyCode.O))
            {
                isOpenSkillConfig = !isOpenSkillConfig;
                skillConfig.SetActive(isOpenSkillConfig);
            }
            
        }

 
    }
}