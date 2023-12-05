using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;


public class DayNightCycleController : MonoBehaviour
{
    [SerializeField] private Light2D globalLight;
    [SerializeField] private List<DayNight> dayNightCycles;
    [SerializeField] private DayNightCycleBar dayNightCycleBar;
    public event Action<int> OnCycleChanged;

    public float actualCycleDuration;
    private float cyclePercentage;
    public int currentCycleIndex = 0;
    private int nextCycleIndex = 1;
    public float delayBeforeNextCycle = 0;
    private bool isWaitingForCycleChange = false;
    private int dayNightTimeBar = 1;
  
    private void Start()
    {
        actualCycleDuration = dayNightCycles[currentCycleIndex].cycleDuration;
        UpdateCyclePercentage();
        globalLight.color = dayNightCycles[currentCycleIndex].cycleColor;
        NotifyCycleChanged(currentCycleIndex);
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
        NotifyCycleChanged(currentCycleIndex);
        if (nextCycleIndex >= dayNightCycles.Count)
        {
            nextCycleIndex = 0;
            dayNightTimeBar = 0;
        }
        isWaitingForCycleChange = false;
        actualCycleDuration = dayNightCycles[currentCycleIndex].cycleDuration;
    }

    private void NotifyCycleChanged(int newCycleIndex)
    {
        // Disparar el evento cuando cambie el ciclo
        OnCycleChanged?.Invoke(newCycleIndex);
    }
}

