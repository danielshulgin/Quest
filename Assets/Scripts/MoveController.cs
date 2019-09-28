using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MoveController : MonoBehaviour
{
    public float maxSpeed = 2.0f;
    private Rigidbody2D rigidbody2D;
    void Start()
    {
        rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateSpeed();
    }

    private void FixedUpdate()
    {
        
    }

    private void UpdateSpeed()
    {
        rigidbody2D.velocity = maxSpeed *
                    new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }
}
