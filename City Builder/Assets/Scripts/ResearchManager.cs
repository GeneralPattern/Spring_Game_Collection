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

    public void StartResearch()
    {
        
        
    }
    public void CompleteResearch()
    {
        
        research.setTrue();
        researched.Invoke();
    }
}
