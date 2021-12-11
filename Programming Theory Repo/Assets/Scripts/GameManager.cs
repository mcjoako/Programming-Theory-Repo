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
    public GameObject pauseMenu;
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
            pauseMenu.gameObject.SetActive(true);
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

    public void LoadMenu()  // When a level is selected this function starts
    {
        
        SceneManager.LoadScene("Title Screen"); // check old scripts        
    }



    public void StartLevelOne()  // When a level is selected this function starts
    {
        levelPlaying = true;
        
        SceneManager.LoadScene("Level 1"); // check old scripts        
    }

    public void StartLevelTwo()  // When a level is selected this function starts
    {
        levelPlaying = true;
        
        SceneManager.LoadScene("Level 2"); // check old scripts        
    }

    public void StartLevelThree()  // When a level is selected this function starts
    {
        levelPlaying = true;
        
        SceneManager.LoadScene("Level 3"); // check old scripts        
    }

    public void StartLevelFour()  // When a level is selected this function starts
    {
        levelPlaying = true;
        
        SceneManager.LoadScene("Level 4"); // check old scripts        
    }

    public void StartLevelFive()  // When a level is selected this function starts
    {
        levelPlaying = true;
        
        SceneManager.LoadScene("Level 5"); // check old scripts        
    }

    public void StartLevelSix()  // When a level is selected this function starts
    {
        levelPlaying = true;
        
        SceneManager.LoadScene("Level 6"); // check old scripts        
    }

    public void StartLevelSeven()  // When a level is selected this function starts
    {
        levelPlaying = true;
        
        SceneManager.LoadScene("Level 7"); // check old scripts        
    }

    public void StartLevelEight()  // When a level is selected this function starts
    {
        levelPlaying = true;
        
        SceneManager.LoadScene("Level 8"); // check old scripts        
    }

    public void StartLevelNine()  // When a level is selected this function starts
    {
        levelPlaying = true;
        
        SceneManager.LoadScene("Level 9"); // check old scripts        
    }

    public void Continue()  // When Continue button is clicked load last played level
    {
        levelPlaying = true;
        
        SceneManager.LoadScene("Selected Level"); // check old scripts        
    }

    public void ResumeLevel()
    {
        pause = TogglePause();
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
