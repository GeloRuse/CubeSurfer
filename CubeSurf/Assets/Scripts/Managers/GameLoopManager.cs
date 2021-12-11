using UnityEngine;

public class GameLoopManager : MonoBehaviour
{
    [SerializeField]
    private PlayerMovement player; //игрок
    [SerializeField]
    private CubeStack cubeStack; //башня из кубов игрока
    [SerializeField]
    private FinishLineScript finish; //финиш
    [SerializeField]
    private CameraFollow cameraFollow; //камера
    [SerializeField]
    private PanelManager uiManager; //управление экранами проигрыша/финиша

    [SerializeField]
    private Transform border1; //граница уровня 1
    [SerializeField]
    private Transform border2; //граница уровня 2
    [SerializeField]
    private float borderOffset = 1.5f;

    private void Start()
    {
        player.AssignClamp(ClampCalc.Calculate(border1, border2, borderOffset));
    }

    private void OnEnable()
    {
        finish.OnFinish += FinishLevel;
        cubeStack.OnDead += GameOver;
    }

    private void OnDisable()
    {
        finish.OnFinish -= FinishLevel;
        cubeStack.OnDead -= GameOver;
    }

    private void FixedUpdate()
    {
        MainLoop();
    }

    /// <summary>
    /// Основной игровой цикл
    /// </summary>
    private void MainLoop()
    {
        if (player.enabled)
            player.Move();
    }

    /// <summary>
    /// Уровень пройден - отключить управление, показать экран финиша
    /// </summary>
    private void FinishLevel()
    {
        player.enabled = false;
        uiManager.ShowWinPanel();
    }

    /// <summary>
    /// Игрок проиграл - отключить управление, прекратить преследование камерой, показать экран поражения
    /// </summary>
    private void GameOver()
    {
        player.enabled = false;
        cameraFollow.StopFollow();
        uiManager.ShowLosePanel();
    }
}
