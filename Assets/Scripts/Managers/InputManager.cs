using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InputManager // I don't want to instantiate this every scene, I just want it to work regardless of wherever it's called from
{
   public static bool ActionButton ()
    {
        
        return Input.GetButtonDown("Action_Button_Xbox");
    }

   public static bool PauseButton()
    {

        return Input.GetButtonDown("Pause_Button");
    }

   public static float mainHorizontal()
   {
        float r = 0;

        r += Input.GetAxis("MainHorizontal_Xbox");
        r += Input.GetAxis("MainHorizontal_Keyboard");
        return Mathf.Clamp(r,-1f, 1f);
   }

    public static float mainVertical()
    {
        float r = 0;

        r += Input.GetAxis("MainVertical_Xbox");
        r += Input.GetAxis("MainVertical_Keyboard");
        return Mathf.Clamp(r, -1f, 1f);
    }
}
