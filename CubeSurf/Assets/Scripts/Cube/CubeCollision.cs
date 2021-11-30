using System;
using UnityEngine;

public class CubeCollision : MonoBehaviour
{
    public event Action OnRightHit; //событие столкновения с правильным кубом
    public event Action<CubeCollision> OnWrongHit; //.. с препятствием
    public event Action<CubeCollision> OnLavaHit; //.. с лавой

    private void OnTriggerEnter(Collider other)
    {
        if (other.isTrigger)
        {
            if (TagLayerCompare.CompareTag(Variables.cubeTag, other.gameObject))
            {
                Destroy(other.gameObject);
                OnRightHit?.Invoke();
            }
            else if (TagLayerCompare.CompareTag(Variables.obstacleTag, other.gameObject))
                OnWrongHit?.Invoke(this);
            else if (TagLayerCompare.CompareTag(Variables.lavaTag, other.gameObject))
                OnLavaHit?.Invoke(this);
        }
    }
}
