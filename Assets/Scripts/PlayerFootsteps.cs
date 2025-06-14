using UnityEngine;

public class PlayerFootsteps : MonoBehaviour
{
    public AudioSource footstepAudio;
    public Rigidbody rb;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public float groundDistance = 0.3f;
    public AudioClip footstepClip;
    public float stepRate = 0.5f; 

    private float nextStepTime;

    void Update()
    {
     
        bool isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundLayer);

        bool isMoving = rb.velocity.magnitude > 0.1f;

        if (isGrounded && isMoving && Time.time > nextStepTime)
        {
            footstepAudio.PlayOneShot(footstepClip);
            nextStepTime = Time.time + stepRate;
        }
    }
}

