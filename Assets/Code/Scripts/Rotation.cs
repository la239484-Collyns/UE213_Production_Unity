using UnityEngine;

public class MultiAxisRotator : MonoBehaviour
{
    public enum RotationMode { Reverse, Loop }

    [Header("Base Rotation")]
    public Vector3 baseRotation = Vector3.zero;

    [System.Serializable]
    public class AxisRotationSettings
    {
        public bool enable = true;
        public float speed = 50f;
        public float min = -45f;
        public float max = 45f;
        public RotationMode mode = RotationMode.Reverse;

        [HideInInspector] public float current = 0f;
        [HideInInspector] public int direction = 1;
    }

    [Header("X Axis Settings")]
    public AxisRotationSettings x = new AxisRotationSettings();

    [Header("Y Axis Settings")]
    public AxisRotationSettings y = new AxisRotationSettings();

    [Header("Z Axis Settings")]
    public AxisRotationSettings z = new AxisRotationSettings();

    void Start()
    {
        x.current = transform.localEulerAngles.x;
        y.current = transform.localEulerAngles.y;
        z.current = transform.localEulerAngles.z;
    }

    void Update()
    {
        UpdateAxis(ref x);
        UpdateAxis(ref y);
        UpdateAxis(ref z);

        transform.localEulerAngles = baseRotation + new Vector3(x.current, y.current, z.current);
    }

    void UpdateAxis(ref AxisRotationSettings axis)
    {
        if (!axis.enable) return;

        axis.current += axis.speed * Time.deltaTime * axis.direction;

        if (axis.mode == RotationMode.Reverse)
        {
            if (axis.current >= axis.max)
            {
                axis.current = axis.max;
                axis.direction = -1;
            }
            else if (axis.current <= axis.min)
            {
                axis.current = axis.min;
                axis.direction = 1;
            }
        }
        else if (axis.mode == RotationMode.Loop)
        {
            if (axis.current >= axis.max)
            {
                axis.current = axis.min;
            }
        }
    }
}
