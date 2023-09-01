using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterController : MonoBehaviour
{
    public float speed = 4.0f;
    public int health = 100;
    public int maxHealth = 100; 

    private LevelController levelController;
    public HealthUiController healthUiController;

    public bool movementAllowed = false;

    private new Rigidbody2D rigidbody2D;
    public bool secondCharacter = false;

    private Vector2 currentMoveDirection = new Vector2(0.0f, 0.0f);
    

    public void InitializeController(LevelController levelController, bool initMovementAllowed,  HealthUiController sharedHealthUiController){
        this.levelController = levelController;
        movementAllowed = initMovementAllowed;
        rigidbody2D = GetComponent<Rigidbody2D>();

        healthUiController = sharedHealthUiController;

        int playerChoice = PlayerPrefs.GetInt("PlayerChoice");

        if(playerChoice == 2){
            maxHealth = 200;
            health = maxHealth;
        }
        else {
            maxHealth = 100;
            health = maxHealth;
        }

    }



     private void Update()
    {
        int playerChoice = PlayerPrefs.GetInt("PlayerChoice");

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainMenu");
        }

        if(playerChoice == 2){
            secondCharacter = true;
        }

        if (gameObject.CompareTag("MainCharacter"))
        {
            MovePlayer1();
        }
        else if (gameObject.CompareTag("SecondCharacter"))
        {
            MovePlayer2();
        }


    }

     private void MovePlayer1()
    {
        movementAllowed = true;
        if (movementAllowed)
        {
            Vector2 moveDirection = new Vector2(0.0f, 0.0f);
            if (Input.GetKey(KeyCode.D))
            {
                moveDirection = new Vector2(1.0f, moveDirection.y);
            }
            if (Input.GetKey(KeyCode.A))
            {
                moveDirection = new Vector2(-1.0f, moveDirection.y);
            }
            if (Input.GetKey(KeyCode.S))
            {
                moveDirection = new Vector2(moveDirection.x, -1.0f);
            }
            if (Input.GetKey(KeyCode.W))
            {
                moveDirection = new Vector2(moveDirection.x, 1.0f);
            }

            if (moveDirection != currentMoveDirection)
            {
                currentMoveDirection = moveDirection;
                rigidbody2D.velocity = moveDirection;
            }
        }
    }

    private void MovePlayer2()
    {
        Vector2 moveDirection = new Vector2(0.0f, 0.0f);
        
        if (secondCharacter && movementAllowed)
        {
                if (Input.GetKey(KeyCode.RightArrow))
                {
                    moveDirection = new Vector2(1.0f, moveDirection.y);
                }
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    moveDirection = new Vector2(-1.0f, moveDirection.y);
                }
                if (Input.GetKey(KeyCode.DownArrow))
                {
                    moveDirection = new Vector2(moveDirection.x, -1.0f);
                }
                if (Input.GetKey(KeyCode.UpArrow))
                {
                    moveDirection = new Vector2(moveDirection.x, 1.0f);
                }

                if (moveDirection != currentMoveDirection)
                {
                    currentMoveDirection = moveDirection;
                    rigidbody2D.velocity = moveDirection;
                }
        }
    }

    public void Teleport(Vector3 newPosition)
    {
        this.transform.position = newPosition;
    }

    public void LoseHealth(int healthToLose)
    {
        health -= healthToLose;
        levelController.UpdateHealth(health);
    }
}
