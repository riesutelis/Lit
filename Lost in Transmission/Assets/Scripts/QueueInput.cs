﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueueInput : MonoBehaviour
{
    [SerializeField]
    PlayerInput pI;
    [SerializeField]
    Turn_manager_script tms;

    InputBox inBox;

    int heldIndex;
    Dirs dir = Dirs.NONE;
    bool[] held = new bool[9];
    Button[] butts = new Button[9];

    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < 4; ++i)
        {
            held[i] = false;
        }
        butts[0] = Button.A;
        butts[1] = Button.B;
        butts[2] = Button.X;
        butts[3] = Button.Y;
        butts[4] = Button.RT;
        butts[5] = Button.LT;
        butts[6] = Button.RB;
        butts[7] = Button.LB;
        butts[8] = Button.START;

        inBox = GetComponentInChildren<InputBox>();
    }

    // Update is called once per frame
    void Update()
    {
        dir = pI.CompassInput();
        inBox.Direction = dir;
        for (int i = 0; i < butts.Length; ++i)
        {
            if (!held[i] && pI.ButtonHeld(butts[i]))
            {
                held[i] = true;
                HeldIndex = i;
            }
            else if (held[i] && !pI.ButtonHeld(butts[i]))
            {
                held[i] = false;
                if (i == heldIndex && (i < 4 || i == 6) && tms.Cooldown(ButtToMove(butts[i])) && dir != Dirs.NONE)
                {
                    Move m = new Move();
                    m.dir = dir;
                    m.type = ButtToMove(butts[i]);
                    // Send move to paulius
                    Debug.Log("QI " + m.dir.ToString() + " " + m.type.ToString());
                    tms.AddMove(m);
                    HeldIndex = -1;
                }
                else if (i == heldIndex)
                {
                    HeldIndex = -1;
                }
            }
        }

        if (pI.LTButtonDown)
        {
            tms.QueueUp();
        }
        else if (pI.RTButtonDown)
        {
            tms.QueueDown();
        }
    }

    private int HeldIndex
    {
        set
        {
            heldIndex = value;
            inBox.Button = (value != -1 ? butts[value] : Button.NONE);
        }
    }

    MoveTypes ButtToMove(Button butt)
    {
        switch (butt)
        {
            case Button.A:
                return MoveTypes.MOVE;
            case Button.B:
                return MoveTypes.MELEE;
            case Button.X:
                return MoveTypes.BLOCK;
            case Button.Y:
                return MoveTypes.RANGE;
            case Button.RB:
                return MoveTypes.CHARGE;
            default:
                return MoveTypes.MOVE;
        }
    }
}
