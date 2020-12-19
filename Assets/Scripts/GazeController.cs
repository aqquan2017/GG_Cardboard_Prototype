using UnityEngine;
using UnityEngine.UI;
using WhackAMole;

public class GazeController : MonoBehaviour
{
    [SerializeField] private bool isGaze = false;
    [SerializeField] private bool isDone = false;
    [SerializeField] private float timeLoad = 0.3f;

    private Image img;
    private GameObject curObj;

    void Start()
    {
        img = GetComponentInChildren<Image>();
        ResetGaze();
    }

    public bool IsGaze
    {
        get { return isGaze; }
        set { isGaze = value; }
    }

    private void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit ,10f))
        {
            if (hit.transform.GetComponent<GazeObject>() != null)
            {
                if (!hit.transform.GetComponent<GazeObject>().state)
                {
                    OnRaycastExit();
                    return;
                }
            }
            else
            {
                OnRaycastExit();
                return;
            }

            if (!isGaze && !curObj)
            {
                OnRaycastEnter(hit.transform.gameObject);
            }

            OnRaycastStay(hit.transform.gameObject);
        }
        else
        {
            OnRaycastExit();
        }


        if (isDone)
        {
            //Trigger something
            Trigger();
        }
    }

    public void Trigger()
    {
        print("HIT " + curObj.name);
        GazeObject g = curObj.GetComponent<GazeObject>();

        g.SwitchState();
        g.eventGaze.Invoke();
        isDone = false;
    }

    public void ResetGaze()
    {
        img.fillAmount = 0;
        isGaze = false;

    }

    private void OnRaycastEnter(GameObject cur)
    {
        isGaze = true;
        curObj = cur;
    }

    private void OnRaycastStay(GameObject cur)
    {
        img.fillAmount += Time.deltaTime / timeLoad;
        
        if (img.fillAmount >= 1)
        {
            isDone = true;
            ResetGaze();
        }
        
    }

    private void OnRaycastExit()
    {
        img.fillAmount = 0f;
        isGaze = false;
        curObj = null;
        isDone = false;
    }

}
