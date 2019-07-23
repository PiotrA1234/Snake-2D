using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkingScriptFood : MonoBehaviour
{
    public static SpriteRenderer m_Material;          //spriterenderer object to manage our sprites .color value ( make it blink by setting same color as the background)
    public static Color defaultColor;                   //basic actual colour of specialFood
    private float offset = 0.1f;                            //offset to prevent bugs with timer2 and randomspecialTimer2
    public static bool blinkingGotEaten = false;                 

    void Start()
    {
        m_Material = GetComponent<SpriteRenderer>();
        defaultColor = m_Material.color;                    //getting default colour from specialFood sprite


    }


    void Update()
    {
        InvokeRepeating("Blink", 0.5f * FoodControllerScript.randomSpecialTimer2, 1f);                          //repeating the Blink function
        CancelInvokeOnExpire();
        CancelInvokeOnEat();                                                                                                              //we just stop the blinking
    }

    void Blink()                //blinking function to make specialFood shine in different colours making its cool blinking effect
    {
        m_Material.color = new Color(m_Material.color.r, m_Material.color.b, m_Material.color.g, (m_Material.color.a + .05f) % 1);
    }
    public void CancelInvokeOnEat()                 //if specialfood blinking needs to be stopped after being eated
    {
        if (blinkingGotEaten == true)
        {
            CancelInvoke();
            m_Material.color = defaultColor;
            blinkingGotEaten = false;
        }

    }
    public void CancelInvokeOnExpire()
    {
        if (FoodControllerScript.timer2 >= FoodControllerScript.randomSpecialTimer2 - offset) CancelInvoke();   //if we reach the time that actual food expires because snake didnt eat it}
    }
}
