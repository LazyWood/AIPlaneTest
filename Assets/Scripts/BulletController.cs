using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed; // �ӵ����ٶ�
    public float lifeTime; // �ӵ�����������

    private void Start()
    {
        // ��lifeTime��������ӵ�
        Destroy(gameObject, lifeTime);
    }

    private void Update()
    {
        // ���ӵ�����y���������ƶ�
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ����ӵ��Ӵ����л����������ӵ��͵л�
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
