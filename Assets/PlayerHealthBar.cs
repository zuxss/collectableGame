using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    private Slider slider;
  
    private void Awake()
    {
        slider = GetComponent<Slider>();
       
    }

    public void MaxLifePoints(float maxLifePoints)
    {
        slider.maxValue = maxLifePoints;
    }

    public void ChangeLifePoints(float currentLifePoints)
    {
        slider.value = currentLifePoints;
    }

    public void InitialateHealthBar(float currentLifePoints)
    {
        MaxLifePoints(currentLifePoints);
        ChangeLifePoints(currentLifePoints);
    }
}
