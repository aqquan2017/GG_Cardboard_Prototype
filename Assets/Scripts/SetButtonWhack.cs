using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using WhackAMole;

public class SetButtonWhack : MonoBehaviour
{
    [SerializeField] Button btnClick;
    [SerializeField] Slider slider;

    public GameController gameControllerWhack;

    void Start()
    {
        btnClick = GetComponent<Button>();
        btnClick.onClick.AddListener(() => gameControllerWhack.SetGameTimer(slider.value));
    }
}
