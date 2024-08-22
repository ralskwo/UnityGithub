using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;  // 오브젝트의 이동 속도
    public float changeDirectionTime = 2f;  // 방향을 변경하는 시간 간격
    public float rotationSpeed = 5f;  // 회전 속도
    public float positionCheckInterval = 0.1f;  // 위치를 확인하는 간격
    public float positionThreshold = 0.005f;  // 위치 변화가 얼마나 작아야 방향을 바꿀지 결정하는 임계값
    public float detectionRange = 10f;  // Raycast로 탐지할 범위
    public int numberOfRays = 8;  // 발사할 레이의 개수

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
                moveDirection = Vector3.forward;  // 앞으로 이동
                break;
            case 1:
                moveDirection = Vector3.back;  // 뒤로 이동
                break;
            case 2:
                moveDirection = Vector3.left;  // 왼쪽으로 이동
                break;
            case 3:
                moveDirection = Vector3.right;  // 오른쪽으로 이동
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
                    break;  // 첫 번째 적을 찾으면 추적을 시작하고 더 이상 레이캐스트를 하지 않음
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
            ChooseRandomDirection();  // 적을 제거한 후 랜덤 이동으로 돌아감
        }
    }
}
