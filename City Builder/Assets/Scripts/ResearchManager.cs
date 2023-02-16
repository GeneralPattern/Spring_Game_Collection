using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ResearchManager : MonoBehaviour
{
    public BoolData research;

    public void CompleteResearch()
    {
        research.setTrue();
        research.researchComplete.Invoke();
        Debug.Log("It worked");
    }
}
