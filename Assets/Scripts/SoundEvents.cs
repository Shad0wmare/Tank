using UnityEngine;

public class SoundEvents : MonoBehaviour
{
    public AudioSource idle;
    public AudioSource acceleration;
    public AudioSource shot;    
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            shot.Play();
        }

        if (Input.GetAxis("Vertical") != 0 && !acceleration.isPlaying)
        {
            idle.Stop();
            acceleration.Play();
        }
        else if(Input.GetAxis("Vertical") == 0 && !idle.isPlaying)
        {
            acceleration.Stop();
            idle.Play();
        }
    }
}
