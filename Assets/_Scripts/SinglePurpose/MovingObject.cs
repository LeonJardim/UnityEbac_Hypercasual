using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class MovingObject : MonoBehaviour
{
    public List<Transform> positions;
    public float duration = 1.0f;

    private int _index = 0;

    private void Start()
    {
        if (positions[0] != null)
        {
            transform.position = positions[0].position;
            NextIndex();
        }

        StartCoroutine(StartMovement());
    }

    IEnumerator StartMovement()
    {
        float time;

        while (true)
        {
            Vector3 currentPosition = transform.position;
            time = 0.0f;

            while(time < duration)
            {
                transform.position = Vector3.Lerp(currentPosition, positions[_index].position, (time / duration));

                time += Time.deltaTime;
                yield return null;
            }
            NextIndex();

            yield return null;
        }
    }


    private void NextIndex()
    {
        _index++;
        if (_index >= positions.Count) _index = 0;
    }
}
