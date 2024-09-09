# Unity NavMesh-Based AI Pathfinding Project

---

## 프로젝트 개요

이 프로젝트는 Unity의 **NavMesh**와 **NavMeshAgent**를 활용하여 AI 캐릭터의 경로 탐색을 구현한 예시입니다. AI는 설정된 경유 지점을 순차적으로 이동하며, 실시간 장애물을 회피하고 복잡한 경로를 탐색할 수 있습니다. **NavMeshObstacle**을 사용하여 AI가 동적으로 경로를 재계산하도록 설정하였으며, 게임 환경에서 자연스럽게 움직이는 AI를 구현할 수 있습니다.

---

## 기능

1. **NavMesh 및 NavMeshAgent 통합**:  
   AI 캐릭터는 **NavMesh**를 기반으로 경로를 계산하고, 장애물을 피하면서 목표 지점까지 이동합니다. **NavMeshAgent**는 AI 캐릭터의 이동을 제어하는 중요한 컴포넌트입니다.

2. **동적 장애물 처리**:  
   **NavMeshObstacle**을 사용하여 움직이는 장애물에 대한 경로 재계산 기능을 구현했습니다. AI는 장애물을 만나면 경로를 재탐색하여 새로운 경로를 설정합니다.

3. **경유 지점 설정**:  
   AI는 여러 개의 경유 지점을 순차적으로 이동하며, 각 경유 지점에 도달하면 자동으로 다음 지점으로 이동합니다.

4. **실시간 장애물 대응**:  
   움직이는 장애물에 대한 실시간 반응을 통해 AI 캐릭터가 경로를 동적으로 수정합니다.

---

## 프로젝트 설치 및 실행 방법

1. **프로젝트 클론**:  
   저장소를 클론하거나 다운로드합니다.

2. **Unity에서 프로젝트 열기**:  
   Unity 2022.3.40f1 이상 버전을 사용하여 프로젝트를 엽니다.

3. **NavMesh 설정**:  
   - 씬에 **Plane**을 추가하여 AI가 이동할 경로를 설정합니다.
   - **Window > AI > Navigation**에서 **NavMeshSurface**를 추가하고 **Bake** 버튼을 눌러 NavMesh를 생성합니다.

4. **NavMeshAgent 추가**:  
   AI 캐릭터 (예: Capsule 오브젝트)에 **NavMeshAgent** 컴포넌트를 추가하고, Inspector에서 속도를 조정합니다.

5. **경유 지점 설정**:  
   씬에 여러 개의 **Empty GameObject**를 추가하고, 이를 **경유 지점(waypoints)**으로 설정한 뒤, AI 스크립트에 할당합니다.

---

## 코드 예시

```csharp
using UnityEngine;
using UnityEngine.AI;

public class AIController : MonoBehaviour
{
    public Transform[] waypoints; // 경유 지점들
    private NavMeshAgent agent;
    private int currentWaypointIndex = 0; // 현재 경유 지점 인덱스

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
        if (agent.remainingDistance <= agent.stoppingDistance && !agent.pathPending)
        {
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
            agent.SetDestination(waypoints[currentWaypointIndex].position);
        }
    }
}
```

---

## 실시간 장애물 처리 예시

```csharp
void HandleDynamicObstacle()
{
    if (agent.isPathStale || agent.remainingDistance < 1f)
    {
        agent.SetDestination(waypoints[currentWaypointIndex].position); // 새로운 경로 설정
    }
}
```

---

## 추가 정보
추가 정보
프로젝트에 대한 더 많은 정보와 세부 설명은 이 블로그를 참고하세요.
- https://mayquartet.com/unity-navmesh%eb%a5%bc-%ed%99%9c%ec%9a%a9%ed%95%9c-ai-%ec%ba%90%eb%a6%ad%ed%84%b0-%ea%b2%bd%eb%a1%9c-%ed%83%90%ec%83%89-%ea%b5%ac%ed%98%84-%ea%b0%80%ec%9d%b4%eb%93%9c/

- ---

## 향후 개선 사항

* AI의 더 복잡한 행동 패턴(예: 경비 경로, 추적 행동 등)을 추가할 수 있습니다.
* AI와 장애물 간의 상호작용을 더욱 정교하게 구현할 수 있습니다.
* 다양한 환경에서 AI의 경로 탐색 기능을 확장할 수 있습니다.



