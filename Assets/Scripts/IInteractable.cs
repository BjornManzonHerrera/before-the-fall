public interface IInteractable
{
    string InteractionPrompt { get; }
    
    string GetDescription();
    float InteractionDistance { get; }
    void Interact();
}
