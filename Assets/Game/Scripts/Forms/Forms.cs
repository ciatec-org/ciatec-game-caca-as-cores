
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class Forms: MonoBehaviour
{
    [Header("Visual Configuration")]
    [SerializeField] private Sprite sprite;
    [SerializeField] private ColorData colorData;

    private Image img;

    private void Awake()
    {
        img = GetComponent<Image>();
        ApplyConfig();
    }

    private void OnValidate()
    {
        img = GetComponent<Image>();
        ApplyConfig();
    }

    public void Config(Sprite newSprite, ColorData newColor)
    {
        sprite = newSprite;
        colorData = newColor;

        if (img == null)
            img = GetComponent<Image>();

        ApplyConfig();
    }

    private void ApplyConfig()
    {
        if (img == null)
            return;

        if (sprite != null)
            img.sprite = sprite;

        if (colorData != null)
            img.color = colorData.color;
    }
}
