using UnityEngine;
using UnityEngine.UI;

public class InteractionUI : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private Canvas uiCanvas;
    [SerializeField] private Text interactionText;

    private void Awake()
    {
        if (uiCanvas == null)
        {
            uiCanvas = FindFirstObjectByType<Canvas>();
        }
    }

    private void Start()
    {
        if (uiCanvas == null)
        {
            // Create a new Canvas if none exists
            GameObject canvasObj = new GameObject("UI Canvas");
            uiCanvas = canvasObj.AddComponent<Canvas>();
            uiCanvas.renderMode = RenderMode.ScreenSpaceOverlay;
            canvasObj.AddComponent<CanvasScaler>();
            canvasObj.AddComponent<GraphicRaycaster>();
        }

        if (interactionText == null)
        {
            interactionText = CreateText("InteractionText", "", 18, TextAnchor.LowerCenter, new Vector2(0, 50));
            interactionText.gameObject.SetActive(false);
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

    private Text CreateText(string name, string text, int fontSize, TextAnchor alignment, Vector2 position)
    {
        GameObject textObj = new GameObject(name);
        textObj.transform.SetParent(uiCanvas.transform);

        Text textComponent = textObj.AddComponent<Text>();
        textComponent.font = Resources.GetBuiltinResource<Font>("LegacyRuntime.ttf");
        textComponent.fontSize = fontSize;
        textComponent.alignment = alignment;
        textComponent.rectTransform.anchoredPosition = position;
        textComponent.rectTransform.sizeDelta = new Vector2(400, 100);

        return textComponent;
    }
}
