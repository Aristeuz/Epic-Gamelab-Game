using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NumberValue : MonoBehaviour
{
    TextMeshProUGUI valueText;

    void Start()
    {
        valueText = GetComponent<TextMeshProUGUI>();
    }

    public void updateText (float value)
    {
        valueText.text = Mathf.RoundToInt(value * 100) + "%";
    }
}
