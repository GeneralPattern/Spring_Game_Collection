using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu]
public class IntData : ScriptableObject
{ 
    public int value;
    public new string name;

    public void AddValue(int num)
    {
        value += num;
    }

    public void SetValue(int num)
    {
        value = num;
    }

}