using UnityEngine;
using UnityEngine.AI;

public class AIController : MonoBehaviour
{
    public Transform[] waypoints; // ���� ������
    private NavMeshAgent agent;
    private int currentWaypointIndex = 0; // ���� ���� ���� �ε���

    // �����̴� ��ֹ�
    public NavMeshObstacle dynamicObstacle;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        if (waypoints.Length > 0)
        {
            agent.SetDestination(waypoints[currentWaypointIndex].position); // ù ���� �������� �̵�
        }
    }

    void Update()
    {
        // ��ֹ��� ��θ� ���Ҵ��� Ȯ��
        if (dynamicObstacle && dynamicObstacle.gameObject.activeSelf)
        {
            HandleDynamicObstacle();
        }

        // NavMeshAgent�� ���� �Ÿ��� ����Ͽ� ���� ���� ���� ���� ���� Ȯ��
        if (agent.remainingDistance <= agent.stoppingDistance && !agent.pathPending)
        {
            // ���� ���� ������ ������ ���
            if (currentWaypointIndex < waypoints.Length - 1)
            {
                // ���� ���� �������� �̵�
                currentWaypointIndex++;
                agent.SetDestination(waypoints[currentWaypointIndex].position);
            }
        }
    }

    void HandleDynamicObstacle()
    {
        // ��ֹ��� ������ ��� ��θ� �ٽ� ���
        if (agent.isPathStale || agent.remainingDistance < 1f)
        {
            agent.SetDestination(waypoints[currentWaypointIndex].position); // ���ο� ��� ����
        }
    }
}
