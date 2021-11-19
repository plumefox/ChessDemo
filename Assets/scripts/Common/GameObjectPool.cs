using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
 * author:
 * createdTime:
 */
namespace Common 
{
    /// <summary>
    /// 对象池
    /// 使用时继承IResetable
    /// </summary>
    public interface IResetable
    {
        void OnReset();
    }
    public class GameObjectPool : MonoSingleton<GameObjectPool>
    {
        //cache用于存储 key为类型，value为gameobject list的字典
        private Dictionary<string, List<GameObject>> cache;

        public override void Init()
        {
            base.Init();
            cache = new Dictionary<string, List<GameObject>>();
        }
        
        public GameObject CreateObject(string key, GameObject prefab, Vector3 pos, Quaternion rotation)
        {
            GameObject go = FindUsableObject(key);
            if (go == null)
                go = AddObejct(key, prefab);
            //使用
            UseObject(pos, rotation, go);
            return go;
        }

        //使用对象
        private static void UseObject(Vector3 pos, Quaternion rotation, GameObject go)
        {
            go.transform.position = pos;
            go.transform.rotation = rotation;
            go.SetActive(true);
            //抽象接口,遍历物体中所有需要重置的逻辑
            foreach (var item in go.GetComponents<IResetable>())
            {
                item.OnReset();
            }
        }

        //添加对象
        private GameObject AddObejct(string key, GameObject prefab)
        {
            GameObject go = Instantiate(prefab);
            //如果对象池中没有记录则添加
            if (!cache.ContainsKey(key))
                cache.Add(key, new List<GameObject>());
            cache[key].Add(go);
            return go;
        }

        //查找指定类别中可以使用的对象
        private GameObject FindUsableObject(string key)
        {
            if (cache.ContainsKey(key))
            {
                return cache[key].Find(s => !s.activeInHierarchy);
            }
               
            return null;
        }

        //回收对象
        public void CollectObject(GameObject go,float delay=0)
        {
            StartCoroutine(CollectObjectDelay(go,delay));
        }
        
        private IEnumerator CollectObjectDelay(GameObject go,float delay)
        {
            yield return new WaitForSeconds(delay);
            go.SetActive(false);
        }

        //清空一类缓存    
        public void Clear(string key)
        {
            for (int i = cache[key].Count -1; i >= 0 ; i--)
            {
                Destroy(cache[key][i]);
            }
            cache.Remove(key);
        }
        
        //全部清空
        public void ClearAll()
        {
            foreach (var key in new List<string>(cache.Keys))
            {
                Clear(key);
            }
        }
    }
}