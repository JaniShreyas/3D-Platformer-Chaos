using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public LayerMask enemyLayers;
    public float attackRange = 5f;
    public float attackDamage = 5f;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Collider[] enemies = Physics.OverlapSphere(transform.position, attackRange, enemyLayers);

            foreach(Collider enemy in enemies)
            {
                Health enemyHealth = enemy.GetComponent<Health>();
                if (enemyHealth == null) return;

                print($"{enemy.name} Hit");
                enemyHealth.TakeDamage(attackDamage);
            }
        }
    }
}
