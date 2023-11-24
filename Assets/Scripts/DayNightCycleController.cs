using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class DayNightCycleController : MonoBehaviour
{
    [SerializeField] private Light2D globalLight;
    [SerializeField] private List<DayNight> dayNightCycles;
    [SerializeField] private DayNightCycleBar dayNightCycleBar;

    public float actualCycleDuration;
    private float cyclePercentage;
    private int currentCycleIndex = 0;
    private int nextCycleIndex = 1;
    public float delayBeforeNextCycle = 0;
    private bool isWaitingForCycleChange = false;
    private int dayNightTimeBar = 1;
    public Gradient gradient;
    private void Start()
    {
        actualCycleDuration = dayNightCycles[currentCycleIndex].cycleDuration;
        UpdateCyclePercentage();
        globalLight.color = dayNightCycles[currentCycleIndex].cycleColor;
    }

    private void Update()
    {
       
        if (!isWaitingForCycleChange)
        {
            if (actualCycleDuration > 0)
            {
                actualCycleDuration -= Time.deltaTime;
                UpdateCyclePercentage();
                globalLight.color = Color.Lerp(dayNightCycles[currentCycleIndex].cycleColor, dayNightCycles[nextCycleIndex].cycleColor, cyclePercentage);
               dayNightCycleBar.sliderController(dayNightTimeBar);
            }

            else
            {
                
                StartCoroutine(ChangeCycleWithDelay());
                
            }
            
        }
    }

    private void UpdateCyclePercentage()
    {
        cyclePercentage = 1 - (actualCycleDuration / dayNightCycles[currentCycleIndex].cycleDuration);
       
    }

    private IEnumerator ChangeCycleWithDelay()
    {
        isWaitingForCycleChange = true;
        yield return new WaitForSeconds(delayBeforeNextCycle);
        currentCycleIndex = nextCycleIndex;
        nextCycleIndex++;
        dayNightTimeBar++;
        if (nextCycleIndex >= dayNightCycles.Count)
        {
            nextCycleIndex = 0;
            dayNightTimeBar = 0;
        }
        isWaitingForCycleChange = false;
        actualCycleDuration = dayNightCycles[currentCycleIndex].cycleDuration;
    }
}

