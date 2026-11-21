using UnityEngine;

[CreateAssetMenu(
    fileName = "NewColor",
    menuName = "Game/Colors/New Color"
)]
public class ColorData : ScriptableObject
{
    [Header("Identification")]
    public string colorName;

    [Header("Appearance")]
    public Color color = Color.white;
}
