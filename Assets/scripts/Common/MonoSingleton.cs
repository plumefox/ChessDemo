﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
 * author:
 * createdTime:
 */
namespace Common 
{
    /// <summary>
    /// 脚本单例类,对象唯一，即可继承该类
    /// </summary>

    public class MonoSingleton<T>: MonoBehaviour where T:MonoSingleton<T>
    {
        private static T instance;
        public static T Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = FindObjectOfType<T>();
                    if (instance == null)
                    {
                        instance = new GameObject("Singleton of " + typeof(T)).AddComponent<T>();
                    }
                    else
                    {
                        instance.Init();
                        
                    }
                }
                return instance;
            }
        }
        public void Awake()
        {
            if (instance == null)
            {
                instance = this as T;
                Init();
            }
        }
        public virtual void Init() {}
    }

}