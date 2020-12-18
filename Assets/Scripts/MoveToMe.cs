using UnityEngine;
using WhackAMole;

public class MoveToMe : MonoBehaviour
{
    private Vector3 v;
    private Quaternion q;

    private void Start()
    {
        v = transform.position + Vector3.up;
        q = transform.rotation;
    }

    public void Move(Transform t)
    {
        Player p = t.gameObject.GetComponent<WhackAMole.Player>();
        if (p)
        {
            if (p.curArrow)
            {
                p.curArrow.gameObject.SetActive(true);
                p.curArrow.GetComponent<GazeObject>().state = true;
            }
        }
        else
        {
            Debug.LogError("ERROR IN UNITY EVENT ? MUST HAVE PLAYER COMPONENT");
        }

        p.curArrow = this;
        gameObject.SetActive(false);

        t.position = v;
        t.rotation = q;
    }
}
