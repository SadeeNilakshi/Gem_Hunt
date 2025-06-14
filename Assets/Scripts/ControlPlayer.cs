using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ControlPlayer : MonoBehaviour
{

    public Animator animator;
    public GameObject GameOverText;

    public float moveSpeed = 5f;
    public float jumpForce = 7f;

    private Rigidbody rb;
    private bool isGrounded;
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
     
         
        transform.position += new Vector3(0, 0, 1) * Time.deltaTime * 5;
        animator.SetBool("Run", true);


        if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-1, 0, 0) * Time.deltaTime *5;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(1, 0, 0) * Time.deltaTime *5;
        }
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            animator.SetTrigger("Jumping");
            isGrounded = false;
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            animator.SetBool("HighJump", true);
            transform.position += new Vector3(0, 1.5f, 0) * Time.deltaTime * 5;
            StartCoroutine(ResetHighJumpBool());
        }


    }

    private IEnumerator ResetHighJumpBool()
    {
       
        yield return null;
        animator.SetBool("HighJump", false);
    }


    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
      
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Game Over");

            if (GameOverText != null)
                GameOverText.SetActive(true);

            Time.timeScale = 0;

            FindObjectOfType<GameManager>().GameOver();

            GameOverUIController ui = FindObjectOfType<GameOverUIController>();
            if (ui != null)
            {
                ui.ShowGameOverScreen();
            }
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Gem"))
        {
            Debug.Log("Collected Gem!");
            Destroy(other.gameObject); 
        }
    }


 
}
