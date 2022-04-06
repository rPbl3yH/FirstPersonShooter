using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Spawner : MonoBehaviour
{
    [SerializeField] Canvas _canvas;
    [SerializeField] GameObject _prefabGameObj;

    [SerializeField] float _startTime;
    [SerializeField] float _intervalTimeSpawn;
    // Start is called before the first frame update
    void Start()
    {
        _canvas = GameObject.FindGameObjectWithTag("Canvas").GetComponent<Canvas>();
        InvokeRepeating("SpawnCharacter", _startTime, _intervalTimeSpawn);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnCharacter()
    {
        GameObject gameObject = Instantiate(_prefabGameObj, transform.position, Quaternion.identity);
        gameObject.GetComponent<Character>().CanvasUI = _canvas;
        
    }
}
