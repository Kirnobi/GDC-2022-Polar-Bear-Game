using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Holder : MonoBehaviour
{
    [SerializeField]
    private LineRenderer lineRenderer;

    private bool holding = false;
    private Holdable heldObject;

    public bool isHolding() { return holding; }

    public bool addHolding(Holdable toHold)
    {
        if (holding)
        {
            return false;
        }
        holding = true;
        heldObject = toHold;
        lineRenderer.enabled = true;
        return true;
    }

    public bool removeHolding()
    {
        if (!holding)
        {
            return false;
        }
        if (heldObject.removeHeld())
        {
            // apply force to the object
        }
        holding = false;
        heldObject = null;
        lineRenderer.enabled = false;
        return true;
    }

    // Start is called before the first frame update
    private void Start()
    {
        lineRenderer.enabled = false;
    }

    // Update is called once per frame
    private void Update()
    {
        if (holding)
        {
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, heldObject.gameObject.transform.position);
        }
    }
}
