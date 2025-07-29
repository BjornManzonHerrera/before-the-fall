using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class SimpleFPSController : MonoBehaviour
{
    [Header("Player Settings")]
    public float walkSpeed = 5f;
    public float lookSpeed = 2f;
    public float gravity = -9.81f;

    [Header("Player Components")]
    [SerializeField] private Camera playerCamera;

    private CharacterController controller;
    private Vector3 playerVelocity;
    private float pitch = 0f;

    // This assumes you have generated a C# class from your Input Actions asset.
    // If not, right-click the .inputactions asset and select "Create C# Script".
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
        HandleLook();
    }

    private void HandleMovement()
    {
        // Gravity
        if (controller.isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = -2f;
        }

        // Movement
        Vector2 moveInput = playerActions.Player.Move.ReadValue<Vector2>();
        Vector3 move = transform.right * moveInput.x + transform.forward * moveInput.y;
        controller.Move(move * walkSpeed * Time.deltaTime);

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