using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Builder")]
    [Space(8)]

    public GameObject tilePrefab;

    public int levelWidth;
    public int levelLength;
    public Transform tilesHolder;
    public float tileSize = 1;
    public float tileEndHeight = 1;

    [Header("Resources")]
    [Space(8)]

    public GameObject woodPrefab;
    public GameObject rockPrefab;

    [Range(0,1)]
    public float obstacleChance = 0.3f;

    public int xBounds = 3;
    public int zBounds = 3;


    private void Start()
    {
        CreateLevel();
    }

    public void CreateLevel()
    {
        for (int x = 0; x < levelWidth; x++)
        {
            for (int z = 0; z < levelLength; z++)
            {
                TileObject spawnedTile = SpawnTile(x * tileSize, z * tileSize);

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

                        SpawnObstacle(spawnedTile.transform.position.x, spawnedTile.transform.position.z);

                        //Debug.Log("Spawned obstacle on " + spawnedTile.gameObject.name);
                        //spawnedTile.gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
                    }
                }
                
            }
        }
    }

    TileObject SpawnTile(float xPos, float zPos)
    {
        GameObject tmpTile = Instantiate(tilePrefab);

        tmpTile.transform.position = new Vector3(xPos, 0, zPos);
        tmpTile.transform.SetParent(tilesHolder);

        tmpTile.name = "Tile " + xPos + " - " + zPos;

        return tmpTile.GetComponent<TileObject>();
    }

    public void SpawnObstacle(float xPos, float zPos)
    {
        bool isWood = Random.value <= 0.5f;

        GameObject spawnedObstacle = null;

        if (isWood)
        {
            spawnedObstacle = Instantiate(woodPrefab);
        }
        else
        {
            spawnedObstacle = Instantiate(rockPrefab);
        }

        spawnedObstacle.transform.position = new Vector3(xPos, tileEndHeight, zPos);
    }
}
