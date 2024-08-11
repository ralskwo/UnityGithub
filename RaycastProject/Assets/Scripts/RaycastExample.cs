using UnityEngine;

public class RaycastExample : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        // ���콺 ���� ��ư�� Ŭ���Ǿ����� Ȯ���մϴ�.
        if (Input.GetMouseButtonDown(0))
        {
            // ī�޶󿡼� ���콺 ������ ��ġ�� �������� Ray�� �߻��մϴ�.
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // Ray�� �浹�� ��ü�� ������ ���� RaycastHit ����ü�� �����մϴ�.
            RaycastHit hit;

            // Ray�� �߻��ϰ� ��ü���� �浹 ���θ� Ȯ���մϴ�.
            if (Physics.Raycast(ray, out hit, 100f))
            {
                // Ray�� �浹�� ��ü�� �̸��� ����� �ֿܼ� ����մϴ�.
                Debug.Log("Hit Object: " + hit.collider.name);
            }
        }
    }
}