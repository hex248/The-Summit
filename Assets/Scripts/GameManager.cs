using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public CharacterController player;

    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Play")
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayScreen()
    {
        SceneManager.LoadScene("Play");
    }

    public void DeathScreen()
    {
        SceneManager.LoadScene("Death");
    }

    public void StartScreen()
    {
        SceneManager.LoadScene("Start");
    }

    public void WinScreen()
    {
        SceneManager.LoadScene("Win");
    }
}
