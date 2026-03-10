using UnityEngine;

public class CollectableCoin : Collectable
{
    [Header("Coin")]
    [SerializeField] private float _lerp = 5.0f;
    [SerializeField] private float _minDistance = 1.0f;

    protected override void OnCollect()
    {
        base.OnCollect();
        ItemManager.Instance.AddCoins();
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
}
