using UnityEngine;

public class CollisionDetect : MonoBehaviour
{        
    public GameObject impactPrefab;    
    
    private GameObject impactPoint;
    private Vector3 impactPosition;
    private Quaternion impactRotation;
    private ContactPoint contact;
    
    private AudioSource explosionSound;
    private float explosionForce = 300f;
    private float explosionRadius = 7f;
    private float upwardsModifier = 1f;

    void Update()
    {
        Destroy(gameObject, 3f);        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.collider.CompareTag("Gun"))
        {           
            contact = collision.GetContact(0);
            impactPosition = contact.point;            
            impactRotation = Quaternion.identity;

            Impact();

            Destroy(gameObject);
        }        
    }

    void Impact()
    {        
        impactPoint = Instantiate(impactPrefab, impactPosition, impactRotation);
        explosionSound = impactPoint.GetComponentInChildren<AudioSource>();

        Collider[] colliders = Physics.OverlapSphere(impactPosition, explosionRadius);        
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(explosionForce, impactPosition, explosionRadius, upwardsModifier);
            }                
        }
        
        explosionSound.Play();

        Destroy(impactPoint, 5.5f);
    }
}
