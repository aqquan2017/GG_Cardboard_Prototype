using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchBtn : MonoBehaviour
{
    public Material trigger;
    public Material nottrigger;
    [SerializeField] GazeObject gaze;
    private MeshRenderer render;

    void Start()
    {
        gaze = GetComponent<GazeObject>();
        render = GetComponent<MeshRenderer>();
        SetMaterial();
    }

    public void SetMaterial()
    {
        render.material = gaze.state ? trigger : nottrigger;
    }
}
