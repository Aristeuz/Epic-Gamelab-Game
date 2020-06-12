using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NumberValue : MonoBehaviour
{
    TextMeshProUGUI valueText;

    void Awake()
    {
        //Debug.Log("Change Text Start");
        valueText = GetComponent<TextMeshProUGUI>();
    }

    public void updateText(float value)
    {
        //Debug.Log("Change Text");
        valueText.text = Mathf.RoundToInt(value * 100) + "%";
    }
}
