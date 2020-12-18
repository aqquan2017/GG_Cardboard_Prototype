using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GazeObject : MonoBehaviour
{
    public bool state = false;
    public UnityEvent eventGaze = new UnityEvent();

    public void SwitchState()
    {
        state = false;
    }

    public void SwitchStateOn()
    {
        state = true;
    }
}
