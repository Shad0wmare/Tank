using UnityEngine;

public class Shooting : MonoBehaviour
{
    private float shellSpeed = 3000f;
    private float recoilSpeed = 15000f;
    public Transform muzzle;
    public GameObject shellPrefab;
    private GameObject shell;
    private Rigidbody shellRb;
    private Rigidbody tankRb;
    public GameObject muzzleFlash;


    private void Start()
    {
        tankRb = GetComponentInParent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shot();            
        }        
    }

    void Shot()
    {        
        shell = Instantiate(shellPrefab, muzzle.position, muzzle.rotation);        
        shellRb = shell.GetComponent<Rigidbody>();        
        Vector3 forward = transform.TransformDirection(Vector3.up);
        
        shellRb.AddForce(forward * shellSpeed);

        muzzleFlash.GetComponent<ParticleSystem>().Play();
        
        tankRb.AddForce(-forward * recoilSpeed);
    }    
}
