using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public CharacterController characterController;
    public CharacterController secondCharacterController;
    public Countdown countdown;
    public HealthUiController healthUiController;
    public GameOverController gameOverController;
    
    public ShowCollectedHearts showCollectedHearts;

    public int maxTime = 120;
    public float timeDamagePerc = 0.3f;
    public int damageFromTime = 1;

    public int roomsDiscovered = 0;
    public int collectedHearts = 0;

    public bool secondCharacter;

    private List<RoomController> roomControllers;

    public bool newLevelStarted = false;

    void Awake()
    {
        InitializeController();
        int newLevelStartedInt = PlayerPrefs.GetInt("newLevelStarted", 0);
        if(newLevelStartedInt == 1) {
            newLevelStarted = true;
            PlayerPrefs.SetInt("newLevelStarted", 0);
        }
        Debug.Log("NewLvl starter" + newLevelStartedInt);
    }

    void Start()
    {
        bool secondCharacterMovementAllowed = PlayerPrefs.GetInt("PlayerChoice") == 2;
        
        // Allow movement based on player's choice
        characterController.movementAllowed = true;
        secondCharacterController.movementAllowed = secondCharacter && secondCharacterMovementAllowed;
    }

    void InitializeController()
    {
        roomsDiscovered = 1;
        RoomController[] roomControllers = GetComponentsInChildren<RoomController>();
        foreach(RoomController roomController in roomControllers){
            roomController.InitializeController(this);
            roomController.initialVisibility = false;
        }
        countdown.InitializeController(this, maxTime);

        characterController.InitializeController(this, true, healthUiController);
        secondCharacterController.InitializeController(this, true, healthUiController);
        healthUiController.InitializeController(characterController.health);

        gameOverController.InitializeController();

        int playerChoice = PlayerPrefs.GetInt("PlayerChoice");
        if (playerChoice == 2)
        {
            secondCharacter = true;
        }

    }

    public void UpdateHealth(int newValue)
    {
        // Update the health of both characters
        characterController.health = newValue;
        secondCharacterController.health = newValue;

        healthUiController.SetHealth((float)newValue/characterController.maxHealth);
        if(newValue == 0){
            GameLost();
        }
    }

    /*public void NewRoomDiscovered(){
        roomsDiscovered++;
        Debug.Log(roomsDiscovered);
        if(roomsDiscovered>=6){
            //Spawn enemy
            countdown.AllRoomsDiscovered();
        }
    }*/

    public void RoomDiscovered()
    {
       roomsDiscovered++;
       Debug.Log("RoomDiscovered" + roomsDiscovered);

        if (roomsDiscovered >= 7 && !newLevelStarted) // we have one more room
        {
            // Make hearts visible
            countdown.AllRoomsDiscovered();
        }
        else if(roomsDiscovered >= 10)
        {
            countdown.AllRoomsDiscovered();
        }
    }

    public void HeartsCollected(){
        collectedHearts++;

        showCollectedHearts.fill();
        Debug.Log("Eaten" + collectedHearts);

        if (collectedHearts == 2 && !newLevelStarted)
        {
            // Load the next level or trigger next level event
            newLevelStarted = true;
            PlayerPrefs.SetInt("newLevelStarted", 1);
            PlayerPrefs.Save();
            SceneManager.LoadScene("NewLevel");
            Debug.Log("Player collected enough collectibles to progress to the next level!");
        }
        else if(collectedHearts == 4){
            SceneManager.LoadScene("Victory");
        }
    }

    public CharacterController GetCharacterController(){
        return characterController;
    }

    public void GameLost(){
        characterController.movementAllowed = false;
        secondCharacterController.movementAllowed = false;
        gameOverController.Setup();

    }

}
