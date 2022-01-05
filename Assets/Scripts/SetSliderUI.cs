using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetSliderUI : MonoBehaviour
{
    private Text notifyTxt;
    public Slider slider;

    private void Start()
    {
        notifyTxt = GetComponent<Text>();
    }

    public void SetText()
    {
        notifyTxt.text = "Thời gian chơi : " + (int)slider.value;
    }
}
