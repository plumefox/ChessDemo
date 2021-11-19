using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
 * author:
 * createdTime:2021/2/20
 */
namespace ChessDemo.Character 
{
    /// <summary>
    /// 敌人状态类
    /// </summary>

    public class EnemyStatus: CharacterStatusBase
    {
        protected override void Death()
        {
            base.Death();
            Destroy(gameObject,1);
        }
    }

}