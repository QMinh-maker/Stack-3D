using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [Header("Camera Settings")]
    [SerializeField] private float moveUpPerScore = 0.5f;
    [SerializeField] private float smoothSpeed = 3f;
    [SerializeField] private int startMoveScore = 3;

    private int score = 0;
    private bool hasStarted = false;

    private Vector3 targetPosition;

    private void Start()
    {
        targetPosition = transform.position;
        GameManager.OnCubeSpawn += OnCubeSpawn;
    }

    private void OnDestroy()
    {
        GameManager.OnCubeSpawn -= OnCubeSpawn;
    }

    private void OnCubeSpawn()
    {
        // Bỏ qua lần spawn đầu tiên (bắt đầu game)
        if (!hasStarted)
        {
            hasStarted = true;
            return;
        }

        score++;

        // Chỉ bắt đầu di chuyển khi đủ điểm
        if (score >= startMoveScore)
        {
            targetPosition += Vector3.up * moveUpPerScore;
        }
    }

    private void LateUpdate()
    {
        // Camera di chuyển mượt
        transform.position = Vector3.Lerp(
            transform.position,
            targetPosition,
            Time.deltaTime * smoothSpeed
        );
    }
}
