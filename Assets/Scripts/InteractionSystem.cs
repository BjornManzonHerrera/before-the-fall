using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; // Added for the new Input System

public class InteractionSystem : MonoBehaviour
{
    
    public LayerMask interactionLayer;
    public InteractionUI interactionUI;

    private Camera cam;
    private IInteractable currentInteractable;
    private InputSystem_Actions inputActions; // Reference to the new Input Actions

    void Start()
    {
        cam = Camera.main;
        inputActions = new InputSystem_Actions();
        inputActions.Player.Enable(); // Enable the "Player" action map
    }

    void OnDestroy()
    {
        inputActions.Player.Disable(); // Disable the action map when the object is destroyed
    }

    void Update()
    {
        CheckForInteractable();
        
        // Check if an interactable is present and the interact button was pressed this frame
        if (currentInteractable != null && inputActions.Player.Interact.WasPressedThisFrame())
        {
            currentInteractable.Interact();
        }
    }

    void CheckForInteractable()
    {
        if (cam == null)
        {
            return; // Exit if camera is not assigned
        }
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        if (Physics.Raycast(ray, out RaycastHit hit, 100f, interactionLayer))
        {
            if (hit.collider.TryGetComponent(out IInteractable interactable))
            {
                if (Vector3.Distance(transform.position, hit.collider.transform.position) <= interactable.InteractionDistance)
                {
                    // Found an interactable object
                    if (interactable != currentInteractable)
                    {
                        currentInteractable = interactable;
                        interactionUI.Show(currentInteractable.GetDescription());
                    }
                    return; // Exit after finding the first interactable
                }
            }
        }

        // No interactable found in range
        if (currentInteractable != null)
        {
            interactionUI.Hide();
            currentInteractable = null;
        }
    }

    // It's good practice to draw gizmos to visualize the interaction range in the editor.
    private void OnDrawGizmos()
    {
        if (cam != null)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(cam.transform.position, cam.transform.position + cam.transform.forward * 100f);
        }
    }
}
