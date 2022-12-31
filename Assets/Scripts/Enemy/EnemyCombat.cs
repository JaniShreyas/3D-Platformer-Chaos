using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] GameObject bullet;

    public float attackRange = 3f;
    
    public float attackSpeed = 2f;
    float timeSinceLastAttack = Mathf.Infinity;
    
    public float bulletForce = 10f;

    public float bulletLife = 5f;

    private void Update()
    {
        if (PlayerIsInRange())
        {
            if(attackSpeed <= timeSinceLastAttack)
            {
                Attack();
            }
        }

        timeSinceLastAttack += Time.deltaTime;
    }

    private bool PlayerIsInRange()
    {
        if(Vector3.Distance(transform.position, player.position) <= attackRange)
        {
            return true;
        }

        return false;
    }

    private void Attack()
    {
        Vector3 playerPosition = player.position;

        GameObject bullet = Instantiate(this.bullet, transform.position, transform.rotation);

        bullet.transform.LookAt(playerPosition);
        Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
        bulletRigidbody.AddForce(bullet.transform.forward * bulletForce, ForceMode.Impulse);

        StartCoroutine(RemoveBullet(bullet));
        timeSinceLastAttack = 0f;
    }

    IEnumerator RemoveBullet(GameObject bullet)
    {
        yield return new WaitForSeconds(bulletLife);

        if (bullet == null) yield return null;

        Destroy(bullet);
    }
}
