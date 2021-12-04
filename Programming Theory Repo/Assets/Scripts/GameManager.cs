using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int positionInRace; // needs to track position in race
    public bool levelPlaying; // Checks if the player is playing a level
    public bool pause = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && levelPlaying)
        {
            pause = TogglePause();
        }
    }

    public void UpdatePosition()
    {
        // Need to check how to track position in race
        //positionInRace = actualposition; 
    }

    public void UpdateScore()
    {
        // Need to think about the score
    }

    void OnGUI()
    {
        if (pause)
        {
            GUILayout.Label("Game is paused!");
            if (GUILayout.Button("Click me to unpause"))
                pause = TogglePause();
        }

    }

    public void StartLevel()  // When a level is selected this function starts
    {
        levelPlaying = true;
        positionInRace = 0;
        SceneManager.LoadScene("Selected Level"); // check old scripts        
    }

    public void Continue()  // When Continue button is clicked load last played level
    {
        levelPlaying = true;
        positionInRace = 0;
        SceneManager.LoadScene("Selected Level"); // check old scripts        
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LostTheRace()
    {
        //gameOverText.gameObject.SetActive(true);
        //restartButton.gameObject.SetActive(true);
        levelPlaying = false;
    }

    bool TogglePause() // Pause menu should appear. I need to check how this really works
    {
        {
            if (Time.timeScale == 0f)
            {
                Time.timeScale = 1f;
                return (false);
            }
            else
            {
                Time.timeScale = 0f;
                return (true);
            }
        }
    }
}
