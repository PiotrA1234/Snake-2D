using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Boundaries scripts are made to make sure every boundary is in appropriate position on game start to avoid any bugs

public class BoundariesScriptLeft : MonoBehaviour
{
    Collider2D m_Collider;                              //collider for the boundary to assign its position properly every game start

    void Start()        
    {
        m_Collider = GetComponent<Collider2D>();        //Fetch the Collider from the GameObject
        gameObject.transform.position = new Vector2(-BackgroundScript.xBackgroundSize / 2 - m_Collider.bounds.size.x / 2, 0f);   //set the boundary position properly to the background
    }


    void Update()
    {

    }
}
