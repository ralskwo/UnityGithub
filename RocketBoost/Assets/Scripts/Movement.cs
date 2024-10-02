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

    [SerializeField] EventTrigger leftButtonEventTrigger; // UI ��ư ����
    [SerializeField] EventTrigger rightButtonEventTrigger; // UI ��ư ����

    AudioSource audioSource;

    bool isLeftButtonPressed = false;
    bool isRightButtonPressed = false;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();

        // ���� ��ư �̺�Ʈ �߰� (������ ��)
        AddEventTrigger(leftButtonEventTrigger, EventTriggerType.PointerDown, () => isLeftButtonPressed = true);
        // ���� ��ư �̺�Ʈ �߰� (���� ��)
        AddEventTrigger(leftButtonEventTrigger, EventTriggerType.PointerUp, () => isLeftButtonPressed = false);

        // ������ ��ư �̺�Ʈ �߰� (������ ��)
        AddEventTrigger(rightButtonEventTrigger, EventTriggerType.PointerDown, () => isRightButtonPressed = true);
        // ������ ��ư �̺�Ʈ �߰� (���� ��)
        AddEventTrigger(rightButtonEventTrigger, EventTriggerType.PointerUp, () => isRightButtonPressed = false);
    }

    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {
        // UI ������ ��ġ���� ���� ��쿡�� ��ġ �Է��� ó��
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

    // EventTrigger�� �̺�Ʈ�� �߰��ϴ� �Լ�
    void AddEventTrigger(EventTrigger trigger, EventTriggerType eventType, System.Action action)
    {
        EventTrigger.Entry entry = new EventTrigger.Entry { eventID = eventType };
        entry.callback.AddListener((data) => action());
        trigger.triggers.Add(entry);
    }

    // UI ��� ���� ��ġ�� �ִ��� Ȯ���ϴ� �Լ�
    private bool IsPointerOverUIObject()
    {
        // ���� ���콺 ��ġ�� ��ġ ��ġ�� �������� Raycast�� �����Ͽ� UI ��ҿ� �浹 ���� Ȯ��
        PointerEventData eventData = new PointerEventData(EventSystem.current);
        eventData.position = Input.GetTouch(0).position;

        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);

        return results.Count > 0;
    }
}
