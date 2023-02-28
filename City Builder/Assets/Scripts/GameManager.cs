using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public GameObject manager;
    
    [Header("Builder")]
    [Space(8)]

    public GameObject tilePrefab;

    public int levelWidth;
    public int levelLength;
    public Transform tilesHolder;
    public float tileSize = 1;
    public float tileEndHeight = 1;
    public IntData levelSize;

    [Space(8)]
    public TileObject[,] tileGrid = new TileObject[0,0];

    [Header("Resources")]
    [Space(8)]

    public GameObject woodPrefab;
    public GameObject rockPrefab;
    public Transform resourcesHolder;

    [Range(0,1)]
    public float obstacleChance = 0.3f;

    public int xBounds = 3;
    public int zBounds = 3;


    [Space(10)]
    [Header("Building Method")]
    [Space(8)]
    public BuildingObject buildingToPlace;

    [Header("Building Research Level")]
    [Space(10)]
    public IntData buildingResearchLevel;

    
    
    public static GameManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        if (levelSize.value == 3)
            {
                levelLength = 40;
                levelWidth = 40;
            }
        if (levelSize.value == 2)
            {
                levelLength = 20;
                levelWidth = 20;
            }
        if (levelSize.value == 1)
            {
                levelLength = 10;
                levelWidth = 10;
                xBounds = 2;
                zBounds = 2;

            }
        CreateLevel();
    }

    public void CreateLevel()
    {
        List<TileObject> visualGrid = new List<TileObject>();

        for (int x = 0; x < levelWidth; x++)
        {
            for (int z = 0; z < levelLength; z++)
            {
                TileObject spawnedTile = SpawnTile(x * tileSize, z * tileSize);
                spawnedTile.xPos = x;
                spawnedTile.zPos = z;

                if (x < xBounds || z < zBounds || z >= (levelLength - zBounds) || x >= (levelWidth - xBounds))
                {
                    spawnedTile.data.StarterTileValue(false);
                }

                if (spawnedTile.data.CanSpawnObstacle)
                {
                    bool spawnObstacle = Random.value <= obstacleChance;

                    if (spawnObstacle)
                    {
                        spawnedTile.data.SetOccupied(Tile.ObstacleType.Resource);

                        ObstacleObject tmpObstacle = SpawnObstacle(spawnedTile.transform.position.x, spawnedTile.transform.position.z);
                        tmpObstacle.SetTileReference(spawnedTile);

                    }
                }
                
                visualGrid.Add(spawnedTile);

            }
        }

        CreateGrid(visualGrid);
    }

    TileObject SpawnTile(float xPos, float zPos)
    {
        GameObject tmpTile = Instantiate(tilePrefab);

        tmpTile.transform.position = new Vector3(xPos, 0, zPos);
        tmpTile.transform.SetParent(tilesHolder);

        tmpTile.name = "Tile " + xPos + " - " + zPos;

        return tmpTile.GetComponent<TileObject>();
    }

    ObstacleObject SpawnObstacle(float xPos, float zPos)
    {
        bool isWood = Random.value <= 0.5f;

        GameObject spawnedObstacle = null;

        if (isWood)
        {
            spawnedObstacle = Instantiate(woodPrefab);
            spawnedObstacle.name = "Wood" + xPos + " - " + zPos;
        }
        else
        {
            spawnedObstacle = Instantiate(rockPrefab);
            spawnedObstacle.name = "Stone" + xPos + " - " + zPos;
        }

        spawnedObstacle.transform.position = new Vector3(xPos, tileEndHeight, zPos);
        spawnedObstacle.transform.SetParent(resourcesHolder);

        return spawnedObstacle.GetComponent<ObstacleObject>();
        
    }

    public void CreateGrid(List<TileObject> refVisualGrid)
    {
        tileGrid = new TileObject[levelWidth, levelLength];

        for (int x = 0; x < levelWidth; x++)
        {
            for (int z = 0; z < levelLength; z++)
            {
                tileGrid[x,z] = refVisualGrid.Find(v => v.xPos == x && v.zPos == z);
            }
        }
    }

    public void SpawnBuilding(BuildingObject building, List<TileObject> tiles)
    {
        GameObject spawnedBuilding = Instantiate(building.gameObject);
        float sumX = 0;
        float sumZ = 0;

        //BAD
        //Vector3 position = new Vector3(tile.xPos, tileEndHeight, tile.zPos);

        

        for(int i = 0; i < tiles.Count; i++)
        {
            sumX += tiles[i].xPos;
            sumZ += tiles[i].zPos;

            tiles[i].data.SetOccupied(Tile.ObstacleType.Building, spawnedBuilding.GetComponent<BuildingObject>());
            Debug.Log("Placed Building at " + tiles[i].xPos + " - " + tiles[i].zPos);
            
                
        }

        Vector3 position = new Vector3( (sumX / tiles.Count), tileEndHeight + building.data.yPadding, (sumZ / tiles.Count));

        spawnedBuilding.transform.position = position;



    }

    public void SelectBuilding(int id)
    {
        for (int i = 0; i < BuildingsDatabase.Instance.buildingsDatabase.Count; i++)
        {
            if (BuildingsDatabase.Instance.buildingsDatabase[i].buildingID == id)
            {
                buildingToPlace = BuildingsDatabase.Instance.buildingsDatabase[i].refOfBuilding;
            }
        }
    }
}
