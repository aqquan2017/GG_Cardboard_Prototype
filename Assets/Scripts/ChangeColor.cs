using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    public void ChangeRandomColor()
    {
        Color c = new Color(Get01(), Get01(), Get01());
        GetComponent<Renderer>().material.color = c;
    }

    private float Get01() => Random.Range(0f, 1f);
}
