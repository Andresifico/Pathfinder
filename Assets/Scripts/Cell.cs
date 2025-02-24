using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Cell : MonoBehaviour
{
    [SerializeField] private TextMeshPro textMeshPro;
    [SerializeField] private GameObject Inner;
    private Grid grid;
    public bool isWalkable;
    public int x, y ;
    public int gCost, hCost, fCost;
    public Cell pastCell;

    public void Init(Grid grid, int x, int y, bool isWalkable)
    {
        this.grid = grid;
        this.x = x;
        this.y = y;
        this.isWalkable = isWalkable;
    }

    public Vector2 Position => transform.position;

    public void SetColor(Color color)
    {
        Inner.GetComponent<SpriteRenderer>().color = color;
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButton(0))
        {
            grid.CellMouseClick(this);
        } 
    }

    internal void CalculateFCost()
    {
        fCost = gCost + hCost;
    }

    internal void SetWalkable(bool v)
    {
        isWalkable = v;
        SetColor(Color.black);
    }

    public override string ToString()
    {
        return "Cell "+x + "," + y;
    }
}
