using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed; // ����ƶ��ٶ�
    public GameObject bulletPrefab; // �ӵ�Ԥ����
    public Transform bulletSpawnPoint; // �ӵ����ɵ�

    private void Update()
    {
        // ��������ƶ��߼�
        Move();

        // ������ҷ����ӵ��߼�
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    private void Move()
    {
        // ��������ƶ��߼�
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector2 direction = new Vector2(h, v);
        transform.Translate(direction * speed * Time.deltaTime);

        // ȷ����Ҳ����Ƴ���Ļ
        float x = Mathf.Clamp(transform.position.x, -8.9f, 8.9f);
        float y = Mathf.Clamp(transform.position.y, -3.7f, 3.7f);
        transform.position = new Vector3(x, y, transform.position.z);
    }

    private void Shoot()
    {
        // �����ӵ�
        Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
    }
}
