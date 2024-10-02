using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Movement : MonoBehaviour
{
    Rigidbody rigidBody;
    [SerializeField] float mainThrust = 100f;
    [SerializeField] float rotationThrust = 100f;
    [SerializeField] AudioClip mainEngine;

    [SerializeField] ParticleSystem mainEngineParticle;
    [SerializeField] ParticleSystem leftThrustParticle;
    [SerializeField] ParticleSystem rightThrustParticle;

    [SerializeField] EventTrigger leftButtonEventTrigger; // UI 버튼 연결
    [SerializeField] EventTrigger rightButtonEventTrigger; // UI 버튼 연결

    AudioSource audioSource;

    bool isLeftButtonPressed = false;
    bool isRightButtonPressed = false;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();

        // 왼쪽 버튼 이벤트 추가 (눌렀을 때)
        AddEventTrigger(leftButtonEventTrigger, EventTriggerType.PointerDown, () => isLeftButtonPressed = true);
        // 왼쪽 버튼 이벤트 추가 (뗐을 때)
        AddEventTrigger(leftButtonEventTrigger, EventTriggerType.PointerUp, () => isLeftButtonPressed = false);

        // 오른쪽 버튼 이벤트 추가 (눌렀을 때)
        AddEventTrigger(rightButtonEventTrigger, EventTriggerType.PointerDown, () => isRightButtonPressed = true);
        // 오른쪽 버튼 이벤트 추가 (뗐을 때)
        AddEventTrigger(rightButtonEventTrigger, EventTriggerType.PointerUp, () => isRightButtonPressed = false);
    }

    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {
        // UI 영역을 터치하지 않은 경우에만 터치 입력을 처리
        if (Input.GetKey(KeyCode.Space) || (Input.touchCount > 0 && !IsPointerOverUIObject()))
        {
            StartThrusting();
        }
        else
        {
            StopThrusting();
        }
    }

    private void StartThrusting()
    {
        rigidBody.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(mainEngine);
        }

        if (!mainEngineParticle.isPlaying)
        {
            mainEngineParticle.Play();
        }
    }

    private void StopThrusting()
    {
        audioSource.Stop();
        mainEngineParticle.Stop();
    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A) || isLeftButtonPressed)
        {
            RotateLeft();
        }
        else if (Input.GetKey(KeyCode.D) || isRightButtonPressed)
        {
            RotateRight();
        }
        else
        {
            StopRotating();
        }
    }

    private void RotateLeft()
    {
        ApplyRotation(Vector3.forward);

        if (!rightThrustParticle.isPlaying)
        {
            rightThrustParticle.Play();
        }
    }

    private void RotateRight()
    {
        ApplyRotation(Vector3.back);

        if (!leftThrustParticle.isPlaying)
        {
            leftThrustParticle.Play();
        }
    }

    private void StopRotating()
    {
        rightThrustParticle.Stop();
        leftThrustParticle.Stop();
    }

    void ApplyRotation(Vector3 dir)
    {
        rigidBody.freezeRotation = true;
        transform.Rotate(dir * rotationThrust * Time.deltaTime);
        rigidBody.freezeRotation = false;
    }

    // EventTrigger에 이벤트를 추가하는 함수
    void AddEventTrigger(EventTrigger trigger, EventTriggerType eventType, System.Action action)
    {
        EventTrigger.Entry entry = new EventTrigger.Entry { eventID = eventType };
        entry.callback.AddListener((data) => action());
        trigger.triggers.Add(entry);
    }

    // UI 요소 위에 터치가 있는지 확인하는 함수
    private bool IsPointerOverUIObject()
    {
        // 현재 마우스 위치나 터치 위치를 기준으로 Raycast를 실행하여 UI 요소와 충돌 여부 확인
        PointerEventData eventData = new PointerEventData(EventSystem.current);
        eventData.position = Input.GetTouch(0).position;

        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);

        return results.Count > 0;
    }
}
