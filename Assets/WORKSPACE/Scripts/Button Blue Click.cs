using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonBlueClick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public float pressDepth = 0.1f; // Độ sâu khi nhấn xuống
    public float speed = 5f; // Tốc độ di chuyển
    private Vector3 originalPosition; // Lưu vị trí ban đầu
    private Vector3 targetPosition; // Vị trí đích của nút

    private void Start()
    {
        originalPosition = transform.localPosition;
        targetPosition = originalPosition;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        targetPosition = originalPosition + new Vector3(0, -pressDepth, 0);
        Debug.LogWarning("Button pressed down: " + targetPosition);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        targetPosition = originalPosition;
        Debug.LogWarning("Button released: " + targetPosition);
    }

    private void Update()
    {
        // Di chuyển nút về vị trí target một cách mượt mà
        transform.localPosition = Vector3.Lerp(transform.localPosition, targetPosition, speed * Time.deltaTime);
    }
}
