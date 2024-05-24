using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class TriggerBox : MonoBehaviour
{
    [Header("Counter")]
    public int scoreAmount;
    public AudioClip audioClip;

    public void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            // Post error messages for audio
            if (!AudioManager.instance)
                Debug.LogError("AudioManager not defined");
            if (!audioClip)
                Debug.LogError("audioClip not defined");

            // Play Cube(TM) collection sound
            if (!!AudioManager.instance && !!audioClip)
                AudioManager.instance.PlayAudio(audioClip);

            // Post error messages for game
            if (!GameManager.instance)
                Debug.LogError("GameManager not defined");
            
            // Collect the Cube(TM)
            if (!!GameManager.instance) {
                GameManager.instance.ChangeScore(scoreAmount);
                Destroy(gameObject);
            }
        }
    }
    
    public void OnTriggerExit(Collider other) {
        Debug.Log(other.transform.name + " has exited box");
    }
}
