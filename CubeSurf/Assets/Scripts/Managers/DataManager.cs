using UnityEngine;

public class DataManager : MonoBehaviour
{
    /// <summary>
    /// Сохранение монет в PlayerPrefs
    /// </summary>
    /// <param name="coinsToAdd">добавляемые монеты</param>
    public static void SaveCoins(int coinsToAdd)
    {
        PlayerPrefs.SetInt(Variables.coinSave, coinsToAdd);
    }

    /// <summary>
    /// Сохранение текущего уровня
    /// </summary>
    /// <param name="lvlToSave">уровень</param>
    public static void SaveLevel(string lvlToSave)
    {
        PlayerPrefs.SetString(Variables.levelSave, lvlToSave);
    }

    /// <summary>
    /// Загрузка собранных монет
    /// </summary>
    /// <returns>кол-во монет</returns>
    public static int LoadCoins()
    {
        return PlayerPrefs.GetInt(Variables.coinSave);
    }

    /// <summary>
    /// Загрузка уровня
    /// </summary>
    /// <returns>название уровня</returns>
    public static string LoadLevel()
    {
        return PlayerPrefs.GetString(Variables.levelSave);
    }
}
