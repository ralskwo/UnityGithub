using UnityEngine;
using UnityEngine.AI;

public class AIController : MonoBehaviour
{
    public Transform[] waypoints; // 경유 지점들
    private NavMeshAgent agent;
    private int currentWaypointIndex = 0; // 현재 경유 지점 인덱스

    // 움직이는 장애물
    public NavMeshObstacle dynamicObstacle;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        if (waypoints.Length > 0)
        {
            agent.SetDestination(waypoints[currentWaypointIndex].position); // 첫 경유 지점으로 이동
        }
    }

    void Update()
    {
        // 장애물이 경로를 막았는지 확인
        if (dynamicObstacle && dynamicObstacle.gameObject.activeSelf)
        {
            HandleDynamicObstacle();
        }

        // NavMeshAgent가 남은 거리를 계산하여 현재 경유 지점 도착 여부 확인
        if (agent.remainingDistance <= agent.stoppingDistance && !agent.pathPending)
        {
            // 현재 경유 지점에 도착한 경우
            if (currentWaypointIndex < waypoints.Length - 1)
            {
                // 다음 경유 지점으로 이동
                currentWaypointIndex++;
                agent.SetDestination(waypoints[currentWaypointIndex].position);
            }
        }
    }

    void HandleDynamicObstacle()
    {
        // 장애물이 존재할 경우 경로를 다시 계산
        if (agent.isPathStale || agent.remainingDistance < 1f)
        {
            agent.SetDestination(waypoints[currentWaypointIndex].position); // 새로운 경로 설정
        }
    }
}
