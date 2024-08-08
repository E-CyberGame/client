using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(Tilemap))]
[RequireComponent(typeof(Grid))]
public class GridManager : MonoBehaviour
{
    Grid grid;
    Tilemap tilemap;
    [SerializeField] TileBase tileBase;


    // Start is called before the first frame update
    void Start()
    {
        grid = GetComponent<Grid>();
        tilemap = GetComponent<Tilemap>();
        grid.Init(40,1);
    }

    void UpdateTileMap()
    {
        for(int x = 0; x< grid.length; x++)
        {
            for(int y = 0; y< grid.height; y++)
            {
                tilemap.SetTile(new Vector3Int(x, y, 0), tileBase);
            }
        }
    }
}
