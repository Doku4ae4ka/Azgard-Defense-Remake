using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BuildingSystem : MonoBehaviour
{
    private SpriteRenderer rend;

    private bool isBuildMode = false;
    private bool isBuildValid = false;

    private string buildType = null;

    private Vector3Int buildLocation;

    [SerializeField] private Tilemap exclusionTilemap;
    [SerializeField] private TileBase exclusionTile;

    private void InitiateBuildMode()
    {
        if (isBuildMode)
            CancelBuildMode();
        isBuildMode = true;
        SetTowerPreview(buildType, GetMouseOnGridPos());

    }

    private void SetTowerPreview(string towerType, Vector3Int currentTilePos)
    {

    }

    private void Update()
    {
        
    }

    private void CancelBuildMode()
    {
        isBuildMode = false;
        isBuildValid = false;
    }

    private void VerifyAndBuild()
    {
        
    }

    private void UpdateTowerPreview()
    {
        var currentTile = exclusionTilemap.GetTile(GetMouseOnGridPos());

        if (exclusionTilemap.GetTile(GetMouseOnGridPos()).name == "Cyan")
        {

        }
        else if (exclusionTilemap.GetTile(GetMouseOnGridPos()).name == "Purple")
        {

        }
    }

    private void UpdateTowerPosAndColor(Vector3Int newPosition, Color color)
    {

    }

    private Vector3Int GetMouseOnGridPos()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int mouseCellPos = exclusionTilemap.WorldToCell(mousePos);
        mouseCellPos.z = 0;

        return mouseCellPos;
    }


}
