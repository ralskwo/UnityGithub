using UnityEngine;

public class RandomMovement : MonoBehaviour
{
    public float moveSpeed = 5f;  // 오브젝트의 이동 속도
    public float changeDirectionTime = 2f;  // 방향을 변경하는 시간 간격
    public float rotationSpeed = 5f;  // 회전 속도
    public float positionCheckInterval = 0.1f;  // 위치를 확인하는 간격
    public float positionThreshold = 0.01f;  // 위치 변화가 얼마나 작아야 방향을 바꿀지 결정하는 임계값

    private float directionTimer = 0f;
    private float positionTimer = 0f;
    private Vector3 moveDirection;
    private Vector3 lastPosition;

    void Start()
    {
        ChooseRandomDirection();
        lastPosition = transform.position;
    }

    void Update()
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
        // 현재 위치에서 이동 방향으로 이동
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);

        // 오브젝트가 이동하는 방향으로 회전하도록 함
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
}
