using UnityEngine;

public class Player : MonoBehaviour
{
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

    public void ResetPlayerPosition()
    {
        transform.position = Vector3.zero;
    }
}
