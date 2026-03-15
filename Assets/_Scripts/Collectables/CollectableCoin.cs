using UnityEngine;

public class CollectableCoin : Collectable
{
    [Header("Coin")]
    [SerializeField] private float _lerp = 5.0f;
    [SerializeField] private float _minDistance = 1.0f;

    private void Start()
    {
        CoinsAnimationManager.Instance.RegisterCoin(this);
    }

    protected override void OnCollect()
    {
        base.OnCollect();
        PlayerController.Instance.Bounce();
        ItemManager.Instance.AddCoins();
        CoinsAnimationManager.Instance.items.Remove(this);
    }

    private void Update()
    {
        Vector3 p = PlayerController.Instance.transform.position;
        if (collected)
        {
            transform.position = Vector3.Lerp(transform.position, p, _lerp * Time.deltaTime);

            if (Vector3.Distance(transform.position, p) < _minDistance)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnDestroy()
    {
        CoinsAnimationManager.Instance.items.Remove(this);
    }
}
