using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawController : MonoBehaviour
{
    private int damage = 20;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "MainCharacter" || collision.gameObject.tag == "SecondCharacter")
        {
            collision.gameObject.SendMessage("LoseHealth", damage);
            
        }
    }

}
