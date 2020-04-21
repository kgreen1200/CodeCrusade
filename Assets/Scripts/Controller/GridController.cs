using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridController : MonoBehaviour
{
    public const int rows = 2;
    public const int cols = 4;

    public Vector2 start;
    public Grid grid;

    GridTile[] tiles;

    // Start is called before the first frame update
    void Start()
    {
        tiles = new GridTile[rows * cols];
        BuildTiles();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void BuildTiles()
    {
        for (int x = 0; x < cols; x++)
        {
            for (int y = 0; y < rows; y++)
            {
                tiles[GetIndex(x, y)] = new GridTile();
            }
        }
    }

    public int GetIndex(int x, int y)
    {
        return x + (cols * y);
    }

    public GridTile GetGridTile(int x, int y)
    {
        if (x >= 0 && x < cols && y >= 0 && y < rows)
        {
            return tiles[GetIndex(x, y)];
        }
        return new GridTile();
    }

    public void SetBlock(int x, int y, Block block)
    {
        tiles[GetIndex(x, y)].block = block;
    }
}
