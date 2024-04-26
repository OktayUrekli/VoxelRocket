using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    AudioSource myAudioSource;

    [SerializeField] ParticleSystem crashVFX, finishVFX;
    [SerializeField] AudioClip crashSFX, startSFX, finishSFX,collectFuelSFX;
    [SerializeField] LevelFinished scriptForSuccessPanel;

    bool started, finished,crashed;
    

    private void Start()
    { 
        myAudioSource = GetComponent<AudioSource>();
        started = false;
        finished = false;
        crashed = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        switch (collision.gameObject.tag)
        {
            case "StartPoint":
                StartSequence();
                break;
            case "FinishPoint":
                FinishSequence();
                break;
            default:
                CrashSequence();
                break;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Fuel"))
        {
            myAudioSource.Stop();
            myAudioSource.PlayOneShot(collectFuelSFX);
            GetComponent<FuelManager>().CollectFuel();
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Coin"))
        {
            gameObject.GetComponent<CoinManager>().ShowCollectedCoins();
            Destroy(other.gameObject);
        }

    }
    void StartSequence()
    {
        if (!started)
        {
            myAudioSource.PlayOneShot(startSFX);
            started = true;
        }
        
    }

    void FinishSequence()
    {
        if (!finished)
        {
            myAudioSource.Stop();
            GetComponent<PlayerMovement>().enabled = false;
            myAudioSource.PlayOneShot(finishSFX);
            finishVFX.Play();
            finished = true;
            UnlockNewLevel();
            scriptForSuccessPanel.LevelSuccessed();
            GetComponent<Rigidbody>().Sleep();
            gameObject.GetComponent<CoinManager>().SaveCollectedCoins();
        }
    }

    void CrashSequence()
    {
        if (!crashed)
        {
            myAudioSource.Stop();
            GetComponent<PlayerMovement>().enabled = false;
            myAudioSource.PlayOneShot(crashSFX);
            crashVFX.Play();
            Invoke("ReloadScene", 1.3f);
            crashed = true;
            GetComponent<Collider>().enabled=false;
            gameObject.GetComponent<CoinManager>().SaveCollectedCoins();
        }
    }

    void UnlockNewLevel()
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex;
        if (currentLevel >= PlayerPrefs.GetInt("levelsUnlocked"))
        {
            PlayerPrefs.SetInt("levelsUnlocked", currentLevel + 1);
        }
    }


    void ReloadScene() { SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); }


   
}
