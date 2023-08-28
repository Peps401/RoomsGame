using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public Vector3 velocity = Vector3.zero;

    public Camera cameraComponent;

    [Range(0,1)]
    public float smoothTime;

    public Vector3 positionOffset = new Vector3(0,0, -10);

    private void Awake(){
        player = GameObject.FindGameObjectWithTag("MainCharacter").transform;

        cameraComponent = GetComponent<Camera>();
        int playerChoice = PlayerPrefs.GetInt("PlayerChoice");
        if (playerChoice == 2)
        {
            ChangeCameraSize(2);
        }
    }
    
    private void LateUpdate(){
        Vector3 targetPosition = player.position + positionOffset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }

    public void ChangeCameraSize(float newSize)
    {
        cameraComponent.orthographicSize = newSize;
    }
}
