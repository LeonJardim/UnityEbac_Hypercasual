using DG.Tweening;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _durationToShow = 1.0f;

    private void Start()
    {
        transform.DOScale(Vector3.one, _durationToShow);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (!PlayerController.Instance.canRun) return;
        if (collision.transform.CompareTag("Enemy"))
        {
            if (PlayerController.Instance.invincible) return;
            GameManager.Instance.EndGame();
        }
        else if (collision.transform.CompareTag("Finish"))
        {
            PlayerController.Instance.CanRun(false);
            GameManager.Instance.EndGame(true, AnimatorManager.AnimationType.IDLE);
        }
    }

    
}
