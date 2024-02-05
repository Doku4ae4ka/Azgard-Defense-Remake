using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Net;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;
using Zenject;
using static Unity.PlasticSCM.Editor.WebApi.CredentialsResponse;
using static UnityEditor.Progress;

public class BuildingSystem : MonoBehaviour
{
    private ITowersFactory _towerFactory;

    [SerializeField] private Tilemap exclusionTilemap;
    [SerializeField] private TileBase exclusionTile;
    [SerializeField] private TileBase emptyTile;
    [SerializeField] private GameObject TowersParent;

    //public static BuildingSystem current;

    [Inject]
    private void Construct(ITowersFactory towerFactory)
    {
        _towerFactory = towerFactory;
    }


    private bool isBuildMode = false;
    private bool isBuildValid = false;

    private GameObject towerPreview;
    private string _towerType;

    public void Init(ITowersFactory towerFactory)
    {
        _towerFactory = towerFactory;
    }

    public void InitiateBuildMode(string towerType)
    {
        if (isBuildMode)
            CancelBuildMode();
        isBuildMode = true;
        towerPreview = _towerFactory.CreateTowerPreview(towerType, GetMouseOnGridPos());
        _towerType = towerType;

    }

    private void Update()
    {
        if (isBuildMode)
        {
            UpdateTowerPreview();
        }

        if (Input.GetMouseButtonDown(1) && isBuildMode)
        {
            CancelBuildMode();
        }
        else if(Input.GetMouseButtonDown(0) && isBuildMode)
        {
            VerifyAndBuild();
        }
    }

    private void CancelBuildMode()
    {
        isBuildMode = false;
        isBuildValid = false;
        Destroy(towerPreview);
    }


    private void VerifyAndBuild()
    {
        if (isBuildValid)
        {
            GameObject newTower = _towerFactory.CreateTower(_towerType, GetMouseOnGridPos());
            newTower.transform.parent = TowersParent.transform;
            exclusionTilemap.SetTile(GetMouseOnGridPos(), exclusionTile);
        }
        else { CancelBuildMode(); }
    }

    private void UpdateTowerPreview()
    {
        Vector3Int currentPos = GetMouseOnGridPos();
        TileBase currentTile = exclusionTilemap.GetTile(currentPos);

        if (currentTile.name == "Cyan")
        {
            UpdateTowerPosAndColor(currentPos, UnityEngine.Color.green);
            isBuildValid = true;

        }
        else if (currentTile.name == "Purple")
        {
            UpdateTowerPosAndColor(currentPos, UnityEngine.Color.red);
            isBuildValid = false;
        }
    }

    private void UpdateTowerPosAndColor(Vector3Int newPosition, UnityEngine.Color color)
    {
        Transform towerSelectTransform = towerPreview.transform.Find("TowerSelect");
        towerSelectTransform.gameObject.GetComponent<SpriteRenderer>().color = color;

        towerPreview.transform.position = newPosition;

    }

    private Vector3Int GetMouseOnGridPos()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int mouseCellPos = exclusionTilemap.WorldToCell(mousePos);
        mouseCellPos.z = 0;

        return mouseCellPos;
    }

}
