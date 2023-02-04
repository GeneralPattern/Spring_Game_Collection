using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileObject : MonoBehaviour
{
   public Tile data;

   [Header("World Tile Data")]
   [Space(10)]

   public int xPos = 0;
   public int zPos = 0;

   private void OnMouseDown()
   {
      //Debug.Log("Clicked on " + gameObject.name);

      if (!data.IsOccupied)
      {
         if(GameManager.Instance.buildingToPlace != null)
         {

            List<TileObject> iteratedTiles = new List<TileObject>();

            bool canPlaceBuildingAdjacent = true;

            for(int x = xPos; x < xPos + GameManager.Instance.buildingToPlace.data.width; x++)
            {
               
               if(canPlaceBuildingAdjacent)
               {
                  for(int z = zPos; z < zPos + GameManager.Instance.buildingToPlace.data.length; z++)
                  {

                     iteratedTiles.Add(GameManager.Instance.tileGrid[x,z]);

                     if (GameManager.Instance.tileGrid[x,z].data.IsOccupied)
                     {
                        canPlaceBuildingAdjacent = false;
                        break;
                     }
                  }
               }
               else
               {
                  break;
               }
            }

            if(canPlaceBuildingAdjacent)
            {
               GameManager.Instance.SpawnBuilding(GameManager.Instance.buildingToPlace, iteratedTiles);
            }
            else
            {
               Debug.Log("Cannot place building");
            }

            
         }
         else
         {
            Debug.Log("Building to place is null");
         }
      }

      
   }
}
