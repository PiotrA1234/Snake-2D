using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    private SnakeMovement snakeMovement;                //object of SnakeMovement class to get its component
    public List<bool> clicks;                           // a list where we store game user's requests to turn snake's direction
    void Start()
    {
        clicks = new List<bool>();
        //snakeMovement = GetComponent<SnakeMovement>();
        
    }

    // Update is called once per frame
    void Update()                                                                       
    {

        if (Input.GetKeyDown("right")) {                                            // controls for PC
            clicks.Add(true);
        }
        if (Input.GetKeyDown("left")) {
            clicks.Add(false);
        }
           
          
        if (Input.touchCount > 0)                                                   // controls for phone
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                if (touch.position.x > Screen.width / 2)
                    clicks.Add(true);                                           //add turn right command to list
                if (touch.position.x < Screen.width / 2)
                    clicks.Add(false);                                          //add turn left command to list
            }
        }

    }
}
