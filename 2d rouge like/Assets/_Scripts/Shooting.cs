using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform firePoint;
    public GameObject bulletPrefab;
    public bool PlayerCharacter = false;

    public float bulletForce = 20f;

    // Update is called once per frame
    void Update()
    {
        if (PlayerCharacter)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Shoot(true);
            }
        }
    }

    public void Shoot(bool isPlayer)
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        bullet.GetComponent<Bullet>().SetShooter(isPlayer);
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }
}
