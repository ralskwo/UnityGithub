using UnityEngine;

public class RaycastExample : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        // 마우스 왼쪽 버튼이 클릭되었는지 확인합니다.
        if (Input.GetMouseButtonDown(0))
        {
            // 카메라에서 마우스 포인터 위치를 기준으로 Ray를 발사합니다.
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // Ray가 충돌한 물체의 정보를 담을 RaycastHit 구조체를 선언합니다.
            RaycastHit hit;

            // Ray를 발사하고 물체와의 충돌 여부를 확인합니다.
            if (Physics.Raycast(ray, out hit, 100f))
            {
                // Ray가 충돌한 물체의 이름을 디버그 콘솔에 출력합니다.
                Debug.Log("Hit Object: " + hit.collider.name);
            }
        }
    }
}