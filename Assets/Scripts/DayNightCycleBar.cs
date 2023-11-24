using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayNightCycleBar : MonoBehaviour
{
    private Slider slider;
    void Start()
    {
        slider = GetComponent<Slider>();
        
    }

    public void sliderController(int currentCycleIndex)
    {
        slider.value = currentCycleIndex;
 }


    public void dayNightTimeBarInitiate(int currentCycleIndex)
    {
        slider.value = currentCycleIndex;
    }
}


