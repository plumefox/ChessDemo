using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
 * author:
 * createdTime:
 */
namespace ChessDemo.Item 
{
    /// <summary>
    /// 
    /// </summary>

    public class PickItem : ItemTruly
    {
        private RectTransform rect;

        public override void Start()
        {
            rect = GameObject.Find("Canvas").GetComponent<RectTransform>();
            base.Start();
        }
        private void Update()
        {
            Vector2 point;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(rect, Input.mousePosition, null, out point);
            transform.localPosition = point;
        }
    }

}