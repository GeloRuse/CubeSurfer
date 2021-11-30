using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    [SerializeField]
    private string nextScene; //следующий уровень
    [SerializeField]
    private Button btnNext; //кнопка "далее"
    [SerializeField]
    private Button btnRestart; //кнопка "заново"

    [SerializeField]
    private CoinScript coins; //управление монетами

    private void Start()
    {
        //подписывание кнопок на соответствующие методы
        btnNext.onClick.AddListener(delegate { NextLevel(nextScene); });
        btnRestart.onClick.AddListener(RestartLevel);
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    /// <summary>
    /// После проигрывания анимации монет - сохранить прогресс, запустить следующий уровень
    /// </summary>
    /// <param name="scene"></param>
    private void NextLevel(string scene)
    {
        coins.AnimateCoins().OnComplete(() =>
        {
            DataManager.SaveCoins(coins.GetCoinCount());
            DataManager.SaveLevel(nextScene);
            SceneManager.LoadScene(scene);
        });
    }
}
