﻿public enum Dirs
{
    NONE = 999,
    N = 0,
    NE = -45,
    E = -90,
    SE = -135,
    S = -180,
    SW = -225,
    W = -270,
    NW = -315
}

public enum MoveTypes
{
    NONE = -1,
    MOVE = 0,
    BLOCK = 1,
    MELEE = 2,
    RANGE = 3,
    CHARGE = 4
};

public enum Button
{
    NONE = -1,
    A = 0,
    B = 1,
    X = 2,
    Y = 3,
    RT = 4,
    LT = 5,
    RB = 6,
    LB = 7,
    START = 8
};

public enum Locks
{
    OPEN = 0, CLOSED = 1, HECKA = 2
};

public struct Move
{
    public MoveTypes type;
    public Dirs dir;
}

public class staticObjects
{
    public static int[] cooldowns = {
        0 /*move*/,
        1 /*block*/,
        3 /*melee*/,
        2 /*range*/,
        4 /*charge*/,
        0 };
    public const float moveTime = 0.2f;
}