using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public class Tile : MonoBehaviour
{
    public bool canWalk;
    public Color highLightColor;
    private SpriteRenderer _spriteRenderer;
    public LayerMask obLayerMask;

    private void Start()
    {
        CheckCanWalk();
    }

    //鼠标移入
    private void OnMouseEnter()
    {
        
        HighListTile();
    }

    //鼠标移出
    private void OnMouseExit()
    {
        ResetTileStatus();
    }

    private void OnMouseDown()
    {
        //chess move to this tile
        if (canWalk && GameManager.GetGM.selectedChess != null)
        {
            
            //GameManager.GetGM.selectedChess.Movement(this.transform);
        }
        

    }

    public void HighListTile()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        if (canWalk)
        {
            _spriteRenderer.color = highLightColor;
        }
        else
        {
            _spriteRenderer.color = Color.white;

        }
    }

    public void ResetTileStatus()
    {
        _spriteRenderer.color = Color.white;
    }
    
    //判断该格子是否可以移动，是否有障碍物阻止移动 
    public void CheckCanWalk()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        Collider2D collider = Physics2D.OverlapCircle(transform.position, _spriteRenderer.bounds.extents.x, obLayerMask);
        if (collider != null || transform.CompareTag("blockWall"))
        {
            canWalk = false;
        }
        else
        {
            canWalk = true;

        }
        
    }

}
