using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipesSpawner : MonoBehaviour
{
    [SerializeField] private float _maxTime = 3f;
    private float _topHeightRange = 0.5f;
    private float _bottomHeightRange = -0.4f;
    [SerializeField] private GameObject _pipes;

    private float _timer;

    void Update()
    {
          if (_timer > _maxTime)
          {
              SpawnPipe();
              _timer = 0;
          }
          _timer += Time.deltaTime;

       
    }

     public void SpawnPipe()
    {
        /*
        Vector2 spawnpos =new Vector2(1, Random.Range(_topHeightRange, _bottomHeightRange));

        GameObject pipe = Instantiate(_pipes, spawnpos, Quaternion.identity );

        Destroy(pipe ,10f);
        */

        // Calculate the position for the new pipe
        float spawnY = Random.Range(_bottomHeightRange, _topHeightRange);
        Vector2 spawnpos = new Vector2(1, spawnY);

        // Instantiate the new pipe
        GameObject pipe = Instantiate(_pipes, spawnpos, Quaternion.identity);

        // Destroy the pipe after a certain time
        Destroy(pipe, 10f);

        // Update the bottom height range to prevent immediate spawning on top of previous pipes
        _bottomHeightRange = spawnY - 0.2f; // Adjust this value as needed for your game
        if (_bottomHeightRange < -1f) // Ensure the bottom height range does not go below a certain value
        {
            _bottomHeightRange = -1f;
        }
    }

}
