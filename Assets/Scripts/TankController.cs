using UnityEngine;

public class TankController : MonoBehaviour
{
    private float force = 1000f;
    private float maxSpeed = 15f;
    private float torque = 5000f;
    private float torqueSpeed = 0.25f;    
    private Rigidbody rb;    

    private void Start()
    {        
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = new Vector3(0, 1.8f, 0);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        if (vertical < 0)
        {
            horizontal = -horizontal;
        }

        rb.AddForce(transform.forward * force * vertical);
        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
        }

        rb.AddTorque(transform.up * torque * horizontal);
        if (rb.angularVelocity.magnitude > torqueSpeed)
        {
            rb.angularVelocity = Vector3.ClampMagnitude(rb.angularVelocity, torqueSpeed);
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed * 0.5f);
        }        
    }
}
