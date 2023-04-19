using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f; // 玩家战机的移动速度
    private Vector2 screenBounds; // 屏幕边界
    private float objectWidth; // 玩家战机的宽度
    private float objectHeight; // 玩家战机的高度

    private void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.size.x / 2f;
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.size.y / 2f;
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal"); // 获取水平输入
        float verticalInput = Input.GetAxis("Vertical"); // 获取垂直输入

        // 计算移动距离
        float horizontalMovement = horizontalInput * speed * Time.deltaTime;
        float verticalMovement = verticalInput * speed * Time.deltaTime;

        // 移动玩家战机
        transform.Translate(horizontalMovement, verticalMovement, 0);

        // 限制玩家战机在屏幕内移动
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x * -1 + objectWidth, screenBounds.x - objectWidth);
        viewPos.y = Mathf.Clamp(viewPos.y, screenBounds.y * -1 + objectHeight, screenBounds.y - objectHeight);
        transform.position = viewPos;
    }
}
