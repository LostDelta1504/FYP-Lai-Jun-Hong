using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;   // new input system
#endif

public class ResetCharacterScript : MonoBehaviour
{
    [Header("Key")]
    public KeyCode resetKey = KeyCode.R;   // used when legacy input is active

    [Header("Optional checkpoint (override start)")]
    public Transform checkpoint;

    Vector3 _startPos;
    Quaternion _startRot;
    CharacterController _cc;
    Rigidbody _rb;

    void Awake()
    {
        _startPos = transform.position;
        _startRot = transform.rotation;
        _cc = GetComponent<CharacterController>();
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
#if ENABLE_INPUT_SYSTEM
        if (Keyboard.current != null && Keyboard.current.rKey.wasPressedThisFrame)
            ResetNow();
#endif
#if ENABLE_LEGACY_INPUT_MANAGER
        if (Input.GetKeyDown(resetKey))
            ResetNow();
#endif
    }

    public void ResetNow()
    {
        Vector3 pos = checkpoint ? checkpoint.position : _startPos;
        Quaternion rot = checkpoint ? checkpoint.rotation : _startRot;

        if (_rb != null)
        {
            _rb.velocity = Vector3.zero;
            _rb.angularVelocity = Vector3.zero;
            _rb.position = pos;
            _rb.rotation = rot;
        }
        else if (_cc != null)
        {
            _cc.enabled = false;                   // prevent collision issues while teleporting
            transform.SetPositionAndRotation(pos, rot);
            _cc.enabled = true;
        }
        else
        {
            transform.SetPositionAndRotation(pos, rot);
        }

        Debug.Log($"Respawned to {pos}");
    }
}
