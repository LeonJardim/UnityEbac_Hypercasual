using Leon.Core.Singleton;
using TMPro;
using UnityEngine;

public class ItemManager : Singleton<ItemManager>
{
    public SOInt coins;

    private void Start()
    {
        ResetItems();
    }

    private void ResetItems()
    {
        coins.Value = 0;
    }

    public void AddCoins(int amount = 1)
    {
        coins.Value += amount;
    }
}
