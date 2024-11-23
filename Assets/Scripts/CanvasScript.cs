using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CanvasScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI healthText, domeText;

    [SerializeField] GameObject duringGameText, postLevelText, postGameText, preGameText, canvasPlayer;


   [SerializeField] Button retryButton, retry1Button;

   



 

    public void UpdateText(int health, float dome)
    {
        healthText.text = ($"Health: {health}");
        domeText.text = ($"Dome: {dome}");
    }

    void SetAllToFalse()
    {
        duringGameText.SetActive(false);
        postLevelText.SetActive(false);
        postGameText.SetActive(false);
        preGameText.SetActive(false);
        canvasPlayer.SetActive(false);
        retryButton.gameObject.SetActive(false);
        retry1Button.gameObject.SetActive(false);
    }
}
