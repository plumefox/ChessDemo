using System;
using System.Collections;
using System.Collections.Generic;
using ChessDemo.Character;
using Common;
using UnityEngine;


/* 
 * author:
 * createdTime:
 */
namespace ChessDemo.MoveType 
{
    /// <summary>
    /// 移动方式管理类
    /// </summary>
   
    public class MoveTypeManager : MonoBehaviour
    {
        private int moveTypeId;
        private MoveTypeBase moveType;
        private string moveTypeName;
        private string moveTypeDescription;

        
        public int MoveTypeId
        {
            get
            {
                return moveTypeId;
            }
            set
            { 
                moveTypeId = value;
                Init();
            }
        }

        public string MoveTypeName
        {
            get => moveTypeName;
            private set => moveTypeName = value;
        }

        public string MoveTypeDescription
        {
            get => moveTypeDescription;
            private set => moveTypeDescription = value;
        }

        public void Init()
        {
            moveType = CreateMoveType(MoveTypeId);
            moveTypeId = moveType.id;
            MoveTypeName = moveType.name;
            MoveTypeDescription = moveType.description;
        }
        
        //根据id反射创建movetype
        public static MoveTypeBase CreateMoveType(int id)
        {
            string classNameMoveType = string.Format("ChessDemo.MoveType.MoveType{0}",id);
            return CreateObject<MoveTypeBase>(classNameMoveType);
        }
        
        private static T CreateObject<T>(string className)where T:class
        {
            Type type = Type.GetType(className);
            //反射创建对象
            return Activator.CreateInstance(type) as T;
        }

        public bool CanMove(float x1, float y1, float x2, float y2)
        {
            return moveType.CanMove( x1,  y1,  x2,  y2);
        }

    }
}