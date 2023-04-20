using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float minSpeed = 1f;
    public float maxSpeed = 5f;
    public float bulletSpeed = 5f;
    public float bulletCooldown = 1f;

    private float speed;
    private float bulletTimer;

    // Start is called before the first frame update
    void Start()
    {
        // Set random speed for the enemy
        speed = Random.Range(minSpeed, maxSpeed);
        // Set random bullet timer for the enemy
        bulletTimer = Random.Range(0f, bulletCooldown);
    }

    // Update is called once per frame
    void Update()
    {
        // Move the enemy downwards
        transform.Translate(Vector2.up * speed * Time.deltaTime);

        // Check if it's time to shoot a bullet
        bulletTimer -= Time.deltaTime;
        if (bulletTimer <= 0)
        {
            // Reset bullet timer
            bulletTimer = bulletCooldown;

            // Shoot a bullet
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            BulletController bulletController = bullet.GetComponent<BulletController>();
            if (bulletController != null)
            {
                bulletController.speed = bulletSpeed;
                bulletController.direction = Vector2.down;
                bulletController.SetBulletType(false); // 设置为敌机子弹
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other) { 
    
    
    }
}
