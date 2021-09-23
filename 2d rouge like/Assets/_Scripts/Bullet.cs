using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject hitEffect;
    public int damage = 40;
    public int enemyDamage = 15;
    bool isPlayer;

    public void SetShooter(bool isplayer)
    {
        isPlayer = isplayer;
    }


    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (isPlayer)
        {
            Enemy enemy = hitInfo.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
        }
        else if (!isPlayer)
        {
            PlayerHealth player = hitInfo.GetComponent<PlayerHealth>();
            if (player != null)
            {
                player.TakeDamage(enemyDamage);
            }
        }
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(effect, 0.5f);
        Destroy(gameObject);
    }
}
