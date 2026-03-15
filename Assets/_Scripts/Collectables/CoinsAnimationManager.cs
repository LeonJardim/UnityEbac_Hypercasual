using System.Linq;
using DG.Tweening;
using Leon.Core.Singleton;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsAnimationManager : Singleton<CoinsAnimationManager>
{
    public List<CollectableCoin> items;

    [Header("Animation")]
    public float scaleDuration = 0.2f;
    public float timeBetweenPieces = 0.1f;
    public Ease ease = Ease.OutBack;

    protected override void Awake()
    {
        base.Awake();
        items = new List<CollectableCoin>();
    }

    public void RegisterCoin(CollectableCoin c)
    {
        if (!items.Contains(c))
        {
            items.Add(c);
            c.transform.localScale = Vector3.zero;
        }
    }

    public void UnRegisterCoin(CollectableCoin c)
    {
        if (!items.Contains(c))
        {
            items.Remove(c);
        }
    }


    IEnumerator ScalePiecesByTime()
    {
        foreach(var o in  items)
        {
            o.transform.localScale = Vector3.zero;
        }
        Sort();

        yield return null;

        foreach(var i in items)
        {
            if (i != null)
            {
                i.transform.DOScale(1, scaleDuration).SetEase(ease); 
                yield return new WaitForSeconds(timeBetweenPieces);
            }
        }

    }

    public void StartAnimations()
    {
        StartCoroutine(ScalePiecesByTime());
    }

    public void Sort()
    {
        items = items.OrderBy(
            x => Vector3.Distance(this.transform.position, x.transform.position)).ToList();
    }
}
