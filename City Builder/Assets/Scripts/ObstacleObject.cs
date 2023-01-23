using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObstacleObject : MonoBehaviour
{

    public UnityEvent AddWoodResource;
    public UnityEvent AddStoneResource;
    private void OnMouseDown()
    {
        Debug.Log("Clicked on " + gameObject.name);

        if(gameObject.name == "Wood(Clone)")
        {
            Debug.Log("Chopped Wood");
            AddWoodResource.Invoke();
        }
        if(gameObject.name == "Stone(Clone)")
        {
            Debug.Log("Mined Stone");
        }
    }

    public enum ObstacleType
    {
        Wood,
        Rock
    }
}
