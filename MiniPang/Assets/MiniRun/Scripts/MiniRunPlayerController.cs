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
            // �¿� �̵� (X��)
            float moveInput = Input.GetAxis("Horizontal");
            Vector3 movement = new Vector3(moveInput * speed, rb.velocity.y, 0); // Z�� ����
            rb.velocity = movement;

            // ����
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
        rb.velocity = Vector3.zero; // �ӵ� �ʱ�ȭ
    }

    private void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isGrounded = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // ���鿡 ������ isGrounded�� true�� ����
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
