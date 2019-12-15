using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DotTypes
{
    public enum Set
    {
        Active = 1,
        Inactive = 0
    };
    public static bool isActive(this Set value)
    {
        return value == Set.Active;
    }

}
