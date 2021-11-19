using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/* 
 * author:
 * createdTime:
 */
namespace Common 
{
    /// <summary>
    /// 拖动窗口
    /// </summary>

    public class MoveUIWindow : MonoBehaviour,IDragHandler
    {
        private RectTransform currentRect;

        private void Awake()
        {
            currentRect = GetComponent<RectTransform>();
        }
        
        public void OnDrag(PointerEventData eventData)
        {
            currentRect.anchoredPosition += eventData.delta;
        }
        
    }
}