using System.Collections;
using System.Collections.Generic;
using Common;
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

    public class Bullet : MonoBehaviour,IResetable
    {
        private Vector2 targetPos;
        
        // Update is called once per frame
        void Update()
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPos,
                Time.deltaTime * 50);

            if (Vector2.Distance(transform.position, targetPos )<0.1)
            {
                GameObjectPool.Instance.CollectObject(gameObject);
            }    
                
        }

        public void OnReset()
        {
            targetPos = transform.TransformPoint(0, 20, 0);
        }
    }
}