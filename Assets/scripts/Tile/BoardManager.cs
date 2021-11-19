using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

/*
 *管理地面铺设
 * 
 */

public class BoardManager : MonoBehaviour
{
    public int rows = 8;
    public int columns = 8;
    public GameObject[] floatTiles;
    public GameObject[] outerWallTiles;
    public GameObject[] eventTiles;
    public GameObject[] monsterTiles;
    public GameObject errorTile;
    private Transform _tilesHolder;
    private List<GameObject> tiles = new List<GameObject>();
    
    
    
    // Start is called before the first frame update
    public void SetupScene()
    {
        BoardSetup();
    }

    //铺设地板
    void BoardSetup()
    {
        _tilesHolder = new GameObject("Map").transform;
        
        int eventIndex = 0;
        
        for (int x = 0; x < columns; x++)
        {
            for (int y = 0; y < rows; y++)
            {
                eventIndex = Random.Range(0, 3);
                GameObject floatTile = errorTile;
                
                if (x == 0 || y == 0 || x == columns-1 || y == rows-1)
                {
                    floatTile = outerWallTiles[Random.Range(0, outerWallTiles.Length)];
                }
                else
                {
                    switch (eventIndex)
                    {
                        case 1:
                        {
                            floatTile = eventTiles[Random.Range(0, eventTiles.Length)];
                            break;
                        }
                        case 2:
                        {
                            floatTile = monsterTiles[Random.Range(0, monsterTiles.Length)];
                            break;
                        }
                        default:
                        {
                            floatTile = floatTiles[Random.Range(0, floatTiles.Length)];
                            break;
                        }
                    }
                    
                }
                GameObject instance = Instantiate(floatTile,new Vector3(x,y,0f),Quaternion.identity) as GameObject;
                instance.transform.SetParent(_tilesHolder);
                tiles.Add(instance);

            }
        }


    }
    
    public List<GameObject> Tiles
    {
        get
        {
            return tiles;
        }
        set
        {
            tiles = value;

        }
    }
    


}
