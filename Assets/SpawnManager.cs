using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyPrefab;

    [SerializeField]
    private GameObject _controlInputPrefab;

    [SerializeField]
    private GameObject _enemyContainer;

    private bool _stopSpawning = false;

    private string[] _upControls = new string[] { "w", "3", "5" };
    private string[] _downControls = new string[] { "s" };
    private string[] _rightControls = new string[] { "d" };

    void Start()
    {
        StartCoroutine(SpawnControlInputsRoutine());
        StartCoroutine(SpawnEnemyRoutine());
    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator SpawnEnemyRoutine()
    {
        while (!_stopSpawning)
        {
            Vector3 posToSpawn = new Vector3(8f, Random.Range(-4f, 4f), 0);
            GameObject newEnemy = Instantiate(_enemyPrefab, posToSpawn, Quaternion.identity);
            newEnemy.transform.parent = _enemyContainer.transform;
            yield return new WaitForSeconds(Random.Range(3, 8));
        }
    }

    private IEnumerator SpawnControlInputsRoutine()
    {
        while (!_stopSpawning)
        {
            string randomKeyPress = _rightControls[Random.Range(0, _rightControls.Length)];
            Vector3 posToSpawn = new Vector3(8f, Random.Range(-4f, 4f), 0);
            GameObject newControl = Instantiate(_controlInputPrefab, posToSpawn, Quaternion.identity) as GameObject;
            if (newControl)
            {
                newControl.GetComponent<ControlInput>().keyPress = randomKeyPress;
                newControl.GetComponent<ControlInput>().controlDirection = "Left";
            }

            newControl.transform.parent = _enemyContainer.transform;


            yield return new WaitForSeconds(Random.Range(3, 8));
        }
    }

    public void OnPlayerDeath()
    {
        _stopSpawning = true;
    }
}
