using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum DoorOrientation{Top, Bottom, Left, Right}

public class DoorController : MonoBehaviour
{
    public RoomController roomController;
    public DoorOrientation doorType;
    public DoorController adjacentDoor;
    public float offset = 2.0f;

    public Vector3 GetTeleportPosition(){
        switch (doorType){
            case DoorOrientation.Top:
                return transform.position + Vector3.down * offset;
            case DoorOrientation.Bottom:
                return transform.position + Vector3.up * offset;
            case DoorOrientation.Left:
                return transform.position + Vector3.right * offset;
            case DoorOrientation.Right:
                return transform.position + Vector3.left * offset;
            default:
                return transform.position;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "MainCharacter" || collision.gameObject.tag == "SecondCharacter")
        {
            collision.gameObject.SendMessage("Teleport", adjacentDoor.GetTeleportPosition());
            adjacentDoor.OnEnter();
        }
    }

     void OnEnter(){
        roomController.Toggle(true);
    }
}

