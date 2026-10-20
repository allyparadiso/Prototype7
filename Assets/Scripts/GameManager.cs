using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }
}
/*
prompt: simulator + spatial audio + eldritch

idea: player is the eldritch monster hunting people

eldritch: creepy or eerie
spatial audio: location based audio ?
*/