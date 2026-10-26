using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;

public class PostProcessing : MonoBehaviour
{
    public static PostProcessing Instance;
    public GameManager gameManager;
    public Teleport teleportScript;

    public AudioSource audioSource;
    public AudioClip clip1;
    public AudioClip clip2;
    public AudioClip clip3;

    //private int numberOfTeleports = 0;
    public Volume volume1;
    public Volume volume2;
    public Volume volume3;

    private Volume currentVolume;

    public int numberOfTeleports = 0;

    private void Start()
    {
        if (Instance == null) Instance = this;
        gameManager = GameManager.Instance;
        teleportScript = Teleport.Instance;

        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.clip = clip1;
        audioSource.loop = true;
        audioSource.Play();

        volume1 = GetComponent<Volume>();
        volume2 = GetComponent<Volume>();
        volume3 = GetComponent<Volume>();

        currentVolume = volume1;
    }

    private void Update()
    {
        if (numberOfTeleports >= 4)
        {
            gameManager.WinGame();
        }
    }

    public void ChangeAudioClip()
    {
        if (numberOfTeleports == 2 || numberOfTeleports == 3)
        {
            if (audioSource.clip == clip1)
            {
                audioSource.Stop();

                audioSource.clip = clip2;
                audioSource.loop = true;
                audioSource.Play();
            }
        }
        else if (numberOfTeleports >= 4)
        {
            if (audioSource.clip == clip2)
            {
                audioSource.Stop();

                audioSource.clip = clip3;
                audioSource.loop = true;
                audioSource.Play();
            }
        }
    }

    public void ChangeVolumes()
    {
        if (currentVolume == volume1 && numberOfTeleports >= 2)
        {
            currentVolume = volume2;
        }
        else if (currentVolume == volume2 && numberOfTeleports >= 4)
        {
            currentVolume = volume3;
        }
    }
}
