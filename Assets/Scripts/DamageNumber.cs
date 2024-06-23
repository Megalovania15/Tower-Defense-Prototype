using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamageNumber : MonoBehaviour
{
    public float lifeTime = 0.35f;

    public GameObject damageTextContainer;

    private TMP_Text damageText;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, lifeTime);
    }
}
