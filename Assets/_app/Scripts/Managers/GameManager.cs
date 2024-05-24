using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Reference to Game Manager component
    public static GameManager instance;
    // Player Score
    public int playerScore;
    // Display text for player score
    public TMP_Text tmpText;

    void Awake() {
        if (!instance)
            instance = this;
        else
            Destroy(this);
    }

    public void ChangeScore(int scoreAmount) {
        playerScore += scoreAmount;
        if (!!tmpText)
            tmpText.text = $"Player Score: {playerScore}";
    }
}
