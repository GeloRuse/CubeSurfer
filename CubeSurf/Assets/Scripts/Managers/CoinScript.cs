using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinScript : MonoBehaviour
{
    [SerializeField]
    private Text coinCounter; //счетчик монет

    [SerializeField]
    private GameObject coinPrefab; //префаб монеты
    [SerializeField]
    private int maxCoins; //награждаемые монеты
    private int coins; //кол-во монет
    private Queue<GameObject> coinsQueue = new Queue<GameObject>(); //пул монет

    [SerializeField]
    private Transform origin; //место начала пути
    [SerializeField]
    private Transform target; //место конца
    [SerializeField]
    private Transform parent; //родитель для монет

    [SerializeField]
    private float spread; //разброс монет
    [SerializeField]
    private float minDuration; //минимальное время перемещения
    [SerializeField]
    private float maxDuration; //максимальное время
    [SerializeField]
    private Ease easeType; //тип анимации

    private void Start()
    {
        PrepareCoins(parent);
        coins = DataManager.LoadCoins();
        coinCounter.text = coins.ToString();
    }

    /// <summary>
    /// Создание последовательности анимации монет
    /// </summary>
    /// <returns>последовательность анимаций</returns>
    public Sequence AnimateCoins()
    {
        Sequence seq = DOTween.Sequence();
        for (int i = 0; i < maxCoins; i++)
        {
            if (coinsQueue.Count > 0)
            {
                GameObject coin = coinsQueue.Dequeue();
                coin.SetActive(true);
                coin.transform.position = origin.position + new Vector3(Random.Range(-spread, spread), Random.Range(-spread, spread), 0f);
                float duration = Random.Range(minDuration, maxDuration);
                seq.Insert(0, coin.transform.DOMove(target.position, duration)
                    .SetEase(easeType)
                    .OnComplete(() =>
                    {
                        coins++;
                        coinCounter.text = coins.ToString();
                        coin.SetActive(false);
                        coinsQueue.Enqueue(coin);
                    }));
            }
        }
        seq.AppendInterval(1f);
        return seq;
    }

    /// <summary>
    /// Создание пула монет
    /// </summary>
    /// <param name="parent">родитель для монет</param>
    private void PrepareCoins(Transform parent)
    {
        GameObject coin;
        for (int i = 0; i < maxCoins; i++)
        {
            coin = Instantiate(coinPrefab);
            coin.transform.parent = parent;
            coin.transform.SetAsFirstSibling();
            coin.SetActive(false);
            coinsQueue.Enqueue(coin);
        }
    }

    public int GetCoinCount()
    {
        return coins;
    }
}
