using System.Collections;
using UnityEngine;

public class StarterScene : MonoBehaviour
{
    void Start()
    {
        StartCoroutine("GoingToMenu");
        PlayerPrefs.SetInt("MyVallet", 0);
    }

    IEnumerator GoingToMenu()
    {
        yield return new WaitForSeconds(5f);
        Application.LoadLevel(1);
    }
}
