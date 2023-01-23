using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

[RequireComponent(typeof(Text))]
public class TextLabelBehaviour : MonoBehaviour
{
  private Text label;
  public UnityEvent startEvent;
  public UnityEvent continualUpdate;


  private void Start() 
  {
    label = GetComponent<Text>();
    startEvent.Invoke();
    
  }

  private void Update()
  {
    continualUpdate.Invoke();
  }
  
  public void UpdateLabel(IntData obj)
  {
    label.text = obj.value.ToString();
  }

}
