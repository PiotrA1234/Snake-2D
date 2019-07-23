using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMovement : MonoBehaviour
{
    [HideInInspector]
    public PlayerDirection direction;
    

    public float moveSpeed;                   //adjustable from Editor Snake's movement speed

    private float timer = 0f;                 //timer to count time between snake move's
    private float moveLength;                 //how much units we move every node at every timer=moveDelay
    private bool move;                        //bool value to check if we can move (because of timer)

    [SerializeField]
    private GameObject Tail;

    private List<Vector2> deltaPosition;                //store movements available for the snake
    private List<Rigidbody2D> nodes;                    //positions of every snake part


    private Rigidbody2D headBody;               //first child of snakegameobject (head)
    private Rigidbody2D mainBody;               //top game object of our whole snake
    private Transform MyTransform;              //main transform

    private Controls controls;                  //gameObject from Controls class to communicate with SnakeMovement
    public static bool canCreateTail;

    void Start()
    {
        controls = GetComponent<Controls>();
        mainBody = GetComponent<Rigidbody2D>();
        MyTransform = transform;

        timer = 0f;        
        moveLength = 0.5f;    
     
        getSnakeOnList();
        SetMovementBehaviour();
        direction = PlayerDirection.UP;            // at game start set snake facing left side
        
    }


    void Update()                           //every update call we check if its time to move, then check for any input (movement direction change) clicks, then we move
    {
        checkMoveAvailability();
        if (move == true)
        {
            if (canCreateTail == true)
            {
                AddTail();
                canCreateTail = false;
            }
            MovementChange();
            Move();

            move = false;
        }

    }
    void getSnakeOnList() {                                                     
        int childCount = 0;                         //variable to make get correct number of rigidbodies2d on our nodes list
        nodes = new List<Rigidbody2D>();
        childCount = MyTransform.childCount;

        for (int i = 0; i < childCount; i++)
        {
            nodes.Add(MyTransform.GetChild(i).GetComponent<Rigidbody2D>());         //setting up every snake part on a list called nodes
        }
        headBody = nodes[0];                                                    // as we know first child is head, we can assign it there
       
    }

    void Move() {
        
        Vector2 dPosition = deltaPosition[(int)direction];      //direction wanted by player to move the snake, here we transfer the direction where snake should move
        Vector2 parentPosition = headBody.position;             //we move parent position to the head(first) node of our snake for future purpose in for loop
        Vector2 previousPosition;

        mainBody.position = mainBody.position + dPosition;      //applying move to our snake main gameobject
        headBody.position = headBody.position + dPosition;      //move head 

        for (int i = 1; i < nodes.Count; i++) {                //for loop to change position of rest of snake's body
            previousPosition = nodes[i].position;           
            nodes[i].position = parentPosition;              
            parentPosition = previousPosition;          
        }

    }
    void checkMoveAvailability() {          //timer function to check if specified time passed so we can move our snake

        timer += Time.deltaTime;

        if (timer >= 1/moveSpeed) {
            move = true;
            timer = 0f;
        }
    }

 
    void SetMovementBehaviour() {
        deltaPosition = new List<Vector2>();                    // list of available movements for snake
        {
            deltaPosition.Add(new Vector2(-moveLength, 0f));  //left 
            deltaPosition.Add(new Vector2(moveLength, 0f));   //right
            deltaPosition.Add(new Vector2(0f, moveLength));   //up
            deltaPosition.Add(new Vector2(0f, -moveLength));  //down
        }
    }
    void MovementChange() {                                                                                                 //function to change snake's direction
        if ((controls.clicks.Contains(false)) || (controls.clicks.Contains(true)))
        {

            if (direction == PlayerDirection.LEFT)                                                            //if its moving LEFT before we want to change it ///
            {
                if ((controls.clicks[0]) == true)                                                                 //request to turn snake's direction to UP
                {
                    direction = PlayerDirection.UP;
                    controls.clicks.RemoveAt(0);
                }
                else                                                                                               //request to turn snake's direction to DOWN
                {
                    direction = PlayerDirection.DOWN;
                    controls.clicks.RemoveAt(0);
                }
            }
            else if (direction == PlayerDirection.UP)                                                         //if its moving UP before we want to change it ///
            {
                if ((controls.clicks[0]) == true)                                                                 //request to turn snake's direction to RIGHT
                {
                    direction = PlayerDirection.RIGHT;
                    controls.clicks.RemoveAt(0);
                }
                else                                                                                               //request to turn snake's direction to LEFT
                {
                    direction = PlayerDirection.LEFT;
                    controls.clicks.RemoveAt(0);
                }
            }
            else if (direction == PlayerDirection.RIGHT)                                                      //if its moving RIGHT before we want to change it ///
            {

                if ((controls.clicks[0]) == true)                                                                 //request to turn snake's direction to DOWN
                {
                    direction = PlayerDirection.DOWN;
                    controls.clicks.RemoveAt(0);
                }
                else                                                                                               //request to turn snake's direction to UP
                {
                    direction = PlayerDirection.UP;
                    controls.clicks.RemoveAt(0);
                }
            }
            else                                                                                                   //if its moving DOWN before we want to change it ///
            {
                if ((controls.clicks[0]) == true)                                                                 //request to turn snake's direction to LEFT
                {
                    direction = PlayerDirection.LEFT;
                    controls.clicks.RemoveAt(0);
                }
                else                                                                                               //request to turn snake's direction to RIGHT
                {
                    direction = PlayerDirection.RIGHT;
                    controls.clicks.RemoveAt(0);
                }
            }
        }
        }
    void AddTail() {
        Vector2 newTailPosition = new Vector2(nodes[nodes.Count - 1].position.x, nodes[nodes.Count - 1].position.y) ;

        GameObject newTail = Instantiate(Tail, newTailPosition, Quaternion.identity);
        newTail.transform.SetParent(transform, true);
        newTail.tag = "Collidable";
        nodes.Add(newTail.GetComponent<Rigidbody2D>());

            canCreateTail = false;
        //Instantiate(Tail, )
    }
    public enum PlayerDirection             //enums to be able to get right move from SetMovementBehaviour() in Move()
    {
        LEFT = 0,       //move left
        RIGHT = 1,      //move right
        UP = 2,         //move up
        DOWN = 3,       //move down
    }



}
