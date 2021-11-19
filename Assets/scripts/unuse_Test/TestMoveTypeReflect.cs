using System;
using System.Collections;
using System.Collections.Generic;
using ChessDemo.Character;
using ChessDemo.MoveType;
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

    public class TestMoveTypeReflect: MonoBehaviour
    {
        public void OnGUI()
        {
            if (GUILayout.Button("movetype"))
            {
                
                MoveTypeManager mt = GetComponent<MoveTypeManager>();
                mt.MoveTypeId = GetComponent<CharacterStatusBase>().MoveTypeID;;
                Debug.Log(mt.CanMove(1, 1, 1, 5));
                Debug.Log(mt.MoveTypeName);
                Debug.Log(mt.MoveTypeId);
                Debug.Log(mt.MoveTypeDescription);


            }
        }
    }



}