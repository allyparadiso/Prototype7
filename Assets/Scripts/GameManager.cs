using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }

    private void Start()
    {

    }

    public void WinGame()
    {

    }
}
/*
prompt: simulator + spatial audio + eldritch

eldritch: creepy or eerie
spatial audio: location based audio ?
*/