using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public GameObject triggeredObject;
    public float minStayTime = 2f;
    public float maxStayTime = 5f;

    float stayTime = 1f;

    private bool isTriggered;

    bool isVisible = false;

    public bool IsTriggered => isTriggered;

    private void OnTriggerEnter(Collider other)
    {
        print(other.name);
        if (other.CompareTag("Player"))
        {
            print("Player");
            Trigger(true);
            isVisible = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        stayTime = Random.Range(minStayTime, maxStayTime);
        StartCoroutine(Reappear());
    }

    private void Trigger(bool activeState)
    {
        if (triggeredObject == null) return;
        triggeredObject.SetActive(activeState);
    }

    IEnumerator Reappear()
    {
        if (triggeredObject == null) yield return null;
        if (isVisible)
        {
            yield return new WaitForSeconds(stayTime);

            Trigger(false);
            isVisible = false;
        }
    }
}


