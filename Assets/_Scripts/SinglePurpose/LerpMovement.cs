using UnityEngine;

public class LerpMovement : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float lerpSpeed;

    private void Update()
    {
        if (target == null) return;
        if (!PlayerController.Instance.canRun) return;
        transform.position = Vector3.Lerp(transform.position, target.position, lerpSpeed * Time.deltaTime);
    }
}
