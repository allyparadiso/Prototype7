using UnityEngine;

public class Teleport : MonoBehaviour
{
    public static Teleport Instance;

    public PostProcessing postProcessing;
    public GameManager gameManager;

    public Transform teleportTarget1;
    public Transform teleportTarget2;
    public GameObject player;

    private void Start()
    {
        if (Instance == null) Instance = this;

        postProcessing = PostProcessing.Instance;
        gameManager = GameManager.Instance;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CharacterController controller = other.GetComponent<CharacterController>();
            
            if (controller != null) controller.enabled = false;

            if (player.transform.position.x >= 30)
            {
                player.transform.position = teleportTarget1.transform.position;
            }
            else
            {
                 player.transform.position = teleportTarget2.transform.position;
            }

            if (controller != null) controller.enabled = true;

            postProcessing.numberOfTeleports++;
            postProcessing.ChangeVolumes();
            postProcessing.ChangeAudioClip();
        }
    }
}
