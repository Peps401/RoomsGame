using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HeartsController : MonoBehaviour
{
    public GameObject gameObject;

    private bool isCollected = false;

    public LevelController levelController;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.gameObject.tag == "MainCharacter" || collision.gameObject.tag == "SecondCharacter") && !isCollected)
        {
            Collect();
        }
    }

    private void Collect()
    {
        levelController.HeartsCollected();

        isCollected = true;
        Destroy(gameObject); // Hide the collectible object
    }
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

}
