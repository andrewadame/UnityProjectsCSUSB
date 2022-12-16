using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource[] soundEffects;

    public static AudioManager instance;

    private void Awake() // Creates an Audio Manager instance
    {
        instance = this;
    }

    public void playSFX(int soundToPlay) // Handles playing a specific sound effect in the array
    {
        soundEffects[soundToPlay].Stop();
        soundEffects[soundToPlay].Play();
    }
}
