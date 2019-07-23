using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScript : MonoBehaviour       //this script is basically used to tell boundaries scripts where they should be positioned
{
    Collider2D m_Collider;                                  //collider to let script know what is the size of actual background
    public static float xBackgroundSize;
    public static float yBackgroundSize;
    void Awake()            //using Awake with purpose, to tell boundaries scripts their positions before they get initialized in their Start() functions
    {
        
        m_Collider = GetComponent<Collider2D>();                //Fetch the Collider from the GameObject


        xBackgroundSize = m_Collider.bounds.size.x;             //Fetch the size of the Collider volume
        yBackgroundSize = m_Collider.bounds.size.y;             
   
    }

}
