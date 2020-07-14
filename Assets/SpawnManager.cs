using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyPrefab;

    [SerializeField]
    private GameObject _controlInputPrefab;

    [SerializeField]
    private GameObject _enemyContainer;

    [SerializeField]
    private TextMeshProUGUI _lose;

    private bool _stopSpawning = false;

    private string[] _upControls = new string[] { "w", "3", "e" };
    private string[] _downControls = new string[] { "s", "x", "c" };
    private string[] _rightControls = new string[] { "d", "f", "g" };
    private string[] _leftControls = new string[] { "a", "q", "z" };


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
            Vector3 posToSpawn = new Vector3(8f, Random.Range(-4f, 4f), 0);
            GameObject newControl = Instantiate(_controlInputPrefab, posToSpawn, Quaternion.identity) as GameObject;
            
            if (newControl)
            {
                int direction = Random.Range(0, 4);

                switch (direction)
                {
                    case 0: //Right
                        {
                            string randomKeyPress = _rightControls[Random.Range(0, _rightControls.Length)];
                            newControl.GetComponent<ControlInput>().keyPress = randomKeyPress;
                            newControl.GetComponent<ControlInput>().controlDirection = "Right";

                            var scriptRef = newControl.GetComponent<ControlInput>();

                            if (scriptRef != null)
                            {
                                scriptRef.UpdateText();
                            }

                            break;
                        }
                    case 1: //Left
                        {
                            string randomKeyPress = _leftControls[Random.Range(0, _leftControls.Length)];
                            newControl.GetComponent<ControlInput>().keyPress = randomKeyPress;
                            newControl.GetComponent<ControlInput>().controlDirection = "Left";
                            var scriptRef = newControl.GetComponent<ControlInput>();

                            if (scriptRef != null)
                            {
                                scriptRef.UpdateText();
                            }
                            break;
                        }
                    case 2: //Up
                        {
                            string randomKeyPress = _upControls[Random.Range(0, _upControls.Length)];
                            newControl.GetComponent<ControlInput>().keyPress = randomKeyPress;
                            newControl.GetComponent<ControlInput>().controlDirection = "Up";
                            var scriptRef = newControl.GetComponent<ControlInput>();

                            if (scriptRef != null)
                            {
                                scriptRef.UpdateText();
                            }
                            break;
                        }
                    case 3: //Down
                        {
                            string randomKeyPress = _downControls[Random.Range(0, _downControls.Length)];
                            newControl.GetComponent<ControlInput>().keyPress = randomKeyPress;
                            newControl.GetComponent<ControlInput>().controlDirection = "Down";
                            var scriptRef = newControl.GetComponent<ControlInput>();

                            if (scriptRef != null)
                            {
                                scriptRef.UpdateText();
                            }
                            break;
                        }
                    default:
                        {
                            string randomKeyPress = _rightControls[Random.Range(0, _rightControls.Length)];
                            newControl.GetComponent<ControlInput>().keyPress = randomKeyPress;
                            newControl.GetComponent<ControlInput>().controlDirection = "Right";
                            var scriptRef = newControl.GetComponent<ControlInput>();

                            if (scriptRef != null)
                            {
                                scriptRef.UpdateText();
                            }
                            break;
                        }
                }


            }

            newControl.transform.parent = _enemyContainer.transform;


            yield return new WaitForSeconds(Random.Range(3, 8));
        }
    }

    public void OnPlayerDeath()
    {
        Debug.Log("STOP");
        _stopSpawning = true;

        StartCoroutine(EndGameRoutine());
    }

    IEnumerator EndGameRoutine()
    {
        Debug.Log("EndGameRoutine");

        this._lose.enabled = true;
        _lose.gameObject.SetActive(true);

        yield return new WaitForSeconds(10f);

        SceneManager.LoadScene(0);

    }
}
