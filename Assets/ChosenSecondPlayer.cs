using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChosenSecondPlayer : MonoBehaviour
{
    private int playerChoice;
    
    public void ChoosePlayer1()
    {
        playerChoice = 1;
        StartGame();
    }
    public void ChoosePlayer2()
    {
        playerChoice = 2;
        StartGame();
    }

    private void StartGame()
    {
        // Store the player choice using PlayerPrefs
        PlayerPrefs.SetInt("PlayerChoice", playerChoice);
        PlayerPrefs.Save();

        // Load the next scene
        SceneManager.LoadScene("Development"); // Replace with the actual scene name
    }
}
