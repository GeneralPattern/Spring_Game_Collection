using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu]
public class IntData : ScriptableObject
{ 
    public int value;
    public IntData maxValue;
    public new string name;

    public void IncreaseResource(int num)
    {
        if (value < maxValue.value)
        {
            value += num;
            if (value > maxValue.value)
            {
                value = maxValue.value;
            }
        }
        
    }

    public void SetValue(int num)
    {
        value = num;
    }

    public void IncreaseValue(int num)
    {
        value += num;
    }

}