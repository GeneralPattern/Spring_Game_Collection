using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    [Header("Resources")]
    [Space(10)]

    public int maxWood;
    int wood = 0;

    public int maxStone;
    int stone = 0;

    public int maxPremiumC;
    int premiumC = 0;

    public int maxStandardC;
    int standardC = 0;

    public void AddWood(int amount)
    {
        wood += amount;

    }

    public void AddStone(int amount)
    {
        stone += amount;

    }

    public void AddPremiumC(int amount)
    {
        premiumC += amount;

    }

    public void AddStandardC(int amount)
    {
        standardC += amount;

    }
}
