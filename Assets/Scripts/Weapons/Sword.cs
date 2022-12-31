using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    [SerializeField] Transform swordPosition;

    private void Update()
    {
        transform.position = swordPosition.position;
    }
}
