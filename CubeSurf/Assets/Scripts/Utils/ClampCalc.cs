using UnityEngine;

public class ClampCalc : MonoBehaviour
{
    /// <summary>
    /// Расчет границ уровня
    /// </summary>
    /// <param name="obj1">граница 1</param>
    /// <param name="obj2">граница 2</param>
    /// <returns>число для ограничения передвижения</returns>
    public static float Calculate(Transform obj1, Transform obj2)
    {
        return Vector3.Distance(obj1.position, obj2.position) / 2 - 1.5f;
    }
}
