using UnityEngine;

public class MultiAxisRotator : MonoBehaviour
{    Vector3 baseRotation = Vector3.zero;

    [Header("X Axis Settings")]
    public bool rotateX = true;
    public float speedX = 50f;
    public float minX = -45f;
    public float maxX = 45f;

    [Header("Y Axis Settings")]
    public bool rotateY = true;
    public float speedY = 100f;
    public float minY = -90f;
    public float maxY = 90f;

    [Header("Z Axis Settings")]
    public bool rotateZ = false;
    public float speedZ = 30f;
    public float minZ = -30f;
    public float maxZ = 30f;

    private float currentX;
    private float currentY;
    private float currentZ;

    private int dirX = 1;
    private int dirY = 1;
    private int dirZ = 1;

    void Start()
    {
        // Initialize with base rotation
        currentX = transform.localEulerAngles.x;
        currentY = transform.localEulerAngles.y;
        currentZ = transform.localEulerAngles.z;
    }

    void Update()
    {
        if (rotateX)
        {
            currentX += speedX * Time.deltaTime * dirX;
            if (currentX >= maxX) { currentX = maxX; dirX = -1; }
            else if (currentX <= minX) { currentX = minX; dirX = 1; }
        }

        if (rotateY)
        {
            currentY += speedY * Time.deltaTime * dirY;
            if (currentY >= maxY) { currentY = maxY; dirY = -1; }
            else if (currentY <= minY) { currentY = minY; dirY = 1; }
        }

        if (rotateZ)
        {
            currentZ += speedZ * Time.deltaTime * dirZ;
            if (currentZ >= maxZ) { currentZ = maxZ; dirZ = -1; }
            else if (currentZ <= minZ) { currentZ = minZ; dirZ = 1; }
        }

        // Apply rotation offset from base
        transform.localEulerAngles = baseRotation + new Vector3(currentX, currentY, currentZ);
    }
}
