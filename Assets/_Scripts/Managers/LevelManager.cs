using Leon.Core.Singleton;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    public Transform container;
    public List<GameObject> levels;

    [SerializeField] private int _index = 0;
    private GameObject _currentLevel;

    protected override void Awake()
    {
        base.Awake();
        SpawnNextLevel();

        transform.SetParent(null);
        DontDestroyOnLoad(gameObject);
    }

    public void SpawnNextLevel()
    {
        if (_currentLevel != null)
        {
            Destroy(_currentLevel);
            _index++;

            if (_index >= levels.Count)
            {
                _index = 0;
            }
        }

        _currentLevel = Instantiate(levels[_index], container);
        _currentLevel.transform.localPosition = Vector3.zero;
    }

    public void RestartLevel()
    {
        if (_currentLevel) Destroy(_currentLevel);

        _currentLevel = Instantiate(levels[_index], container);
        _currentLevel.transform.localPosition = Vector3.zero;
    }
}
