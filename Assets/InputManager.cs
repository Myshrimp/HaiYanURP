using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager instance;
    private bool disabled=false;
    private void Start()
    {
        instance = this;
    }
    public bool GetKeyA()
    {
        return Input.GetKey(KeyCode.A);
    }
    public bool GetKeyD()
    {
        return Input .GetKey(KeyCode.D);
    }
    public bool GetKeyDownSpace()
    {
        return Input.GetKeyDown(KeyCode.Space);
    }
    public bool GetCrouch()
    {
        return Input.GetKey(KeyCode.LeftControl);
    }
    public bool GetCrouchUp()
    {
        return Input.GetKeyUp(KeyCode.LeftControl);
    }
    public InputManager GetInstance()
    {
        return instance;
    }
    public bool IsDisabled()
    {
        return disabled;
    }
    public void Disable()
    {
        disabled= true;
    }
    public void SetAble()
    {
        disabled = false;
    }
}
