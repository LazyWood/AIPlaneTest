using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed; // �ӵ����ٶ�
    public float lifeTime; // �ӵ�����������
    public Vector2 direction = Vector2.up;
    private bool isPlayerBullet = true; // ��������

    private void Start()
    {
        // ��lifeTime��������ӵ�
        Destroy(gameObject, lifeTime);
    }

    private void Update()
    {
        // ���ӵ�����y���������ƶ�
        transform.Translate(direction *Vector2.up * speed * Time.deltaTime);
    }
    // ��������
    public void SetBulletType(bool isPlayerBullet)
    {
        this.isPlayerBullet = isPlayerBullet;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.tag);
        if (isPlayerBullet && other.CompareTag("Enemy")) // ��ҵ��ӵ����ел�
        {
            Destroy(other.gameObject); // ����л�
            Destroy(gameObject); // �����ӵ�
        }
        else if (!isPlayerBullet && other.CompareTag("Player")) // �л����ӵ��������
        {
            Destroy(other.gameObject); // �������
            Destroy(gameObject); // �����ӵ�
            GameManager.Instance.GameOver(); // ��Ϸ����
        }
    }
}
