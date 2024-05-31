using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GPT_PipesSpawner : MonoBehaviour
{
    [SerializeField] private float _maxTime = 3f;

    [SerializeField] private float _topHeightRange = 0.5f;
    [SerializeField] private float _bottomHeightRange = -0.4f;
    [SerializeField] private GameObject _pipes;
    [SerializeField] private float _verticalSpacing ; // Adjust this value for desired vertical spacing between pipes

    private float _timer;
    private float _lastPipeY;

    private void Start()
    {
        // Spawn the first pipe when the game starts
        //SpawnPipe();
        
        _timer = _maxTime; // Start the timer at max time to ensure immediate spawn
    }

    void Update()
    {
        // Update the timer
        _timer += Time.deltaTime;

        // Check if it's time to spawn a new pipe
        if (_timer >= _maxTime)
        {
            SpawnPipe();
            _timer = 0;
        }
    }

    private void SpawnPipe()
    {
        
        // Calculate the vertical position for the new pipe
        
        float newY = _lastPipeY;
        Vector2 spawnPos = new Vector2(2.5f, newY + Random.Range(_topHeightRange, _bottomHeightRange) );

        // Instantiate the new pipe
        GameObject pipe = Instantiate(_pipes, spawnPos, Quaternion.identity);

        // Update the last pipe position
        _lastPipeY = newY;

        // Destroy the pipe after a certain time
        Destroy(pipe, 10f);
    }
}
