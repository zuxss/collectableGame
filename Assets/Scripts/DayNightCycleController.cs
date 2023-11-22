using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class DayNightCycleController : MonoBehaviour
{
    [SerializeField] private Light2D globalLight;
    [SerializeField] private List<DayNight> dayNightCycles;

    public float actualCycleDuration;
    private float cyclePercentage;
    private int currentCycleIndex = 0;
    private int nextCycleIndex = 1;
    public float delayBeforeNextCycle = 0;
    private bool isWaitingForCycleChange = false;

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
                globalLight.color = Color.Lerp(dayNightCycles[currentCycleIndex].cycleColor, dayNightCycles[nextCycleIndex].cycleColor, Mathf.SmoothStep(0f, 1f, cyclePercentage));
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
        cyclePercentage = Mathf.Clamp01(cyclePercentage); // Ensure the percentage is between 0 and 1
    }

    private IEnumerator ChangeCycleWithDelay()
    {
        isWaitingForCycleChange = true;
        yield return new WaitForSeconds(delayBeforeNextCycle);
        currentCycleIndex = nextCycleIndex;
        nextCycleIndex++;
        if (nextCycleIndex >= dayNightCycles.Count)
        {
            nextCycleIndex = 0;
        }
        isWaitingForCycleChange = false;
        actualCycleDuration = dayNightCycles[currentCycleIndex].cycleDuration;
    }
}

