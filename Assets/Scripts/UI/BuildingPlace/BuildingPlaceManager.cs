using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingPlaceManager : AdminMonoBehaviour
{
    public static BuildingPlaceManager instance;
    protected BuildingPlace currentBuildingPlace;
    public BuildingPlace _currentBuildingPlace => currentBuildingPlace;
    public void SetCurrentPlace(BuildingPlace buildingPlace) => this.currentBuildingPlace = buildingPlace;
    protected override void Awake()
    {
        instance = this;
    }
    
}
