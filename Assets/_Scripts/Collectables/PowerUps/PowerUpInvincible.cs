using UnityEngine;

public class PowerUpInvincible : PowerUp
{
    [Header("Invincible")]
    [SerializeField] private string powerUpName = "Invincible";

    protected override void StartPowerUp()
    {
        base.StartPowerUp();
        GameManager.Instance.powerUpText.text = powerUpName;
        PlayerController.Instance.invincible = true;
    }

    protected override void EndPowerUp()
    {
        base.EndPowerUp();
        PlayerController.Instance.invincible = false;
    }
}
