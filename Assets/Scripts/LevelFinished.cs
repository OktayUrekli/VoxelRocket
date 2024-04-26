using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelFinished : MonoBehaviour
{
    [SerializeField] GameObject successedPanel,fuelBar,canDashImg,stopButton;
    [SerializeField] TextMeshProUGUI collectedCoinText;

    private void Start()
    {
        successedPanel.SetActive(false);
        stopButton.SetActive(true);
    }

    public void LevelSuccessed()
    {
        successedPanel.SetActive(true);
        fuelBar.SetActive(false);
        canDashImg.SetActive(false);
        stopButton.SetActive(false);
        ShowCollectedCoins();
    }


    void ShowCollectedCoins()
    {
        collectedCoinText.text=GameObject.FindGameObjectWithTag("Player").GetComponent<CoinManager>().collectedCoins.ToString();
    }
}
