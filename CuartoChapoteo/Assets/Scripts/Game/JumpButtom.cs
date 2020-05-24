using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class JumpButtom : MonoBehaviour,IPointerUpHandler,IPointerDownHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        if (PlayerJumpScript.instance != null) 
        {
            PlayerJumpScript.instance.givePower(true);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (PlayerJumpScript.instance != null)
        {
            PlayerJumpScript.instance.givePower(false);
        }
    }
}
