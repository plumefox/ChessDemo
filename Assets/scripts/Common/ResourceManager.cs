using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Object = System.Object;

/* 
 * author:
 * createdTime:
 */
namespace Common 
{
    /// <summary>
    /// 资源加载器,根据资源名称获取资源
    /// </summary>
    public class ResourceManager
    {
        private static Dictionary<string, string> configMap;
        //静态构造函数 初始化类到静态数据成员
        //类被加载时执行一次
        static ResourceManager()
        {
            string fileContent = GetConfigFile("ConfigMap.txt");
            BuildMap(fileContent);

        }
        public static string GetConfigFile(string fileName)
        {
            string url;
            #region unity宏 
                //分平台判断路径，否则会概率性产生问题
                //如果在编译器下
                #if UNITY_EDITOR || UNITY_STANDALONE
                    url = "file://"+Application.dataPath+"/StreamingAssets/"+fileName;
                //ios
                #elif UNITY_IPHONE
                    url = "file://"+Application.dataPath+"/Raw/"+fileName;
                //android
                #elif UNITY_ANDROID
                    url = "jar:file://"+Application.dataPath+"!/assets/"+fileName;
                #endif
            #endregion
            //移动端只能通过www读取
            WWW www = new WWW(url);
            while (true)
            {
                if(www.isDone)
                    return www.text;
            }
            
        }
        public static void BuildMap(string fileContent)
        {
            configMap = new Dictionary<string, string>();
            //解析
            //字符串读取器
            using (StringReader reader = new StringReader(fileContent))
            {
                string line;
                while ((line=reader.ReadLine())!= null)
                {
                    string[] keyValue = line.Split('=');
                    configMap.Add(keyValue[0],keyValue[1]);
                }
            }
        }
        public static T Load<T>(string prefabName) where T : UnityEngine.Object
        {
            string prefabPath = configMap[prefabName];
            return Resources.Load<T>(prefabPath);
        }
    }

}