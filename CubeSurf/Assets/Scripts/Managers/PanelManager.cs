using UnityEngine;

public class PanelManager : MonoBehaviour
{
    [SerializeField]
    private GameObject winPanel; //экран финиша
    [SerializeField]
    private GameObject losePanel; //экран проигрыша

    public void ShowWinPanel()
    {
        winPanel.SetActive(true);
    }

    public void ShowLosePanel()
    {
        losePanel.SetActive(true);
    }

}
