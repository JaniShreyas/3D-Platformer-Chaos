using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactions : MonoBehaviour
{
    public float resetTime = 3f;
    [Header("Specifications")]

    public float minimumGravityMultiplier = 1.5f;
    public float maximumGravityMultiplier = 3f;

    public float minimumSpeedMultiplier = 0.5f;
    public float maximumSpeedMultiplier = 5f;

    public float minimumJumpMultiplier = 0.4f;
    public float maximumJumpMultiplier = 10f;

    Vector3 initialGravity;
    float initialSpeed;
    float initialJumpForce;

    PlayerMovement playerMovement;

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();

        initialGravity = Physics.gravity;
        initialSpeed = playerMovement.multiplier;
        initialJumpForce = playerMovement.jumpForce;
    }

    private void OnTriggerEnter(Collider other)
    {
        Interact(other, false);
    }

    private void OnTriggerExit(Collider other)
    {
        StartCoroutine(ExitInteract(other));
    }

    IEnumerator ExitInteract(Collider other)
    {
        yield return new WaitForSeconds(resetTime);
        Interact(other, true);
    }

    private void Interact(Collider other, bool reset)
    {
        switch (other.tag)
        {
            case "Invert":
                if (reset)
                {
                    ResetInvert();
                    break;
                }
                Invert();
                break;

            case "Gravity":
                if (reset)
                {
                    ResetGravity();
                    break;
                }
                RandomizeGravity();
                break;

            case "Speed":
                if (reset)
                {
                    ResetSpeed();
                    break;
                }
                RandomizeSpeed();
                break;

            case "Jump":
                if (reset)
                {
                    ResetJumpForce();
                    break;
                }
                RandmoizeJumpForce();
                break;
        }
    }

    private void RandmoizeJumpForce()
    {
        float jumpForceMultiplier = 1f;

        jumpForceMultiplier = Random.Range(minimumJumpMultiplier, maximumJumpMultiplier);

        playerMovement.jumpForce *= jumpForceMultiplier;
    }

    private void ResetJumpForce()
    {
        playerMovement.jumpForce = initialJumpForce;
        print("Reset Jump");
    }

    private void RandomizeSpeed()
    {
        float speedMultiplier = 1;

        speedMultiplier = Random.Range(minimumSpeedMultiplier, maximumSpeedMultiplier);

        playerMovement.multiplier *= speedMultiplier;
    }

    private void RandomizeGravity()
    {
        float gravityMultiplier = 1;

        gravityMultiplier = Random.Range(minimumGravityMultiplier, maximumGravityMultiplier);

        Physics.gravity *= gravityMultiplier;
    }

    private void Invert()
    {
        playerMovement.multiplier = -playerMovement.multiplier;
    }

    private void ResetInvert()
    {
        playerMovement.multiplier = Mathf.Abs(playerMovement.multiplier);
        print("Reset Invert");
    }
    
    private void ResetGravity()
    {
        Physics.gravity = initialGravity;
        print("Reset Gravity");
    }

    private void ResetSpeed()
    {
        playerMovement.multiplier = initialSpeed;
        print("Reset Speed");
    }
}
