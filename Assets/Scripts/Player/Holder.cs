using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Holder : MonoBehaviour
{
    [SerializeField]
    private LineRenderer lineRenderer;
    [SerializeField]
    private float throwScale = 200f;
    [SerializeField]
    private float throwDelay = .25f;

    private bool holding = false;
    private Holdable heldObject;
    private float throwTimer = 0f;

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
        throwTimer = throwDelay;
        return true;
    }

    public bool removeHolding(Vector3 force)
    {
        if (!holding)
        {
            return false;
        }
        if (heldObject.removeHeld())
        {
            heldObject.GetComponent<Rigidbody2D>().AddForce(force);
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
        if (Input.GetMouseButtonDown(0) && holding && throwTimer <= 0)
            removeHolding((Camera.main.ScreenToWorldPoint(Input.mousePosition) - heldObject.transform.position) * throwScale);
        if (holding)
        {
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, heldObject.gameObject.transform.position);
        }
    }

    private void FixedUpdate()
    {
        if (throwTimer > 0)
        {
            throwTimer -= Time.deltaTime;
        }
    }
}
