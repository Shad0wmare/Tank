using UnityEngine;

public class TurretController : MonoBehaviour
{
    public Transform gun;
    private float turretRotationSpeed = 0.5f;
    private float gunTiltSpeed = 0.25f;
    private float gunMinAngle = -15f;
    private float gunMaxAngle = 5f;
    private float gunAngle = 0f;
          
    void Update()
    {
        TurretMove();     
    }

    void TurretMove()
    {
        float vertical = Input.GetAxis("Mouse Y") * gunTiltSpeed;
        float horizontal = Input.GetAxis("Mouse X") * turretRotationSpeed;

        transform.rotation *= Quaternion.Euler(0, horizontal * turretRotationSpeed, 0);

        gunAngle -= vertical;
        gunAngle = Mathf.Clamp(gunAngle, gunMinAngle, gunMaxAngle);
        gun.localRotation = Quaternion.Euler(gunAngle, 0, 0);
    }
}
