using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float bulletRange = 1f;
    [SerializeField] float bulletDamage = 5f;
    [SerializeField] LayerMask playerMask;

    private void Update()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, bulletRange, playerMask);

        foreach(Collider hit in hits)
        {
            Health playerHealth = hit.GetComponent<Health>();
            if (playerHealth == null) return;

            playerHealth.TakeDamage(bulletDamage);

            Destroy(gameObject);
        }
    }
}
