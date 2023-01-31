using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObstacleObject : MonoBehaviour
{

    public UnityEvent AddWoodResource;
    public UnityEvent AddStoneResource;
    public TileObject refTile;


    private void OnMouseDown()
    {
        //Debug.Log("Clicked on " + gameObject.name);

        if(gameObject.tag == "Wood")
        {
            AddWoodResource.Invoke();
            Destroy(gameObject);
            refTile.data.CleanTile();
        }
        if(gameObject.tag == "Stone")
        {
            AddStoneResource.Invoke();
            Destroy(gameObject);
            refTile.data.CleanTile();
        }
    }

    public void SetTileReference(TileObject obj)
    {
        refTile = obj;
    }

    public enum ObstacleType
    {
        Wood,
        Rock
    }

    
}
