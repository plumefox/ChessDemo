using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GenerateItems : MonoBehaviour
{
    public Transform[] spawnPoints;//存储事件坐标
    public GameObject[] items;//存储prefab事件列表
    
  
   
    private GameObject[] mapEventlist;
    private List<int> mapEventIndexList;
    public int eventCount = 3;
    
    void GenerateRandomItems()
    {
        //索引，spawnindex 地图 itemidex 物品
        int spawnIndex = Random.Range(0, spawnPoints.Length);
        int itemIndex = Random.Range(0, items.Length);
        Instantiate(items[itemIndex], spawnPoints[spawnIndex].position,spawnPoints[spawnIndex].rotation);

    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("poom_-发生碰撞");
    }

    void GetChidName()
    {
        Transform[] father = GetComponentsInChildren<Transform>();
        foreach (var child in father)
        {
            Debug.Log(child.name);
            
        }
        
    }
}
