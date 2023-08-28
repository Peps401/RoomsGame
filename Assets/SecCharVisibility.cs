using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecCharVisibility : MonoBehaviour
{
    public GameObject secondCharacter;
    
    // Start is called before the first frame update
    void Update()
    {
        int playerChoice = PlayerPrefs.GetInt("PlayerChoice");
        if(playerChoice == 2){
            secondCharacter.SetActive(true);
        }
        else{
            secondCharacter.SetActive(false);
        }
    }
}
