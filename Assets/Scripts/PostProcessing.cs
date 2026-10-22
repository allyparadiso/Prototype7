using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PostProcessing : MonoBehaviour
{
    public static PostProcessing Instance;
    public Volume volume;
    public VolumeProfile[] volumeProfiles;

    private int currentProfile = 0;
    private Vignette vignette;

    private void Start()
    {
        if (Instance == null) Instance = this;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (volume != null && volumeProfiles.Length > 0)
            {
                currentProfile++;

            }
        }
    }

    void ActivateCurrentProfile()
    {
        
    }
}
//attach to map edges