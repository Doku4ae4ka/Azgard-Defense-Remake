using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    public TowersFactory towersFactory;
    public BuildingSystem buildingSystem;

    public override void InstallBindings()
    {
        BindTowersFactory();
        BindBuildingSystem();
    }

    public void BindTowersFactory()
    {
        Container.Bind<ITowersFactory>().FromInstance(towersFactory).AsSingle().NonLazy();
    }

    public void BindBuildingSystem()
    {
        Container.Bind<BuildingSystem>().FromInstance(buildingSystem).AsSingle().NonLazy();
    }
}
