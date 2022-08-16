using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLock : MonoBehaviour
{
    [SerializeField]
    private CursorLockMode lockState = CursorLockMode.Locked;

    [SerializeField]
    private bool visible = false;

    void Start()
    {
        Cursor.lockState = lockState;
        Cursor.visible = visible;
    }
}
