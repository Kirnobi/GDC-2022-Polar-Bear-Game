using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Holdable : MonoBehaviour
{
    [SerializeField]
    private float bounceForce = 350f;
    [SerializeField]
    private float moveSpeed = 0.1f;

    private Holder holder;
    private Rigidbody2D rb;
    private BoxCollider2D collider2d;
    private bool held = false;

    public bool removeHeld()
    {
        if (!held)
        {
            return false;
        }
        held = false;
        collider2d.enabled = true;
        rb.bodyType = RigidbodyType2D.Dynamic;
        rb.gravityScale = 1;
        return true;
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        holder = GameObject.FindGameObjectWithTag("Holder").GetComponent<Holder>();
        collider2d = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (held)
        {
            if (rb.bodyType == RigidbodyType2D.Kinematic)
            {
                Vector3 toMove = holder.gameObject.transform.position - transform.position;
                // Move proportional to distance
                transform.Translate(toMove * moveSpeed);
            } else if (rb.velocity.y < 0)
            {
                rb.bodyType = RigidbodyType2D.Kinematic;
                rb.gravityScale = 0;
            }
        }
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && !holder.isHolding())
        {
            rb.AddForce(Vector3.up * bounceForce);
            if (holder.addHolding(this))
            {
                held = true;
                collider2d.enabled = false;
            }
        }
    }
}
