using TMPro;
using UnityEngine;

public class CanvasScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI healthText, domeText;




    public void UpdateText(int health, float dome)
    {
        healthText.text = ($"Health: {health}");
        domeText.text = ($"Dome: {dome}");
    }
}
