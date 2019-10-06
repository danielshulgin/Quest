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
        //UpdateRotation();
    }

    private void UpdateSpeed()
    {
        rigidbody2D.velocity = maxSpeed *
                    new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }
    private void UpdateRotation()
    {
        if (Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0)
        {
            float angle = Mathf.Atan2(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal")) * Mathf.Rad2Deg - 90;
            angle = Mathf.Lerp(transform.rotation.z % 360, angle % 360, 0.5f);
            
            transform.rotation = Quaternion.AngleAxis(angle , Vector3.forward);
        }
    }
}
