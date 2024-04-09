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
    private InputAction _TriggerAction;

    private float moveX;
    private float moveY;
    private float moveZ;

    private float speed;

    private GameObject Sparks;

    public bool Iswelding;

    void Start()
    {
        Sparks = GameObject.Find("Sparks");

        _towerCraneActionMap = towerCranePlayerInput.actions.FindActionMap("TowerCraneAction");

        _trolleyInputAction = _towerCraneActionMap.FindAction("TrolleyMove");
        _hookInputAction = _towerCraneActionMap.FindAction("HookMove");
        _jibInputAction = _towerCraneActionMap.FindAction("JibRotate");
        _TriggerAction = _towerCraneActionMap.FindAction("Trigger");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_TriggerAction.ReadValue<float>() == 1.0)
        {
            speed = 0.05f;
            Sparks.SetActive(true);
            Iswelding = true;
        }

        if (_TriggerAction.ReadValue<float>() == 0.0)
        {
            speed = 0.1f;
            Sparks.SetActive(false);
            Iswelding = false;
        }

        if (_trolleyInputAction.ReadValue<float>() > 0.5)
        {
            moveZ = speed;
        }
        if (_trolleyInputAction.ReadValue<float>() <= 0.5 && _trolleyInputAction.ReadValue<float>() >= -0.5)
        {
            moveZ = 0.0f;
        }
        if (_trolleyInputAction.ReadValue<float>() < -0.5)
        {
            moveZ = -1.0f * speed;
        }

        if (_jibInputAction.ReadValue<float>() > 0.5)
        {
            moveY = -1.0f * speed;
        }
        if (_jibInputAction.ReadValue<float>() <= 0.5 && _jibInputAction.ReadValue<float>() >= -0.5)
        {
            moveY = 0.0f;
        }
        if (_jibInputAction.ReadValue<float>() < -0.5)
        {
            moveY = speed;
        }

        if (_hookInputAction.ReadValue<float>() > 0.5)
        {
            moveX = speed;
        }
        if (_hookInputAction.ReadValue<float>() <= 0.5 && _hookInputAction.ReadValue<float>() >= -0.5)
        {
            moveX = 0.0f;
        }
        if (_hookInputAction.ReadValue<float>() < -0.5)
        {
            moveX= -1.0f * speed;
        }




        transform.Translate(new Vector3(moveX, moveY, moveZ) * 0.01f);

    }
}
