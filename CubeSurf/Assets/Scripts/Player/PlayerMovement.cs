using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private InputManager inputManager; //менеджер управления
    private float xClamp; //ограничение движения по оси X
    private Vector3 targetPos; //вектор направления
    private bool isMoving; //состояние движения

    [SerializeField]
    private float speed; //скорость движения

    private void OnEnable()
    {
        inputManager.OnStartTouch += TrackMove;
        inputManager.OnEndTouch += CancelMove;
    }

    private void OnDisable()
    {
        inputManager.OnStartTouch -= TrackMove;
        inputManager.OnEndTouch -= CancelMove;
    }

    private void TrackMove()
    {
        isMoving = true;
    }

    private void CancelMove()
    {
        isMoving = false;
    }

    /// <summary>
    /// Движение объекта
    /// </summary>
    public void Move()
    {
        if (isMoving)
            targetPos = new Vector3(Mathf.Clamp(inputManager.PrimaryPosition().x, -xClamp, xClamp), transform.position.y, transform.position.z + 1);
        else
            targetPos = transform.position + Vector3.forward;
        transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * speed);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -xClamp, xClamp), transform.position.y, transform.position.z);
    }

    /// <summary>
    /// Назначение ограничения перемещения по оси X
    /// </summary>
    /// <param name="clamp">ограничивающее число</param>
    public void AssignClamp(float clamp)
    {
        xClamp = clamp;
    }
}
