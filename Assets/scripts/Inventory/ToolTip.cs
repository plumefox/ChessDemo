using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* 
 * author:
 * createdTime:
 */
namespace ChessDemo.Item 
{
    /// <summary>
    /// 
    /// </summary>

    public class ToolTip : MonoBehaviour
    {
        
        private CanvasGroup canvasGroup;
        private float tarAlpha = 1;
        private const int fadeSpeed = 2;
        private RectTransform rect;
        private bool isShowing;
        private Vector2 offset = new Vector2(10, 0);
        private Text parentContent;
        private Text childContent;

        public ToolTip()
        {
            tarAlpha = 0;
        }

        public void Start()
        {
            canvasGroup = GetComponent<CanvasGroup>();
            rect = GameObject.Find("Canvas").GetComponent<RectTransform>();
            parentContent = GetComponent<Text>();
            childContent = transform.Find("Content").GetComponent<Text>();
        }

        public void Update()
        {
            //渐变
            if (canvasGroup.alpha != tarAlpha)
            {
                canvasGroup.alpha = Mathf.Lerp(canvasGroup.alpha, tarAlpha, Time.deltaTime * fadeSpeed);
                if (Mathf.Abs(canvasGroup.alpha - tarAlpha)< 0.05f)
                {
                    canvasGroup.alpha = tarAlpha;
                    //canvasGroup.blocksRaycasts = canvasGroup.alpha == 0 ? false : true;
                }
            }

            if (isShowing)
            {
                Vector2 point;
                RectTransformUtility.ScreenPointToLocalPointInRectangle(rect, Input.mousePosition, null, out point);
                transform.localPosition = point+offset;
            }
        }

        public void Show(string content)
        {
            parentContent.text = content;
            childContent.text = content;
            isShowing = true;
            tarAlpha = 1;
        }

        public void Hide()
        {
            isShowing = false;
            tarAlpha = 0;
        }
    }
}