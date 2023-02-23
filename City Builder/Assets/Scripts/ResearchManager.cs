using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ResearchManager : MonoBehaviour
{
    public float time = 0.0f;
    public BoolData research;
    public IntData researchLevel;
    public UnityEvent researched;

    public GameObject gameManager;
    
    public void StartResearch()
    {
        
        
    }
    public void CompleteResearch()
    {
        Debug.Log("RESEARCHED");
        research.setTrue();
        researched.Invoke();
    }
}
