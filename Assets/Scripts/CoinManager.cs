using TMPro;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    [SerializeField] AudioClip coinSFX;
    [SerializeField] TextMeshProUGUI coinText;
    AudioSource myAudioSource;
    public int collectedCoins;
    int vallet=0;

    private void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
        collectedCoins = 0;
        coinText.text = collectedCoins.ToString();
    }


    public void ShowCollectedCoins()
    {
        myAudioSource.PlayOneShot(coinSFX);
        collectedCoins += 10;
        coinText.text= collectedCoins.ToString();
    }

    public void SaveCollectedCoins()
    {
        vallet = PlayerPrefs.GetInt("MyVallet");
        vallet += collectedCoins;
        PlayerPrefs.SetInt("MyVallet",vallet);
    }
}
