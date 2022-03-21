using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ManageStatGUI : MonoBehaviour
{
    public PlayerData playerData;
    public TextMeshProUGUI money;
    public Slider stamina;
    public TextMeshProUGUI strength;

    // Start is called before the first frame update
    void Start()
    {
        try
        {
            stamina.maxValue = playerData.Stamina.BaseValue;
        }
        catch (Exception e)
        {
            Debug.Log(playerData.Stamina.BaseValue);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void FixedUpdate()
    {
        try
        {

            money.text = playerData.Money.Value.ToString();
            strength.text = playerData.Strength.Value.ToString();
            stamina.value = (float)playerData.Stamina.Value;
        }catch
        {
            return;
        }
    }
}
