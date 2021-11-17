using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public CharacterController player;
    
    void Update()
    {
        scoreText.text = $"Score: {player.score}";
    }
}
