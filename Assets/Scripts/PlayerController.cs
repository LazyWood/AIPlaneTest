using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f; // ���ս�����ƶ��ٶ�
    private Vector2 screenBounds; // ��Ļ�߽�
    private float objectWidth; // ���ս���Ŀ��
    private float objectHeight; // ���ս���ĸ߶�

    private void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.size.x / 2f;
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.size.y / 2f;
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal"); // ��ȡˮƽ����
        float verticalInput = Input.GetAxis("Vertical"); // ��ȡ��ֱ����

        // �����ƶ�����
        float horizontalMovement = horizontalInput * speed * Time.deltaTime;
        float verticalMovement = verticalInput * speed * Time.deltaTime;

        // �ƶ����ս��
        transform.Translate(horizontalMovement, verticalMovement, 0);

        // �������ս������Ļ���ƶ�
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x * -1 + objectWidth, screenBounds.x - objectWidth);
        viewPos.y = Mathf.Clamp(viewPos.y, screenBounds.y * -1 + objectHeight, screenBounds.y - objectHeight);
        transform.position = viewPos;
    }
}
