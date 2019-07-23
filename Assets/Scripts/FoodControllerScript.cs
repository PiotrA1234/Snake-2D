using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FoodControllerScript : MonoBehaviour
{
    public GameObject normalFood;       //gameobject for normal food to assign it from editor
    public GameObject specialFood;      //gameobject for special food to assign it from editor
 
    public static float timer = 0f;       //timer counting real game time           being used in SnakeCollider script
    private float randomSpecialTimer;   //timer between every new specialFood Spawn counted from last one being set to INACTIVE

    public static bool ableToSpawnSpecialFood;        //bool value to decide if we can spawn a specialFood

    public static float timer2 = 0f;               //counter for specialFood lifetime       being used in BlinkingScriptFood script
    public static float randomSpecialTimer2;      //used for specialFood lifetime           being used in BlinkingScriptFood script

    void Start()
    {
      
        float randomPosX = Random.Range(-BackgroundScript.xBackgroundSize / 2 + normalFood.transform.localScale.x, BackgroundScript.xBackgroundSize / 2 - normalFood.transform.localScale.x);
        float randomPosY = Random.Range(-BackgroundScript.yBackgroundSize / 2 + normalFood.transform.localScale.y, BackgroundScript.yBackgroundSize / 2 - normalFood.transform.localScale.y);
        /// <summary>
        // randomize the x and y position for the food in the way to avoid bugs with food stucked in Boundaries around the screen
        ///</summary
        normalFood.transform.position=new Vector2(randomPosX, randomPosY);          //setting position and activating the first food
        normalFood.SetActive(true);
        randomSpecialTimer = Random.Range(4, 8);                       //initializing random timer for first time
    }

    void Update()
    {  
        SpecialFoodDeadTime();
        respawnNormalFood();                            //calling spawning normal food function
        SpecialFoodAvailability();                      //adding the time
        
        if (ableToSpawnSpecialFood == true)             //if time of the main "timer" is >= randomSpecialTimer allow to create specialFood
        {
            
            respawnSpecialFood();
            ableToSpawnSpecialFood = false;                 //disable ableToSpawnSpecialFood after respawning it to let player catch the specialFood if he can!
        }

       
    }


    void respawnSpecialFood() {                             //function to randomize the time for specialfood to respawn and set the objects position and activate it
     
        randomSpecialTimer2 = Random.Range(5, 8);                               //setting actual max lifetime of specialFood
        randomSpecialTimer = Random.Range(5, 8) + randomSpecialTimer2;        //randomize the specialfood spawn time after letting the last specialFood go inactive
            float randomPosX = Random.Range(-BackgroundScript.xBackgroundSize / 2 + normalFood.transform.localScale.x, BackgroundScript.xBackgroundSize / 2 - normalFood.transform.localScale.x);
            float randomPosY = Random.Range(-BackgroundScript.yBackgroundSize / 2 + normalFood.transform.localScale.y, BackgroundScript.yBackgroundSize / 2 - normalFood.transform.localScale.y);
             /// <summary>
             // randomize the x and y position for the food in the way to avoid bugs with food stucked in Boundaries around the screen (we calculate the position of boundaries as max values)
             ///</summary>

            specialFood.gameObject.transform.position = new Vector2(randomPosX, randomPosY);
                                                                                                                //setting position and activating the new food
            if (specialFood.gameObject.transform.position != normalFood.transform.position)             // if statement to never respawn special food on same position as normal food
            {
                 specialFood.SetActive(true);                                   //activating the food on map
                 
            if (BlinkingScriptFood.m_Material)
                BlinkingScriptFood.m_Material.color = BlinkingScriptFood.defaultColor;            //set colour to default when specialFood is ON (in case Blink() left our object in different
                                                                                                   //than default colour
        }


    }
    void SpecialFoodDeadTime() {                //timer for specialFood lifetime
        if (specialFood.activeInHierarchy == true)
        {
            timer2 += Time.deltaTime;
        }
        if (timer2 >= randomSpecialTimer2)
        {
            specialFood.SetActive(false);         //deactivate specialFood after randpmspecialTimer2 time is reached
            timer2 = 0f;                             //reseting the timer to start counting next random specialFood lifetime
        }
    }
    void SpecialFoodAvailability()
    {                                   //timer function to check if specified time passed so we can spawn another special food 
        timer += Time.deltaTime;
        if (timer >= randomSpecialTimer)
        {
                ableToSpawnSpecialFood = true;          //allow respawnSpecialFood() to execute
                timer = 0f;                             //reseting the timer to start counting next random time to spawn a specialfood
        }
    }

    void respawnNormalFood() {                                          //function to respawn normal food
        if (SnakeCollider.foodEatenNormal == true)                    //only respawn new normalfood after last one was eaten
        {

            SnakeCollider.foodEatenNormal = false;                    // change the foodEatenNormal value to false to let it be able to respawn again (because it was eaten)
            float randomPosX = Random.Range(-BackgroundScript.xBackgroundSize / 2 + normalFood.transform.localScale.x, BackgroundScript.xBackgroundSize / 2 - normalFood.transform.localScale.x);
            float randomPosY = Random.Range(-BackgroundScript.yBackgroundSize / 2 + normalFood.transform.localScale.y, BackgroundScript.yBackgroundSize / 2 - normalFood.transform.localScale.y);
            /// <summary>
            // randomize the x and y position for the food in the way to avoid bugs with food stucked in Boundaries around the screen (we calculate the position of boundaries as max values)
            ///</summary>
            normalFood.gameObject.transform.position = new Vector2(randomPosX, randomPosY);     //setting position and activating the new food
            normalFood.SetActive(true);
            

        }
    }
}
