using UnityEngine;

public class PowerUpFly : PowerUp
{
    [Header("Fly")]
    [SerializeField] private string powerUpName = "Fly";
    public float height = 2.0f;
    public float animationDuration = 0.1f;
    public DG.Tweening.Ease ease = DG.Tweening.Ease.OutBack;


    protected override void StartPowerUp()
    {
        base.StartPowerUp();
        GameManager.Instance.powerUpText.text = powerUpName;
        PlayerController.Instance.FlyON(height, duration, animationDuration, ease);
    }
    protected override void EndPowerUp()
    {
        base.EndPowerUp();
        PlayerController.Instance.ResetHeight(animationDuration);
    }
}
