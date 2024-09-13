using UnityEngine;

public class MiniRunCameraController : MonoBehaviour
{
    public Transform playerTransform;
    public Vector3 offset; // �÷��̾�� ī�޶� �� �Ÿ� ����

    void Update()
    {
        // �÷��̾��� X���� ���� ī�޶� �̵�, Y�� Z�� ����
        transform.position = new Vector3(playerTransform.position.x + offset.x, offset.y, offset.z);
    }
}
