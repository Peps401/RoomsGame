using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomController : MonoBehaviour
{
    public bool initialVisibility = false;

    private bool isVisible = false;  // Flag to track room visibility   
    private bool wasDiscovered = false; // Flag to track whether the room was previously discovered

    private LevelController levelController;
    
    // Start is called before the first frame update
    public void InitializeController(LevelController levelController)
    {
        this.levelController = levelController;
        gameObject.SetActive(initialVisibility);
        DoorController[] doorControllers = GetComponentsInChildren<DoorController>();
        foreach (DoorController door in doorControllers)
        {
            door.roomController = this;
        }
    }


    public void Toggle(bool state)
    {
        if (!wasDiscovered && state) // Only count if the room wasn't previously discovered and is becoming visible
        {
            wasDiscovered = true;
            isVisible = true;
            gameObject.SetActive(true);
            levelController.RoomDiscovered(); // Notify the level controller that a room is discovered
        }
        else
        {
            isVisible = state;
            gameObject.SetActive(state);
        }
    }

    public bool IsActive(){
        return this.gameObject.activeSelf;
    }
}
