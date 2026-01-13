using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMovement : MonoBehaviour
{
    private MovingCube movingCube;
    
    private float direction = 1f;

    // Giới hạn tuyệt đối
    private const float X_MIN = -1.2f;
    private const float X_MAX = 1.2f;

    private const float Z_MIN = -1.4f;
    private const float Z_MAX = 1.3f;

    private void Awake()
    {
        movingCube = GetComponent<MovingCube>();
    }

    private void OnEnable()
    {
        direction = 1f;
    }

    void Update()
    {
        if (movingCube.moveSpeed <= 0f)
            return;

        if (movingCube.MoveDirection == MoveDirection.X)
        {
            MoveX();
        }
        else
        {
            MoveZ();
        }
    }

    private void MoveX()
    {
        Vector3 pos = transform.localPosition;
        pos.x += direction * movingCube.moveSpeed * Time.deltaTime;

        if (pos.x >= X_MAX)
        {
            pos.x = X_MAX;
            direction = -1f;
        }
        else if (pos.x <= X_MIN)
        {
            pos.x = X_MIN;
            direction = 1f;
        }

        transform.localPosition = pos;
    }

    private void MoveZ()
    {
        Vector3 pos = transform.localPosition;
        pos.z += direction * movingCube.moveSpeed * Time.deltaTime;

        if (pos.z >= Z_MAX)
        {
            pos.z = Z_MAX;
            direction = -1f;
        }
        else if (pos.z <= Z_MIN)
        {
            pos.z = Z_MIN;
            direction = 1f;
        }

        transform.localPosition = pos;
    }
}
