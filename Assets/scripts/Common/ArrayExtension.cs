using System;
using System.Collections;
using System.Collections.Generic;
/* 扩展功能
 * 
 */

namespace Common
{
    /// <summary>
    /// 数组扩展
    /// </summary>
    static class ArrayExtension
    {
        //寻找符合表达式的对象，否则返回空
        public static T Find<T>(this T[] array, Func<T, bool> condition)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (condition(array[i]))
                {
                    return array[i];
                }
            }

            return default(T);
        }

        //查找所有满足条件的元素
        public static T[] FindAll<T>(this T[] array,Func<T,bool> condition)
        {
            List<T> list = new List<T>();

            for (int i = 0; i < array.Length; i++)
            {
                if (condition(array[i]))
                {
                    list.Add(array[i]);
                }

            }
           
            return list.ToArray();

        }
        
        //动态增加成员
        public static T Add<T>(this T[] array, Func<T, bool> condition)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (condition(array[i]))
                {
                    return array[i];
                }
            }

            return default(T);
        }

        //求最大值
        public static T GetMax<T,Q>(this T[] array, Func<T, Q> condition) where Q:IComparable
        {
            T max = array[0];
            for (int i = 0; i < array.Length; i++)
            {
                if (condition(max).CompareTo(condition(array[i]))<0)
                {
                    max = array[i];

                }
            }

            return max;
        }
        
        //求最小值
        public static T GetMin<T,Q>(this T[] array, Func<T, Q> condition) where Q:IComparable
        {
            T min = array[0];
            for (int i = 0; i < array.Length; i++)
            {
                if (condition(min).CompareTo(condition(array[i]))>0)
                {
                    min = array[i];
                }
            }
            return min;
        }

        //筛选
        public static Q[] Select<T,Q>(this T[] array,Func<T,Q> condition)
        {
            List < Q > result= new List<Q>();
            //Q[] result = new Q[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                result.Add(condition(array[i])); 
            }
            return result.ToArray();

        }
       
       

    }
    
}



