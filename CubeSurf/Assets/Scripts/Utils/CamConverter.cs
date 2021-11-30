using UnityEngine;

public class CamConverter : MonoBehaviour
{
    /// <summary>
    /// Конвертация позиции клика
    /// </summary>
    /// <param name="camera">камера</param>
    /// <param name="position">место клика</param>
    /// <returns>конвертированное значение</returns>
    public static Vector3 ScreenToWorld(Camera camera, Vector3 position)
    {
        position.z = 10f;
        return camera.ScreenToWorldPoint(position);
    }
}
