using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusEffect
{
    //this is a factory that "produces" the different status effects

    //select the type of status effect in the inspector
    public enum Type {
        None,
        Fire
    }

    public static System.Type GetStatusEffect(Type type)
    {
        switch (type)
        {
            case Type.Fire:
                return typeof(FireEffect);
            default:
                throw new ArgumentException("Don't know the type: " + type.ToString());
        }
    }
}
