using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioClip[] musics;
    [SerializeField] AudioSource playMusic;

    public static AudioManager instance;

    private void Awake()
    {

        if (instance==null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        playMusic.volume = PlayerPrefs.GetFloat("MusicVolume");
        StartCoroutine(PlayMusic());
    }

    IEnumerator PlayMusic()
    {
        for (int i = 0; i < musics.Length; i++)
        {
            playMusic.clip = musics[i];
            playMusic.Play();
            yield return new WaitForSeconds(musics[i].length + 5f);
        }
    }
}
