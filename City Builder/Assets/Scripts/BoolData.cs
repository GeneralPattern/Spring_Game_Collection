using UnityEngine;

[CreateAssetMenu (fileName = "Bool Data", menuName = "Data/Bool Data")]
public class BoolData : ScriptableObject
{
    public bool value;


    public void setTrue()
    {
        value = true;
    }

    public void setFalse()
    {
        value = false;
    }
}
