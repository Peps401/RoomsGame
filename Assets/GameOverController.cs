using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    public void InitializeController(){
        gameObject.SetActive(false);
    }
    
    public void Setup (){
        gameObject.SetActive(true);
    }

    public void RestartButton(){
        SceneManager.LoadScene("Development");
    }

    public void ExitButton(){
        SceneManager.LoadScene("MainMenu");
    }
}
