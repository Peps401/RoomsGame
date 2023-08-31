using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class zRoadFinisherController : MonoBehaviour
{
    int collectedHearts;
    public zCarMoving carMovingController;
    // Start is called before the first frame update
    void Start()
    {
        collectedHearts = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (carMovingController.heartsCollected == 3)
        {
            
            SceneManager.LoadScene("Victory");
            Debug.Log("Player collected enough collectibles to progress to the next level!");
        }
    }

}
