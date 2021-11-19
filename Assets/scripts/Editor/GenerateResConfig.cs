using System.IO;
using UnityEditor;
using UnityEngine;
/* 
 * author:
 * createdTime:2021/2/18
 */
namespace Common 
{
    /// <summary>
    /// 程序发布的时候不会被带走
    /// AssetDatabase：包含了只在编辑器中操作资源的相关功能
    /// StreamingAssets:unity特殊目录之一，该目录的文件不会被压缩，适合在移动端读取资源（pc可以写入）
    /// Application.persistentDataPath 可以进行读写操作，unity外部 安装后产生
    /// </summary>
    public class GenerateResConfig : Editor
    {
        
        [MenuItem("Tools/Resources/Generate ResConfig File")]
        
        public static void Generate()
        {
            string saveFileName = "ConfigMap.txt";
            //生成资源配置文件
            string[] resFiles=AssetDatabase.FindAssets("t:prefab",new string[]{"Assets/Resources"});
            for (int i = 0; i < resFiles.Length; i++)
            {
                resFiles[i] = AssetDatabase.GUIDToAssetPath(resFiles[i]);
                string fileName = Path.GetFileNameWithoutExtension(resFiles[i]);
                string filepath = resFiles[i].Replace("Assets/Resources/", string.Empty).Replace(".prefab", string.Empty);
                resFiles[i] = fileName + "=" + filepath;
            }
            Debug.Log("yes");
            
            //只有一种选择，兼容pc，安卓，ios。保证可以读取到资源
            File.WriteAllLines("Assets/StreamingAssets/"+saveFileName,resFiles);
            //手动刷新
            AssetDatabase.Refresh();
            
        }
    }
}