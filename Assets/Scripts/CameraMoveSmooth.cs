using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoveSmooth : MonoBehaviour
{
    public Transform A;
    public float speedSmooth;

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, A.position, speedSmooth * Time.deltaTime);
    }
}
