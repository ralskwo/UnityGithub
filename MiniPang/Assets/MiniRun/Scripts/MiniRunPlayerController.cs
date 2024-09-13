using UnityEngine;

public class MiniRunPlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float speed = 5f;
    public float jumpForce = 5f;
    private bool isRunning = false;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (isRunning)
        {
            // 좌우 이동 (X축)
            float moveInput = Input.GetAxis("Horizontal");
            Vector3 movement = new Vector3(moveInput * speed, rb.velocity.y, 0); // Z축 고정
            rb.velocity = movement;

            // 점프
            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                Jump();
            }
        }
    }

    public void StartRunning()
    {
        isRunning = true;
    }

    public void StopRunning()
    {
        isRunning = false;
        rb.velocity = Vector3.zero; // 속도 초기화
    }

    private void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isGrounded = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // 지면에 닿으면 isGrounded를 true로 설정
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
