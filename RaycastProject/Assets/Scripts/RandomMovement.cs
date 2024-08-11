using UnityEngine;

public class RandomMovement : MonoBehaviour
{
    public float moveSpeed = 5f;  // ������Ʈ�� �̵� �ӵ�
    public float changeDirectionTime = 2f;  // ������ �����ϴ� �ð� ����
    public float rotationSpeed = 5f;  // ȸ�� �ӵ�
    public float positionCheckInterval = 0.1f;  // ��ġ�� Ȯ���ϴ� ����
    public float positionThreshold = 0.01f;  // ��ġ ��ȭ�� �󸶳� �۾ƾ� ������ �ٲ��� �����ϴ� �Ӱ谪

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
        // ���� ��ġ���� �̵� �������� �̵�
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);

        // ������Ʈ�� �̵��ϴ� �������� ȸ���ϵ��� ��
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
