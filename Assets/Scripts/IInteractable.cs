public interface IInteractable
{
    string GetInteractionPrompt();
    
    string GetDescription();
    float InteractionDistance { get; }
    void Interact();
}
