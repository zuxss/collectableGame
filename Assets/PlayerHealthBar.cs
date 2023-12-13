using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    [SerializeField]  private Slider slider;
    [SerializeField] private PlayerHealth playerHealth;

    private void Start()
    {
        slider = GetComponent<Slider>();
        playerHealth = GameObject.Find("Player").GetComponent<PlayerHealth>();
        InitialateHealthBar(playerHealth.maxLifePoints);
    }

    void Update()
    {
        ChangeLifePoints(playerHealth.currentLifePoints);
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
