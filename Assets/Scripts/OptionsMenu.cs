using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    [SerializeField] GameObject optionsPanel, levelsPanel;
    [SerializeField] TMP_Dropdown resDropdown;
    

    Resolution[] resolutions;

    private void Start()
    {    
        optionsPanel.SetActive(false);
        levelsPanel.SetActive(false);
        StartingResulations();
    }

    void StartingResulations()
    {
        resolutions = Screen.resolutions;
        resDropdown.ClearOptions();
        List<string> options = new List<string>();

        int currentResolationIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolationIndex = i;
            }
        }
        resDropdown.AddOptions(options);
        resDropdown.value = currentResolationIndex;
        resDropdown.RefreshShownValue();
    }

    public void SetResulation(int resIndex)
    {
        Resolution res = resolutions[resIndex];
        Screen.SetResolution(res.width,res.height,Screen.fullScreen);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullScreen(bool isFull)
    {
        Screen.fullScreen = isFull;
    }

    public void MethodForExitButton()
    {
        Application.Quit();
    }
}
