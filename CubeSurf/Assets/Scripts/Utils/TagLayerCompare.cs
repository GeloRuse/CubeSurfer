using UnityEngine;

public class TagLayerCompare : MonoBehaviour
{
    /// <summary>
    /// Метод для сравнения тэгов
    /// </summary>
    /// <param name="tag">тэг</param>
    /// <param name="go">объект сравнения</param>
    /// <returns>совпадение тэгов</returns>
    public static bool CompareTag(string tag, GameObject go)
    {
        if (go.tag.Equals(tag))
        {
            return true;
        }
        return false;
    }

    /// <summary>
    /// Метод для сравнения слоев
    /// </summary>
    /// <param name="layer">слой</param>
    /// <param name="go">объект сравнения</param>
    /// <returns>совпадение слоев</returns>
    public static bool CompareLayer(string layer, GameObject go)
    {
        if (go.layer == LayerMask.NameToLayer(layer))
        {
            return true;
        }
        return false;
    }
}
