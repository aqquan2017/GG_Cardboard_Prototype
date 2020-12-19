using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoveSmooth : MonoBehaviour
{
    public Transform A;
    public float speedSmooth;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, A.position, speedSmooth * Time.deltaTime);
    }
}
