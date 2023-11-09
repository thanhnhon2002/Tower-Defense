using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingPlaceManager : AdminMonoBehaviour
{
    public static BuildingPlaceManager instance;
    protected BuildingPlace currentBuildingPlace;
    protected override void Awake()
    {
        instance = this;

    }
}
