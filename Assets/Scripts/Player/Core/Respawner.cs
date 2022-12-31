using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawner : MonoBehaviour
{
    public Vector3 respawnPoint = new Vector3(0f, 1f, 0f);

    private void Update()
    {
        if (transform.position.y <= -10)
        {
            Respawn();
        }

        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            Respawn();
        }
    }

    private void Respawn()
    {
        transform.position = respawnPoint;
    }
}
