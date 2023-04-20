using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float minSpawnDelay = 1f;
    [SerializeField] private float maxSpawnDelay = 3f;

    private float screenWidth;
    private float screenHeight;

    private void Start()
    {
        // ��ȡ��Ļ�ߴ�
        Camera mainCamera = Camera.main;
        screenHeight = mainCamera.orthographicSize;
        screenWidth = mainCamera.aspect * screenHeight;

        // ��ʼ���ɵл�
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        while (true)
        {
            // �ȴ������ʱ��
            float randomDelay = Random.Range(minSpawnDelay, maxSpawnDelay);
            yield return new WaitForSeconds(randomDelay);

            // ������ɵл���λ��
            float randomX = Random.Range(-screenWidth, screenWidth);
            Vector3 spawnPosition = new Vector3(randomX, screenHeight, 0f);

            // �����л�
            GameObject newEnemy = Instantiate(enemyPrefab, spawnPosition, enemyPrefab.transform.rotation);

            // ���ٳ�����Ļ��Χ�ĵл�
            StartCoroutine(DestroyIfOffScreen(newEnemy));
        }
    }

    private IEnumerator DestroyIfOffScreen(GameObject enemy)
    {
        while (enemy!=null)
        {
            // ����л�λ�ó�����Ļ��Χ�������ٵл�
            Vector3 screenPoint = Camera.main.WorldToViewportPoint(enemy.transform.position);
            if (screenPoint.y < 0)
            {  
                Destroy(enemy);
                break;
            }

            yield return null;
        }
    }
}
