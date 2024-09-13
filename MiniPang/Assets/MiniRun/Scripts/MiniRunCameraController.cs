using UnityEngine;

public class MiniRunCameraController : MonoBehaviour
{
    public Transform playerTransform;
    public Vector3 offset; // 플레이어와 카메라 간 거리 유지

    void Update()
    {
        // 플레이어의 X축을 따라 카메라 이동, Y와 Z는 고정
        transform.position = new Vector3(playerTransform.position.x + offset.x, offset.y, offset.z);
    }
}
