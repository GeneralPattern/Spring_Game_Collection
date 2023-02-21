using System.Collections;
using UnityEngine;
using UnityEngine.Events;


public class Timer : MonoBehaviour
{
    public UnityEvent updateTextEvent, completedEvent;

    private float timeLeft;
    private float seconds =  0.01f;
    public BoolData canRun;
    public FloatData timer;

    private float elapsedTime;

    private WaitForSecondsRealtime wfsrtObj;

    private void Start()
    {
        wfsrtObj = new WaitForSecondsRealtime(seconds);
    }

    public void StartTimer(float timer)
    {
        StartCoroutine(UpdateTimer(timer));
    }

    public void StopTimer(float timer)
    {
        StopCoroutine(UpdateTimer(timer));
    }
    
    private void Completed()
    {
        StopCoroutine(UpdateTimer(timer.value));
        completedEvent.Invoke();
    }

    // ReSharper disable Unity.PerformanceAnalysis
    private IEnumerator UpdateTimer(float researchLength)
    {
        canRun.value = true;
        while (canRun.value)
        {
            timeLeft = researchLength;
            elapsedTime += Time.deltaTime;
            timeLeft -= elapsedTime;
            timer.SetValue(timeLeft);
            updateTextEvent.Invoke();
            if (timeLeft <= 0)
            {
                timeLeft = 0;
                timer.SetValue(timeLeft);
                Completed();
                updateTextEvent.Invoke();
                StopTimer(timeLeft);
                canRun.value = false;
            }
            yield return null;
        }
    }
}
