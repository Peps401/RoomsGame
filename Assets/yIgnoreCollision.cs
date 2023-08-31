using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yIgnoreCollision : MonoBehaviour
{
    public GameObject secondCharacter;

    private Collider2D ownCollider;
    private Collider2D otherCollider;

    void Start()
    {
        // Get the colliders of both characters
        ownCollider = GetComponent<Collider2D>();
        otherCollider = secondCharacter.GetComponent<Collider2D>();

        // Ignore collision between the two colliders
        Physics2D.IgnoreCollision(ownCollider, otherCollider, true);
    }

}
