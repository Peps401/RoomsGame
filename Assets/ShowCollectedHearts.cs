using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowCollectedHearts : MonoBehaviour
{
    public GameObject firstHeart;
    public GameObject secondHeart;
    public GameObject thirdHeart;
    public GameObject fourthHeart;


    public LevelController levelController;
    public HeartsController heartsController;

    
    // Update is called once per frame
    public void fill()
    {
        Debug.Log("Collected hearts for UI" + levelController.collectedHearts);
        if(levelController.collectedHearts == 1){
            firstHeart.SetActive(true);
        }
        if(levelController.collectedHearts == 2){
            secondHeart.SetActive(true);
        }
        if(levelController.collectedHearts == 3){
            thirdHeart.SetActive(true);
        }
        if(levelController.collectedHearts == 4){
            fourthHeart.SetActive(true);
        }
    }

}
