using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelLoadManager : MonoBehaviour
{

    [SerializeField] int levelCount;
    [SerializeField] Button[] levelButtons;

    int levelsUnlocked;

    void Start()
    {
        levelsUnlocked = PlayerPrefs.GetInt("levelsUnlocked", 1);

        for (int i = 0; i < levelCount; i++) 
        {
            levelButtons[i].interactable = false;
        }
        for (int j = 0; j < 6; j++)
        {
            levelButtons[j].interactable = true;
        }

    }

    public void NewLevelUnlocked()
    {
        if (levelsUnlocked < 7)
        {
            for (int j = 0; j < levelsUnlocked; j++)
            {
                levelButtons[j].interactable = true;

            }
        }
        
    }

    public void LoadLevel(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
    }
}
