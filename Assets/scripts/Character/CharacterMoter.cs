using System.Collections;
using System.Collections.Generic;
using ChessDemo.Character;
using ChessDemo.MoveType;
using UnityEngine;
using Object = System.Object;

/* 
 * author:
 * createdTime:
 */
namespace ChessDemo.Character 
{
    /// <summary>
    /// 角色直接行为
    /// </summary>
    
    public class CharacterMoter : MonoBehaviour
    {
        private CharacterController controller;
        // Start is called before the first frame update
        void Start()
        {
            controller = GetComponent<CharacterController>();
        }

        //移动到目标点 _trans 目标点
        public void Move(Transform _trans)
        {
            //transform.position = Vector2.MoveTowards(transform.position, new Vector2(_trans.position.x, _trans.position.y),moveSpeed * Time.deltaTime);
            transform.position = _trans.position;//直接在指定位置出现
            
        }
        


    }
}