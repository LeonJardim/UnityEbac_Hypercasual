using DG.Tweening;
using UnityEngine;

public class BounceFX : MonoBehaviour
{
    [SerializeField] private float _amount = 1.3f;
    [SerializeField] private float _duration = 0.3f;

    public void Bounce()
    {
        DOTween.Kill(transform);
        transform.localScale = Vector3.one;

        transform.DOScale(_amount, _duration).SetLoops(2, LoopType.Yoyo);
    }
}
