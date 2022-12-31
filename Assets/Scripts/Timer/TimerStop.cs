using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerStop : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            transform.parent.GetComponent<Timer>().isTiming = false;

            print(transform.parent.GetComponent<Timer>().isTiming);
        }
    }
}
