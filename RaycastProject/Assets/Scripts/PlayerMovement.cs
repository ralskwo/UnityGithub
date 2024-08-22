using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;  // ������Ʈ�� �̵� �ӵ�
    public float changeDirectionTime = 2f;  // ������ �����ϴ� �ð� ����
    public float rotationSpeed = 5f;  // ȸ�� �ӵ�
    public float positionCheckInterval = 0.1f;  // ��ġ�� Ȯ���ϴ� ����
    public float positionThreshold = 0.005f;  // ��ġ ��ȭ�� �󸶳� �۾ƾ� ������ �ٲ��� �����ϴ� �Ӱ谪
    public float detectionRange = 10f;  // Raycast�� Ž���� ����
    public int numberOfRays = 8;  // �߻��� ������ ����

    private float directionTimer = 0f;
    private float positionTimer = 0f;
    private Vector3 moveDirection;
    private Vector3 lastPosition;
    private bool isChasing = false;
    private Transform targetEnemy;

    void Start()
    {
        ChooseRandomDirection();
        lastPosition = transform.position;
    }

    void Update()
    {
        if (!isChasing)
        {
            directionTimer += Time.deltaTime;
            positionTimer += Time.deltaTime;

            if (directionTimer >= changeDirectionTime)
            {
                ChooseRandomDirection();
                directionTimer = 0f;
            }

            if (positionTimer >= positionCheckInterval)
            {
                CheckPosition();
                positionTimer = 0f;
            }

            DetectEnemy();
        }

        MoveAndRotate();
    }

    void ChooseRandomDirection()
    {
        int randomDirection = Random.Range(0, 4);

        switch (randomDirection)
        {
            case 0:
                moveDirection = Vector3.forward;  // ������ �̵�
                break;
            case 1:
                moveDirection = Vector3.back;  // �ڷ� �̵�
                break;
            case 2:
                moveDirection = Vector3.left;  // �������� �̵�
                break;
            case 3:
                moveDirection = Vector3.right;  // ���������� �̵�
                break;
        }
    }

    void MoveAndRotate()
    {
        if (isChasing && targetEnemy != null)
        {
            moveDirection = (targetEnemy.position - transform.position).normalized;
        }

        transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);

        Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    void CheckPosition()
    {
        float distanceMoved = Vector3.Distance(transform.position, lastPosition);

        if (distanceMoved < positionThreshold)
        {
            ChooseRandomDirection();
        }

        lastPosition = transform.position;
    }

    void DetectEnemy()
    {
        float angleStep = 360f / numberOfRays;

        for (int i = 0; i < numberOfRays; i++)
        {
            float angle = i * angleStep;
            Vector3 direction = Quaternion.Euler(0, angle, 0) * transform.forward;
            Ray ray = new Ray(transform.position, direction);
            RaycastHit hit;

            Debug.DrawRay(transform.position, direction * detectionRange, Color.red);

            if (Physics.Raycast(ray, out hit, detectionRange))
            {
                if (hit.collider.gameObject.name.Contains("Enemy"))
                {
                    Debug.Log("Enemy detected: " + hit.collider.gameObject.name);
                    isChasing = true;
                    targetEnemy = hit.transform;
                    moveDirection = (targetEnemy.position - transform.position).normalized;
                    break;  // ù ��° ���� ã���� ������ �����ϰ� �� �̻� ����ĳ��Ʈ�� ���� ����
                }
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("Enemy"))
        {
            Destroy(collision.gameObject);
            isChasing = false;
            ChooseRandomDirection();  // ���� ������ �� ���� �̵����� ���ư�
        }
    }
}
