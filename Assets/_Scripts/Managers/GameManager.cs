using Leon.Core.Singleton;
using UnityEngine;
using TMPro;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private GameObject _endGameScreen;
    public TMP_Text powerUpText;
    public void EndGame(AnimatorManager.AnimationType type = AnimatorManager.AnimationType.DEAD)
    {
        _endGameScreen.SetActive(true);
        PlayerController.Instance.CanRun(false);
        PlayerController.Instance.animatorManager.Play(type);

    }
}
