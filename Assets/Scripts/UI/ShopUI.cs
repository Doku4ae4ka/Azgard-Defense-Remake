using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ShopUI : MonoBehaviour
{
    private BuildingSystem _buildingSystem;

    [SerializeField] private Button _towerArcherBtn;
    [SerializeField] private Button _towerGunBtn;
    [SerializeField] private Button _towerWindBtn;

    [Inject]
    private void Construct(BuildingSystem buildingSystem)
    {
        _buildingSystem = buildingSystem;
    }


    private void Start()
    {
        InitButtons();
    }

    private void InitButtons()
    {
        _towerArcherBtn.onClick.AddListener((() =>
        {
            string towerType = "TowerArcher";
            _buildingSystem.InitiateBuildMode(towerType);
        }));

        _towerGunBtn.onClick.AddListener((() =>
        {
            string towerType = "TowerGun";
            _buildingSystem.InitiateBuildMode(towerType);
        }));

        _towerWindBtn.onClick.AddListener((() =>
        {
            string towerType = "TowerWind";
            _buildingSystem.InitiateBuildMode(towerType);
        }));

    }
}