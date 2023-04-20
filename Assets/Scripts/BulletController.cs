using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed; // 子弹的速度
    public float lifeTime; // 子弹的生命周期
    public Vector2 direction = Vector2.up;
    private bool isPlayerBullet = true; // 新增变量

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
    // 新增方法
    public void SetBulletType(bool isPlayerBullet)
    {
        this.isPlayerBullet = isPlayerBullet;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.tag);
        if (isPlayerBullet && other.CompareTag("Enemy")) // 玩家的子弹击中敌机
        {
            Destroy(other.gameObject); // 消灭敌机
            Destroy(gameObject); // 消灭子弹
        }
        else if (!isPlayerBullet && other.CompareTag("Player")) // 敌机的子弹击中玩家
        {
            Destroy(other.gameObject); // 消灭玩家
            Destroy(gameObject); // 消灭子弹
            GameManager.Instance.GameOver(); // 游戏结束
        }
    }
}
