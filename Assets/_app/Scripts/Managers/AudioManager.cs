using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    // AudioSource to play audio
    public AudioSource audioSource;

    // Awake is called once before the first execution of Start after the MonoBehaviour is created
    void Awake() {
        if (!instance)
            instance = this;
        else
            Destroy(this);
    }

    public void PlayAudio(AudioClip audioClip) {
        if (!!audioSource) {
            audioSource.clip = audioClip;
            audioSource.Play();
        }
    }
}
