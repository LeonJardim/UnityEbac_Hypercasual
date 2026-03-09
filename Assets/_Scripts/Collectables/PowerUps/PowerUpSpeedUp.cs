using UnityEngine;

public class PowerUpSpeedUp : PowerUp
{
    [Header("Speed Up")]
    [SerializeField] private string powerUpName = "Super Speed";
    public float speedAmount;

    protected override void StartPowerUp()
    {
        base.StartPowerUp();
        GameManager.Instance.powerUpText.text = powerUpName;
        PlayerController.Instance.SpeedPowerUpOn(speedAmount);
    }

    protected override void EndPowerUp()
    {
        base.EndPowerUp();
        PlayerController.Instance.SpeedPowerUpOff();
    }
}
