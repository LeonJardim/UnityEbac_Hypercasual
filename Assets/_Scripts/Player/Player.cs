using UnityEngine;

public class Player : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Enemy"))
        {
            if (PlayerController.Instance.invincible) return;
            GameManager.Instance.EndGame();
        }
        else if (collision.transform.CompareTag("Finish"))
        {
            GameManager.Instance.EndGame(AnimatorManager.AnimationType.IDLE);
        }

    }
}
