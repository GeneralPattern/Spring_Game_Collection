using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class TileObject : MonoBehaviour
{
   public Tile data;
   public IntData wood;
   public IntData stone;
   [Header("World Tile Data")]
   [Space(10)]

   public int xPos = 0;
   public int zPos = 0;

   public UnityEvent PlacedBuilding;
   public UnityEvent NotEnoughWood;
   public UnityEvent NotEnoughStone;
   private void OnMouseDown()
   {
      //Debug.Log("Clicked on " + gameObject.name);
      Debug.Log("Touched Tile");
      if (!data.IsOccupied)
      {
         if(GameManager.Instance.buildingToPlace != null)
         {
            if (GameManager.Instance.buildingToPlace.data.woodCost <= wood.value)
            {
               if (GameManager.Instance.buildingToPlace.data.stoneCost <= stone.value)
               {
                  wood.value -= GameManager.Instance.buildingToPlace.data.woodCost;
                  stone.value -= GameManager.Instance.buildingToPlace.data.stoneCost;
                  PlacedBuilding.Invoke();
                  
                  List<TileObject> iteratedTiles = new List<TileObject>();

                  bool canPlaceBuildingAdjacent = true;

                  try
                  {
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
                  }
                  catch (System.IndexOutOfRangeException)
                  {
                     Debug.Log("No tiles to place on");
                     return;
                  }
                  
                  if(canPlaceBuildingAdjacent)
                  {
                     GameManager.Instance.SpawnBuilding(GameManager.Instance.buildingToPlace, iteratedTiles);
                     PlacedBuilding.Invoke();
               
                  }
                  else
                  {
                     Debug.Log("Cannot place building");
                  }
               }
               else
               {
                  Debug.Log("Not enough stone");
                  NotEnoughStone.Invoke();
                  return;
               }
            }
            else
            {
               Debug.Log("Not enough wood");
               NotEnoughWood.Invoke();
               return;
            }
         }
         else
         {
            Debug.Log("Building to place is null");
         }
      }

      
   }
}
