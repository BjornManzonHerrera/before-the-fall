he interaction system works — when I press `E`, items are picked up and Debug.Log messages confirm it. However, the **interaction UI text does not appear** when I look at interactable objects.

Here’s what I need you to help with:

1. Review the `InteractionSystem.cs` and `InteractionUI.cs` logic.
2. Ensure `InteractionUI.Show(string text)` is being called correctly from `InteractionSystem`.
3. Confirm that a working Canvas and Text (or TMP) component is hooked up properly in the Unity scene.
4. Give me instructions to verify or correct:
   - How the `InteractionUI` script should be attached to the UI Canvas.
   - How the Canvas should be configured (World Space vs Screen Space).
   - Whether there are missing UI references in the Inspector.

Here's a sample Debug.Log output to prove `Interact()` is being called:

Picked up Item3
UnityEngine.Debug:Log (object)
PickupableItem:Interact () (at Assets/Scripts/PickupableItem.cs:11)
InteractionSystem:Update () (at Assets/Scripts/InteractionSystem.cs:35)


The logic works, I just can’t see the text prompt. Please walk me through fixing the UI visibility part.