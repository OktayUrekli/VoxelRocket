using TMPro;
using UnityEngine;

public class SpaceShopManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI coinVallet;

    private void Start()
    {
        coinVallet.text=PlayerPrefs.GetInt("MyVallet").ToString();
    }
}
