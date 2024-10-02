using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    [SerializeField] GameObject[] DependenceAndroidPlatform;

    // Start is called before the first frame update
    void Start()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            SetActiveObjects(true);
        }
        else
        {
            SetActiveObjects(false);
        }
    }

    void SetActiveObjects(bool isActive)
    {
        foreach (GameObject obj in DependenceAndroidPlatform)
        {
            if (obj != null)
            {
                obj.SetActive(isActive);
            }
        }
    }

}
