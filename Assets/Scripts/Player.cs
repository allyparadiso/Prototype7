using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public static Player Instance;

    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float gravity = -9.8f;

    [SerializeField] private float lookSensitivity = 0.1f;
    [SerializeField] private float topClamp = 88f;
    [SerializeField] private float bottomClamp = -85f;

    private CharacterController _controller;
    private Vector2 _moveInput;
    private Vector2 _lookInput;

    private float _cinemachineTargetPitch;
    private float _verticalVelocity;

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
    }

    private void Start()
    {
        if (Instance == null) Instance = this;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        Movement();
    }

    private void LateUpdate()
    {
        Rotation();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        _moveInput = context.ReadValue<Vector2>();
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        _lookInput = context.ReadValue<Vector2>();
    }

    void Movement()
    {
        if (_controller.isGrounded && _verticalVelocity < 0)
        {
            _verticalVelocity = -2;
        }

        Vector3 moveDirection = transform.forward * _moveInput.y + transform.right * _moveInput.x;

        _verticalVelocity += gravity * Time.deltaTime;
        moveDirection.y = _verticalVelocity;

        _controller.Move(moveDirection * moveSpeed * Time.deltaTime);
    }

    void Rotation()
    {
        if (_lookInput.sqrMagnitude >= 0.01f)
        {
            _cinemachineTargetPitch -= _lookInput.y * lookSensitivity;
            _cinemachineTargetPitch = Mathf.Clamp(_cinemachineTargetPitch, bottomClamp, topClamp);

            transform.Rotate(Vector3.up * (_lookInput.x + lookSensitivity));
        }
    }
}