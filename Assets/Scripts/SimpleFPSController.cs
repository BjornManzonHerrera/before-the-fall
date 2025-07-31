using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class SimpleFPSController : MonoBehaviour
{
    [Header("Player Settings")]
    public float walkSpeed = 5f;
    public float sprintSpeed = 10f;
    public float jumpHeight = 1.5f;
    public float lookSpeed = 2f;
    public float gravity = -9.81f;

    [Header("Player Components")]
    [SerializeField] private Camera playerCamera;

    private CharacterController controller;
    private Vector3 playerVelocity;
    private float pitch = 0f;

    private InputSystem_Actions playerActions;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        if (playerCamera == null)
        {
            playerCamera = GetComponentInChildren<Camera>();
        }

        playerActions = new InputSystem_Actions();
        playerActions.Player.Enable();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        HandleMovement();
        HandleJumping();
        HandleLook();
    }

    private void HandleMovement()
    {
        // Check if the sprint button is held down
        bool isSprinting = playerActions.Player.Sprint.ReadValue<float>() > 0;
        float currentSpeed = isSprinting ? sprintSpeed : walkSpeed;

        // Movement
        Vector2 moveInput = playerActions.Player.Move.ReadValue<Vector2>();
        Vector3 move = transform.right * moveInput.x + transform.forward * moveInput.y;
        controller.Move(move * currentSpeed * Time.deltaTime);
    }

    private void HandleJumping()
    {
        // Gravity
        if (controller.isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = -2f;
        }

        // Jumping
        if (playerActions.Player.Jump.WasPressedThisFrame() && controller.isGrounded)
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        playerVelocity.y += gravity * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }

    private void HandleLook()
    {
        // Mouse look
        Vector2 lookInput = playerActions.Player.Look.ReadValue<Vector2>();
        float yaw = lookInput.x * lookSpeed * Time.deltaTime;
        transform.Rotate(Vector3.up, yaw);

        pitch -= lookInput.y * lookSpeed * Time.deltaTime;
        pitch = Mathf.Clamp(pitch, -89f, 89f);
        playerCamera.transform.localRotation = Quaternion.Euler(pitch, 0f, 0f);
    }

    private void OnEnable()
    {
        playerActions?.Player.Enable();
    }

    private void OnDisable()
    {
        playerActions?.Player.Disable();
    }
}