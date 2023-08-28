using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillboardController : MonoBehaviour
{
    public Transform cam;
    
    //Called after regular update so it doesnt mess up with main camera
    void LateUpdate()
    {
        //cam.position points it towards camera BUT we wanna make sure to point the whole billboard
        //towards the camera
        //we`ll take our current position n go one unit in the direction that the camera
        // is currently phacing
        transform.LookAt(transform.position + cam.forward);
    }
}
