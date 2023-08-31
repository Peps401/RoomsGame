using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class twoPlayerCam : MonoBehaviour
{
    public Camera cameraComponent;
    // Start is called before the first frame update
    void Start()
    {
        cameraComponent = GetComponent<Camera>();
        int playerChoice = PlayerPrefs.GetInt("PlayerChoice");
        if (playerChoice == 2)
        {
            ChangeCameraSize(2);
        }
    }

    public void ChangeCameraSize(float newSize)
    {
        cameraComponent.orthographicSize = newSize;
    }
}
