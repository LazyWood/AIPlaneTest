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
        // 获取屏幕尺寸
        Camera mainCamera = Camera.main;
        screenHeight = mainCamera.orthographicSize;
        screenWidth = mainCamera.aspect * screenHeight;

        // 开始生成敌机
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        while (true)
        {
            // 等待随机的时间
            float randomDelay = Random.Range(minSpawnDelay, maxSpawnDelay);
            yield return new WaitForSeconds(randomDelay);

            // 随机生成敌机的位置
            float randomX = Random.Range(-screenWidth, screenWidth);
            Vector3 spawnPosition = new Vector3(randomX, screenHeight, 0f);

            // 创建敌机
            GameObject newEnemy = Instantiate(enemyPrefab, spawnPosition, enemyPrefab.transform.rotation);

            // 销毁超出屏幕范围的敌机
            StartCoroutine(DestroyIfOffScreen(newEnemy));
        }
    }

    private IEnumerator DestroyIfOffScreen(GameObject enemy)
    {
        while (enemy!=null)
        {
            // 如果敌机位置超出屏幕范围，则销毁敌机
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
