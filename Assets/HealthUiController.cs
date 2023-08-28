using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HealthUiController : MonoBehaviour
{    
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    public LevelController levelController;

    public void InitializeController(int initHealth){
        slider.minValue = 0;
        int playerChoice = PlayerPrefs.GetInt("PlayerChoice");

        if(playerChoice == 2){
            slider.maxValue = 200;
            initHealth = 200;
        }
        else slider.maxValue = 100;
        SetHealth(initHealth);
    }
    
    public void SetHealth(float newValue){
        if(newValue<0){
            newValue = 0;
        }
        else if(newValue>=200){
            newValue=200;
        }

        Debug.Log("Current health: " + newValue.ToString());

        slider.value = newValue * (slider.maxValue-slider.minValue); 

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

}
