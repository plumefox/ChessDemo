using System.Collections;
using System.Collections.Generic;
using ChessDemo.Character;
using ChessDemo.MoveType;
using ChessDemo.UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager gm;
    BoardManager boardManager;
    // public int mapSeed = 0; //地图随机种子
    // public float eventFrequency = 5f;//事件占比 
    // public float maxEvent = 5f;
    // public float minEvent = 0;
    //public Chess selectedChess;
    public CharacterInputController selectedChess;
    public UIcontrol gameUI;
    public MoveTypeManager moveTypeManager;
    //保存要加载的场景名
    public static string LoadSceneName;
    
    //private List<GameObject> tiles;

    public static GameManager GetGM
    {
        get
        {
            return gm;
        }
    }
    
    void Awake()
    {
        gm = this;
        boardManager = GetComponent<BoardManager>();
        gameUI = GameObject.FindObjectOfType<UIcontrol>();
        moveTypeManager = new MoveTypeManager();
        
        
        InitGame();
    }

    // Update is called once per frame
    void Update()
    {
         
    }

    void InitGame()
    {
        boardManager.SetupScene();
        
        Debug.Log(boardManager.Tiles.Count);

    }

    public List<GameObject> Tiles
    {
        get
        {
            return boardManager.Tiles;
        }
        
    }
}
