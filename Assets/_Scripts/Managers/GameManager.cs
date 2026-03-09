using Leon.Core.Singleton;
using UnityEngine;
using TMPro;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private GameObject _endGameScreen;
    public TMP_Text powerUpText;
    public void EndGame()
    {
        _endGameScreen.SetActive(true);
        PlayerController.Instance.canRun = false;
    }
}
