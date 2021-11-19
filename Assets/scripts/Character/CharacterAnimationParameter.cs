using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
 * author:
 * createdTime:
 */
namespace ChessDemo.Character 
{
    /// <summary>
    /// 角色动画参数
    /// </summary>

    [Serializable]
    public class CharacterAnimationParameter
    {
        public string run = "run";
        public string attack = "attack";
        public string idle = "idle";
        public string die = "die";
        public string jump = "jump";

    }
}