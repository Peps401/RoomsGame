using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameStarter : MonoBehaviour
{
    public TMP_Text messageText;
    public Button okButton;
    public Countdown countdown;
    private bool isGameStarted = false;
    
    private void Start()
    {
        //Show the message and button at the beginning
        messageText.gameObject.SetActive(true);
        okButton.gameObject.SetActive(true);
    }

    public void OkButtonClicked()
    {
        // Hide the message and button when OK is clicked
        messageText.gameObject.SetActive(false);
        okButton.gameObject.SetActive(false);
        
        // Start the clock and show it
        isGameStarted = true;
        countdown.isGameStarted = true;

        // Hide the message and OK button
        gameObject.SetActive(false);

    }

}

