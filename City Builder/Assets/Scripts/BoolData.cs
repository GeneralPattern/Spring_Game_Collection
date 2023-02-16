using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu (fileName = "Bool Data", menuName = "Data/Bool Data")]
public class BoolData : ScriptableObject
{
    public bool value;
    public UnityEvent researchComplete;

    
    public void setTrue()
    {
        value = true;
    }

    public void setFalse()
    {
        value = false;
    }

    public void CompleteResearch()
    {
        value = true;
        researchComplete.Invoke();
        Debug.Log("It worked");
    }
}
