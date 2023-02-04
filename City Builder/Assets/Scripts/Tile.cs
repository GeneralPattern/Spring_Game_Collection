using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Tile
{
    public BuildingObject buildingRef;

    public ObstacleType obstacleType;

    bool isStarterTile = true;

    public enum ObstacleType
    {
        None,
        Resource,
        Building
    }

    public void SetOccupied(ObstacleType t)
    {
        obstacleType = t;
        
    }

    public void SetOccupied(ObstacleType t, BuildingObject b)
    {
        obstacleType = t;
        
        buildingRef = b;
    }

    public void CleanTile()
    {
        obstacleType = ObstacleType.None;
    }

    public void StarterTileValue(bool value)
    {
        isStarterTile = value;
    }

    public bool IsOccupied
    {
        get
        {
            return obstacleType != ObstacleType.None;
        }
    }

    public bool CanSpawnObstacle
    {
        get
        {
            return !isStarterTile;
        }
    }

}
