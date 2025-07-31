using UnityEngine;
using TMPro; // Import TextMeshPro

public class InteractionUI : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private Canvas uiCanvas;
    [SerializeField] private TextMeshProUGUI interactionText; // Use TextMeshProUGUI

    private void Awake()
    {
        // Ensure we have a canvas to work with
        if (uiCanvas == null)
        {
            uiCanvas = FindFirstObjectByType<Canvas>();
            if (uiCanvas == null)
            {
                // Create a new Canvas if none exists in the scene
                GameObject canvasObj = new GameObject("UI Canvas");
                uiCanvas = canvasObj.AddComponent<Canvas>();
                uiCanvas.renderMode = RenderMode.ScreenSpaceOverlay;
                canvasObj.AddComponent<UnityEngine.UI.CanvasScaler>();
                canvasObj.AddComponent<UnityEngine.UI.GraphicRaycaster>();
            }
        }
    }

    private void Start()
    {
        // If the interaction text is not assigned, create it
        if (interactionText == null)
        {
            interactionText = CreateTMPText("InteractionText", "", 24, TextAlignmentOptions.Center, new Vector2(0, 50));
            interactionText.gameObject.SetActive(false); // Start with the text hidden
        }
    }

    public void Show(string prompt)
    {
        if (interactionText != null)
        {
            interactionText.text = prompt;
            interactionText.gameObject.SetActive(true);
        }
    }

    public void Hide()
    {
        if (interactionText != null)
        {
            interactionText.gameObject.SetActive(false);
        }
    }

    private TextMeshProUGUI CreateTMPText(string name, string text, float fontSize, TextAlignmentOptions alignment, Vector2 position)
    {
        GameObject textObj = new GameObject(name);
        textObj.transform.SetParent(uiCanvas.transform, false); // SetParent with worldPositionStays = false

        TextMeshProUGUI tmpText = textObj.AddComponent<TextMeshProUGUI>();
        tmpText.text = text;
        tmpText.fontSize = fontSize;
        tmpText.alignment = alignment;
        
        // Set RectTransform properties
        RectTransform rectTransform = tmpText.rectTransform;
        rectTransform.anchoredPosition = position;
        rectTransform.sizeDelta = new Vector2(400, 100);

        return tmpText;
    }
}