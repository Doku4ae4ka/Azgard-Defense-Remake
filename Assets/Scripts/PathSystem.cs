using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PathSystem : MonoBehaviour
{
    [SerializeField] private Tilemap roadTilemap;
    [SerializeField] private TileBase[] roadTiles;

    private List<Vector3> pathPoints = new List<Vector3>();

    BoundsInt bounds;

    void Start()
    {
        roadTilemap.CompressBounds();
        bounds = roadTilemap.cellBounds;

        GeneratePath();

    }

    void GeneratePath()
    {
        pathPoints.Clear();
        TileBase[] allTiles = roadTilemap.GetTilesBlock(bounds);

        for (int x = 0; x < bounds.size.x; x++)
        {
            for (int y = 0; y < bounds.size.y; y++)
            {
                TileBase tile = allTiles[x + y * bounds.size.x];
                if (IsRoadTile(tile))
                {
                    Vector3Int localPlace = (new Vector3Int(x, y, (int)roadTilemap.transform.position.z));
                    Vector3 place = roadTilemap.CellToWorld(localPlace);
                    pathPoints.Add(place);
                }
            }
        }
    }

    bool IsRoadTile(TileBase tile)
    {
        foreach (var roadTile in roadTiles)
        {
            if (tile == roadTile)
            {
                return true;
            }
        }
        return false;
    }
}
