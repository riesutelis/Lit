﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityMaster : MonoBehaviour {

    AbilityCard[] abs = new AbilityCard[5];

    // Use this for initialization
    void Start()
    {
        AbilityCard[] tempAbs = GetComponentsInChildren<AbilityCard>();
        for (int i = 0; i < 5; ++i)
        {
            string abName = tempAbs[i].gameObject.name;
            switch (abName)
            {
                case "abilityMove":
                    abs[0] = tempAbs[i];
                    break;
                case "abilityMelee":
                    abs[1] = tempAbs[i];
                    break;
                case "abilityBlock":
                    abs[2] = tempAbs[i];
                    break;
                case "abilityRange":
                    abs[3] = tempAbs[i];
                    break;
                case "abilityCharge":
                    abs[4] = tempAbs[i];
                    break;
            }
        }
    }

    public void UpdateAbility(Button b, int cd, Locks l)
    {
        int i = ((int)b < 4 ? (int)b : (int)b - 2);
        abs[i].Locked = l;
        abs[i].Cooldown = cd;
    }
}
