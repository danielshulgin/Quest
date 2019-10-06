using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MoveController : MonoBehaviour
{
    public static MoveController instance;

    public float rotationSpeed = 150f;
    public float defaultMaxSpeed = 2.0f;
    [HideInInspector] public float maxSpeed = 2.0f;
    private Rigidbody2D rigidbody2D;

    void Awake() {
        instance = this;
        maxSpeed = defaultMaxSpeed;
    }

    void Start()
    {
        rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateSpeed();
        UpdateRotation();
    }

    private void UpdateSpeed()
    {
        rigidbody2D.velocity = maxSpeed *
                    new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }

    //float maxRotatoin;
    //float targetRadius = 2f;
    //float slowRadius = 60f;
    private void UpdateRotation()
    {
        if (maxSpeed == 0)
            return;

        if (Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0)
        {
            float angle = Mathf.Atan2(Input.GetAxis("Vertical"),
                Input.GetAxis("Horizontal")) * Mathf.Rad2Deg - 90;
            angle = MapAngleToPiRadius(angle);
            float currentAnngle = MapAngleToPiRadius(transform.rotation.z);
            transform.rotation =
            Quaternion.RotateTowards(transform.rotation,
                Quaternion.AngleAxis(angle, Vector3.forward),
                rotationSpeed * Time.deltaTime);
        }
    }

    /// <summary>
    /// [0, 360] -> [-180, 180]
    /// </summary>
    private float MapAngleToPiRadius(float angle)
    {
        angle = (int)angle % 360;
        if (angle > 180) 
        {
            angle -= 360;
        }
        else if (angle < -180)
        {
            angle += 360;
        }
        return angle;
    }
}
