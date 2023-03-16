using UnityEngine;

[System.Serializable]
public class Building
{   
    public int buildingID;

    public string name;
    public int width = 0;
    public int length = 0;

    public int woodCost = 0;
    public int stoneCost = 0;

    public GameObject buildingModel;

    public float yPadding = 0;

    public ResourceType resourceType = ResourceType.None;

    public StorageType storageType = StorageType.None;

    public BoolData Research;

    
    public BuildingObject refOfBuilding;
    public enum ResourceType
    {
        None,
        Standard,
        Premium,
        Storage,
        Research
    }
    public enum StorageType
    {
        None,
        Wood,
        Stone
    }

   
}
