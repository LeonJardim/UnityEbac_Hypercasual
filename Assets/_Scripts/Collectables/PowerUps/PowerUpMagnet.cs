using DG.Tweening;
using UnityEngine;

public class PowerUpMagnet : PowerUp
{
    [Header("Magnet")]
    [SerializeField] private string powerUpName = "Magnet";
    public float radius = 4.5f;

    protected override void StartPowerUp()
    {
        base.StartPowerUp();
        GameManager.Instance.powerUpText.text = powerUpName;
        PlayerController.Instance.ChangeCoinCollectorRadius(radius);
    }
    protected override void EndPowerUp()
    {
        base.EndPowerUp();
        PlayerController.Instance.ResetCoinCollectorRadius();
    }

}
