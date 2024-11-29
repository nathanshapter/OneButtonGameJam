using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CanvasScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI healthText, domeText, cashText, levelText;

    [SerializeField] GameObject duringGameText, postLevelText, postGameText, preGameText, canvasPlayer;


   [SerializeField] Button retryButton, retry1Button;
    [SerializeField] EnemySpawner spawner;

    PlayerWallet wallet;
    private void Start()
    {
        wallet = FindFirstObjectByType<PlayerWallet>();
    }

    private void Update()
    {
        cashText.text = ($"Cash: {wallet.cash}");
        levelText.text = ($"Current Level: {spawner.currentLevel}");
    }



    public void UpdateText(int health, float dome)
    {
        healthText.text = ($"Health: {health}");
 
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
