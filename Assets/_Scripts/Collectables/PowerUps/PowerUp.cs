using UnityEngine;

public class PowerUp : Collectable
{
    [Header("Power Up")]
    public float duration;

    private void Awake()
    {
        timeToDestroy = duration + 0.5f;
    }
    protected override void OnCollect()
    {
        base.OnCollect();
        StartPowerUp();
    }

    protected virtual void StartPowerUp()
    {
        Invoke(nameof(EndPowerUp), duration);
    }

    protected virtual void EndPowerUp()
    {
        GameManager.Instance.powerUpText.text = "";
    }
}
