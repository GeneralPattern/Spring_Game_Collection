using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class BuildingObject : MonoBehaviour
{
    public UnityEvent AddResourceFromBuilding;
    public Building data;
    
    [Header("Resource Creation")]
    [Space(10)]
    
    public IntData resourceTypeofProduction;
    
    public int resourceRounded = 0;

    public float resource = 0;

    public float resourceLimit = 100;

    public float generationSpeed = 5;

    [Space(10)] 
    public UnityEvent IncreaseMaxium;

    Coroutine buildingBehaviour;

    private void Start()
    {
        if (data.resourceType != Building.ResourceType.Storage || data.resourceType != Building.ResourceType.None)
        {
            buildingBehaviour = StartCoroutine(CreateResource());

            if (data.resourceType == Building.ResourceType.Storage)
            {
                IncreaseMaxium.Invoke();
            }
        }
        
    }

    private void OnMouseDown()
    {
        if (data.resourceType == Building.ResourceType.Storage)
            return;
        
        switch (data.resourceType)
        {
            case Building.ResourceType.Standard:
            {
                if(resourceTypeofProduction.value < resourceTypeofProduction.maxValue.value)
                    resourceTypeofProduction.value += resourceRounded;
                    EmptyResource();
                    if (resourceTypeofProduction.value > resourceTypeofProduction.maxValue.value)
                        resourceTypeofProduction.value = resourceTypeofProduction.maxValue.value;
                
                break;
            }

            case Building.ResourceType.Premium:
            {
                resourceTypeofProduction.value += resourceRounded;
                EmptyResource();
                break;
            }
        }
    }

    private void EmptyResource()
    {
        resource = 0;
    }
    IEnumerator CreateResource()
    {
        while (true)
        {
            if (resource < resourceLimit)
            {
                resource += generationSpeed * Time.deltaTime;
                resourceRounded = Mathf.RoundToInt(resource);
            }
            else
            {
                resource = resourceLimit;
            }
            yield return null;
        }
    }
}
