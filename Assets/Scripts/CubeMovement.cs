using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMovement : MonoBehaviour
{

    public bool isClick = false;
    Quaternion origin;

    private void Start()
    {
        origin = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if(!isClick)
            Inputs();
    }


    void Inputs()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            StopCoroutine("Move");
            StartCoroutine( Move(1, 0));
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            StopCoroutine("Move");
            StartCoroutine(Move(-1, 0));
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            StopCoroutine("Move");
            StartCoroutine(Move(0, 1));
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            StopCoroutine("Move");
            StartCoroutine(Move(0, -1));
        }
    }

    IEnumerator Move(int x, int y)
    {
        float time = 0, timer = 0.3f;
        isClick = true;

        Quaternion startRot = transform.rotation;
        Vector3 startPos = transform.position;

        Quaternion desireRot = Quaternion.identity;
        Vector3 desirePos = Vector3.zero;


        if(x > 0)
        {
            desireRot = transform.rotation * Quaternion.Euler( Vector3.forward * 90);
            desirePos = transform.position - Vector3.right;
        }
        else if(x < 0)
        {
            desireRot = transform.rotation * Quaternion.Euler(Vector3.forward * -90);
            desirePos = transform.position + Vector3.right;
        }

        if (y > 0)
        {
            desireRot = transform.rotation * Quaternion.Euler(Vector3.right * 90);
            desirePos = transform.position + Vector3.forward;
        }
        else if (y < 0)
        {
            desireRot = transform.rotation * Quaternion.Euler(Vector3.right * -90);
            desirePos = transform.position - Vector3.forward;
        }

        while (time <= timer)
        {
            time += Time.deltaTime;

            transform.rotation = Quaternion.Slerp(startRot, desireRot, time / timer);
            transform.position = Vector3.Lerp(startPos, desirePos, time / timer);


            yield return null;
        }

        transform.rotation = origin;
        isClick = false;
    }

}
