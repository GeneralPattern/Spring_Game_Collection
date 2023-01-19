using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Building
{   
    public int buildingID;

    public int width = 0;
    public int length = 0;



    public ResourceType resourceType = ResourceType.None;

    public enum ResourceType
    {
        None,
        Standard,
        Premium
    }

   
}
