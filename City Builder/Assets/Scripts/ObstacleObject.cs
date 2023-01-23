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
            AddWoodResource.Invoke();
        }
        if(gameObject.name == "Stone(Clone)")
        {
            AddStoneResource.Invoke();
        }
    }

    public enum ObstacleType
    {
        Wood,
        Rock
    }
}
