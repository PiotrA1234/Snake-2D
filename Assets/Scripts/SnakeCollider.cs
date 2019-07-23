using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// in this class its managed when Snake collides with other objects 
public class SnakeCollider : MonoBehaviour
{

    public static bool foodEatenNormal;               //boolean value used in FoodControllerScript to decide when to respawn new Normal food and add points to player
    public static bool foodEatenSpecial;               //boolean value used in FoodControllerScript to decide when to respawn new Special food and add points to player
    public static int Score = 0;                        //score for calculating purposes
    void OnCollisionEnter2D(Collision2D target)                              //Snake on Collision function
    {
        if (target.gameObject.tag == "Collidable")
        {
            FindObjectOfType<GameControllerScript>().EndGame();
            Destroy(gameObject.transform.parent.gameObject);                //destroy whole snake on collision with a collidable
           
        }
    }
    void OnTriggerEnter2D(Collider2D target)
    {                              //Snake on Trigger function
        if (target.gameObject.tag == "CollectibleNormal")
        {
            Score += 1;
            foodEatenNormal = true;                                         //pass the true value for FoodControllerScript
            target.gameObject.SetActive(false);                           //set state of Fruit Collectible to inactive after "eating it"
            SnakeMovement.canCreateTail = true;                           //pass canCreateTail=true for SnakeMovement script to let it grow by 1 node
        }
        else if (target.gameObject.tag == "CollectibleSpecial")
        {
            Score += 10;
            FoodControllerScript.timer = 0f;                      //reset the FoodControllerScript.timer to avoid situation of instantly respawning a specialfood after eating one
            FoodControllerScript.timer2 = 0f;                       //reset the specialFood lifetime timer
            BlinkingScriptFood.blinkingGotEaten = true;                 //passing for blinkingscriptfood information that the food while blinking, was eaten
            foodEatenSpecial = true;                                        //pass the true value for FoodControllerScript
            target.gameObject.SetActive(false);                           //set state of Fruit Collectible to inactive after "eating it"
            SnakeMovement.canCreateTail = true;                           //pass canCreateTail=true for SnakeMovement script to let it grow by 1 node
        }
    }

}