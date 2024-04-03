using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class TargetController : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private PlayerInput towerCranePlayerInput;

    private InputActionMap _towerCraneActionMap;

    private InputAction _trolleyInputAction;
    private InputAction _hookInputAction;
    private InputAction _jibInputAction;

    private float moveX;
    private float moveY;
    private float moveZ;

    void Start()
    {
        _towerCraneActionMap = towerCranePlayerInput.actions.FindActionMap("TowerCraneAction");

        _trolleyInputAction = _towerCraneActionMap.FindAction("TrolleyMove");
        _hookInputAction = _towerCraneActionMap.FindAction("HookMove");
        _jibInputAction = _towerCraneActionMap.FindAction("JibRotate");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        if (_trolleyInputAction.ReadValue<float>() > 0.5)
        {
            Debug.Log("z");
            moveZ = 0.1f;
        }
        if (_trolleyInputAction.ReadValue<float>() <= 0.5 && _trolleyInputAction.ReadValue<float>() >= -0.5)
        {
            moveZ = 0.0f;
        }
        if (_trolleyInputAction.ReadValue<float>() < -0.5)
        {
            Debug.Log("z");
            moveZ = -0.1f;
        }

        if (_jibInputAction.ReadValue<float>() > 0.5)
        {
            Debug.Log("y");
            moveY = -0.1f;
        }
        if (_jibInputAction.ReadValue<float>() <= 0.5 && _jibInputAction.ReadValue<float>() >= -0.5)
        {
            moveY = 0.0f;
        }
        if (_jibInputAction.ReadValue<float>() < -0.5)
        {
            Debug.Log("y");
            moveY = 0.1f;
        }

        if (_hookInputAction.ReadValue<float>() > 0.5)
        {
            Debug.Log("x");
            moveX = 0.1f;
        }
        if (_hookInputAction.ReadValue<float>() <= 0.5 && _hookInputAction.ReadValue<float>() >= -0.5)
        {
            moveX = 0.0f;
        }
        if (_hookInputAction.ReadValue<float>() < -0.5)
        {
            Debug.Log("x");
            moveX= -0.1f;
        }

        transform.Translate(new Vector3(moveX, moveY, moveZ) * 0.01f);
    }
}
