using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed; // 子弹的速度
    public float lifeTime; // 子弹的生命周期
    public Vector2 direction = Vector2.up;

    private void Start()
    {
        // 在lifeTime秒后销毁子弹
        Destroy(gameObject, lifeTime);
    }

    private void Update()
    {
        // 让子弹沿着y轴正方向移动
        transform.Translate(direction *Vector2.up * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 如果子弹接触到敌机，则销毁子弹和敌机
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
