using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;


public class State
{
    public bool Down = false;
    public bool Up = false;
    public bool Pressed = false;
    public float value = 0;
}


public class VRInputProvider : MonoBehaviour
{

    public State left_grip = new State();
    public State left_trigger = new State();
    public State left_secondaryButton = new State();
    public State left_primaryButton = new State();
    public State left_menubutton = new State();
    public State right_grip = new State();
    public State right_trigger = new State();
    public State right_secondaryButton = new State();
    public State right_primaryButton = new State();

    protected State CalculateState(State prev, bool current)
    {
        State ret = new State();
        if (current && !prev.Down && !prev.Pressed && !prev.Up)
        {
            ret.Down = true;
        }
        if (prev.Down)
        {
            ret.Down = false;
        }
        if (prev.Down && current)
        {
            ret.Pressed = true;
        }
        if (prev.Pressed && current)
        {
            ret.Pressed = true;
        }
        if (prev.Pressed && !current)
        {
            ret.Pressed = false;
            ret.Up = true;
        }
        return ret;
    }

    protected virtual void CalculateControllers()
    {

    }
    void FixedUpdate()
    {
        CalculateControllers();
    }
}
