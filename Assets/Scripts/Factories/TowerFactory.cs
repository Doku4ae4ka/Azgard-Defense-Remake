using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class TowersFactory : MonoBehaviour, ITowersFactory
{
    [SerializeField] private TowerData[] _towerDatas;

    private TowerData _towerData;

    public TowerData GetTowerData(string towerType)
    {
        foreach (var data in _towerDatas)
        {
            if (data.name == towerType + "Data")
            {
                return data;
            }
        }
        Debug.LogError("Tower data not found: " + towerType);
        return null;
    }

    public GameObject CreateTowerPreview(string towerType, Vector3Int currentTilePos)
    {
        _towerData = GetTowerData(towerType);
        GameObject towerPreview = Instantiate(_towerData.prefab);
        towerPreview.transform.position = currentTilePos;
        Transform towerSelectTransform = towerPreview.transform.Find("TowerSelect");
        if (towerSelectTransform != null)
        {
            towerSelectTransform.gameObject.SetActive(true);
        }
        else { Debug.LogError("TowerSelect not found"); }
        Transform towerRangeTransform = towerPreview.transform.Find("Range");
        if (towerRangeTransform != null)
        {
            towerRangeTransform.gameObject.GetComponent<SpriteRenderer>().enabled = true;
        }
        else { Debug.LogError("Range object not found"); }
        Transform towerModelTransform = towerPreview.transform.Find("TowerModel");
        if (towerModelTransform != null)
        {
            towerModelTransform.gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 0.45f, 0.6f);
        }
        else { Debug.LogError("TowerModel not found"); }
        return towerPreview;
    }

    public GameObject CreateTower(string towerType, Vector3Int currentTilePos)
    {
        _towerData = GetTowerData(towerType);
        GameObject newTower = Instantiate(_towerData.prefab);
        newTower.transform.position = currentTilePos;
        return newTower;
    }

    public int CountEntities()
    {
        return 0;
    }
}
