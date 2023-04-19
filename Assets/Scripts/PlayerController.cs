using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed; // 玩家移动速度
    public GameObject bulletPrefab; // 子弹预制体
    public Transform bulletSpawnPoint; // 子弹生成点

    private void Update()
    {
        // 处理玩家移动逻辑
        Move();

        // 处理玩家发射子弹逻辑
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    private void Move()
    {
        // 处理玩家移动逻辑
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector2 direction = new Vector2(h, v);
        transform.Translate(direction * speed * Time.deltaTime);

        // 确保玩家不会移出屏幕
        float x = Mathf.Clamp(transform.position.x, -8.9f, 8.9f);
        float y = Mathf.Clamp(transform.position.y, -3.7f, 3.7f);
        transform.position = new Vector3(x, y, transform.position.z);
    }

    private void Shoot()
    {
        // 生成子弹
        Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
    }
}
