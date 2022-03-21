using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static Constant;

public class PlayerStatitics : MonoBehaviour
{
    public float MaxStamina;
    public float Strength;
    public float Money;

    public float currentStamina;

    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI strengthText;
    public Slider staminaSlide;

    private void Awake()
    {
        MaxStamina = currentStamina = 300;
        Strength =  100;
        Money =  100;
        staminaSlide.maxValue = MaxStamina;
        DontDestroyOnLoad(this);
    }
    private void Update()
    {
        moneyText.text = Money.ToString();
        strengthText.text = Strength.ToString();
        staminaSlide.value = currentStamina;

        if (currentStamina >0)
        {
            currentStamina -= Time.deltaTime;
        }
        else
        {
            Debug.Log("Oop");
        }
        if (currentStamina <= 10)
        {
            GameObject.Find("Player").GetComponent<PlayerMovement>().OutStamina();
        }
    }
    public void GainSomeThing(string type,float num)
    {
        switch (type)
        {
            case "Money":
                Money += num;
                break;
            case "Strength":
                Strength += num;
                break ;
            case "Stamina":
                currentStamina += num;
                break;
            default:
                break;
        }
    }
    public void RefillStamina()
    {
        currentStamina = MaxStamina;
    }
}
