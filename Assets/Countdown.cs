using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Countdown : MonoBehaviour
{
    public TMP_Text textBox;

    private LevelController levelController;
    private int timeLeft;
    private int tracker;
    private bool loseHealthTime = false;

    public HeartsController heartsController;
    public HeartsController secondHeartsController;
    public HeartsController thirdHeartsController;
    public HeartsController fourthHeartsController;

    float timePassed = 0.0f;

    public bool isGameOver = false;
    public bool isGameStarted = false;

    public void InitializeController(LevelController levelController, int maxTime)
    {
        this.levelController = levelController;
        timeLeft = maxTime;
    }

    // Start is called before the first frame update
    void Start()
    {
        textBox.text = timeLeft.ToString();
    }

    // Update is called once per frame
    void Update()
    {

        timePassed += Time.deltaTime;
        if(!isGameOver && isGameStarted){
            if (timePassed >= 1.0f)
            {
                timeLeft--;
                timePassed = 0.0f;
                textBox.text = timeLeft.ToString();
            }

            if (loseHealthTime)
            {
                Every5SecLoseHealth();
            }
        }
        if (timeLeft == 0){
            levelController.GameLost();
        }
    }

    public void AllRoomsDiscovered()
    {
        tracker = timeLeft - 5;
        loseHealthTime = true;
        heartsController.gameObject.SetActive(true);
        secondHeartsController.gameObject.SetActive(true);
        if(levelController.newLevelStarted){
            thirdHeartsController.gameObject.SetActive(true);
            fourthHeartsController.gameObject.SetActive(true);
        }
    }

    void Every5SecLoseHealth()
    {
        if (timeLeft == tracker)
        {
            tracker -= 5;
            levelController.GetCharacterController().LoseHealth(10);
        }
    }
}
