using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    [SerializeField]
    private string loadScene; //следующий уровень

    private void Start()
    {
        string loadedLevel = DataManager.LoadLevel();
        if (!loadedLevel.Equals(""))
            loadScene = loadedLevel;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(loadScene);
    }
}