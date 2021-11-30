using System;
using UnityEngine;

public class FinishLineScript : MonoBehaviour
{
    public event Action OnFinish; //событие завершения уровня

    private void OnTriggerEnter(Collider other)
    {
        if (TagLayerCompare.CompareLayer(Variables.playerLayer, other.gameObject))
            OnFinish?.Invoke();
    }
}
