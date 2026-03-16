using UnityEngine;

public class Collectable : MonoBehaviour
{
    public string tagToCompare = "Player";
    public ParticleSystem particles;
    public GameObject mesh;
    public AudioSource audioSource;
    public bool isDestroyable = true;
    public float timeToDestroy;
    public bool collected = false;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag(tagToCompare))
        {
            if (collected) return;
            Collect();
        }
    }

    protected virtual void Collect()
    {
        if (collected) return;
        collected = true;
        OnCollect();
        if (isDestroyable) Invoke(nameof(DestroyMe), timeToDestroy);
    }
    protected virtual void OnCollect()
    {
        if (particles != null)
        {
            particles.transform.SetParent(null);
            particles.Play();
        }
        if (mesh != null) mesh.SetActive(false);
        if (audioSource != null) audioSource.Play();
    }

    private void DestroyMe()
    {
        Destroy(gameObject);
    }
}
