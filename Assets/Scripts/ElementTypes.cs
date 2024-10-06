using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementTypes : MonoBehaviour
{
    public enum Elements { 
        Basic,
        Fire,
        Water,
        Air,
        Earth,
        Lightning,
        Size
    }

    public GameObject[] explosionRadii = new GameObject[(int)Elements.Size];
}
