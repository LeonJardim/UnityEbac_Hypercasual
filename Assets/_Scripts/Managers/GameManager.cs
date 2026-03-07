using Leon.Core.Singleton;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private TouchController _playerController;
    [SerializeField] private GameObject _endGameScreen;
    public void EndGame()
    {
        _endGameScreen.SetActive(true);
        _playerController.canRun = false;
    }
}
