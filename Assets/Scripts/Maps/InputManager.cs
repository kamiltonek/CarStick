using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : Singleton<InputManager>
{
    private bool breakIsPreessed;
    private bool gasIsPressed;

    private bool start;

    public void Gas()
    {
        if (!start)
        {
            start = true;
        }
        gasIsPressed = true;
    }

    public void Break()
    {
        if (start)
        {
            breakIsPreessed = true;
        }
    }

    public void NeutralAfterBreak()
    {
        breakIsPreessed = false;
    }

    public void NeutralAfterGas()
    {
        gasIsPressed = false;
    }

    public bool BreakIsPreessed { get => breakIsPreessed; }
    public bool GasIsPressed { get => gasIsPressed; }
}
