using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITowersFactory
{
    public GameObject CreateTowerPreview(string towerType, Vector3Int currentTilePos);

    public GameObject CreateTower(string towerType, Vector3Int currentTilePos);
}