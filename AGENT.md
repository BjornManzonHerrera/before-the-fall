I'm getting a `NullReferenceException` in my Unity project coming from the `InteractionSystem.cs` script. Here’s the error log:

NullReferenceException: Object reference not set to an instance of an object  
InteractionSystem.CheckForInteractable () (at Assets/Scripts/InteractionSystem.cs:59)  
InteractionSystem.Update () (at Assets/Scripts/InteractionSystem.cs:30)  

NullReferenceException: Object reference not set to an instance of an object  
InteractionSystem.CheckForInteractable () (at Assets/Scripts/InteractionSystem.cs:53)  
InteractionSystem.Update () (at Assets/Scripts/InteractionSystem.cs:30)

Please help me with the following:

1. Review the likely cause of the null reference based on line 53 and 59 of `CheckForInteractable()`.
2. Suggest what variables or references may be missing (e.g. `playerCamera`, `interactionUI`, `currentInteractable`, etc.).
3. Give me debugging steps to determine which object is `null`.
4. Provide instructions to:
   - Add null checks to avoid crashes.
   - Properly assign missing references in the Unity Inspector.
   - Validate that all objects are initialized before use.

The script works partially — interaction with objects functions, but the error suggests something is not set correctly. I want to safely handle or fix this issue.
