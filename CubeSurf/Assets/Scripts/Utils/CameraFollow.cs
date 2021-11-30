using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private Transform target; //объект за которым следует камера
    [SerializeField]
    private float offsetY; //расстояние камеры от объекта по оси Y
    [SerializeField]
    private float offsetZ; //расстояние камеры от объекта по оси Z

    private Vector3 newPos; //новая позиция камеры

    private void FixedUpdate()
    {
        if (target != null)
        {
            MoveCamera();
        }
    }

    private void MoveCamera()
    {
        newPos = transform.position;
        newPos.y = target.position.y + offsetY;
        newPos.z = target.position.z + offsetZ;
        transform.position = newPos;
    }

    public void StopFollow()
    {
        target = null;
    }
}
