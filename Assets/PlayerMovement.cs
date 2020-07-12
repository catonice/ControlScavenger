using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    float _speed = 10f;
    int _controlInputs = 1;
    float _yBounds = 4.5f;
    float _xBounds = 8.4f;

    string downInput;
    string leftInput;
    string rightInput;
    string upInput;
    
    string[] downInputs = new string[] { };
    string[] leftInputs = new string[] { };
    string[] rightInputs = new string[] { };
    string[] upInputs = new string[] { };



    [SerializeField]
    private GameObject _bulletPrefab;

    [SerializeField]
    private ControlDisplay _controlDisplay;

    private SpawnManager _spawnManager;


    // Start is called before the first frame update
    void Start()
    {
        _controlDisplay.SetNumberOfControls(_controlInputs);

        transform.position = new Vector3(0, 0, 0);

        _spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();

        if (!_spawnManager)
        {
            Debug.LogError("The Spawn Manager is NULL.");
        }
    }

    // Update is called once per framel
    void Update()
    {
        float horizontalInput = 0; // Change to allow different key inputs
        float verticalInput = Input.GetAxis("Vertical");

        if (rightInput != null)
        {
            if (Input.GetKey(rightInput))
            {
                Debug.Log(rightInput + " key was pressed");
                horizontalInput = 1;
            }
        }

        if (leftInput != null)
        {
            if (Input.GetKey(leftInput))
            {
                Debug.Log(leftInput + " key was pressed");
                horizontalInput = -1;
            }
        }

        if (downInput != null)
        {
            if (Input.GetKey(downInput))
            {
                Debug.Log(downInput + " key was pressed");
                verticalInput = -1;
            }
        }

        if (upInput != null)
        {
            if (Input.GetKey(upInput))
            {
                Debug.Log(upInput + " key was pressed");
                verticalInput = 1;
            }
        }

        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);

        transform.Translate(direction * _speed * Time.deltaTime);

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -_xBounds, _xBounds), Mathf.Clamp(transform.position.y, -_yBounds, _yBounds), 0);
    }

    public void AddControl(string keyPress, string controlDirection) {
        
        _controlInputs += 1; // Add Controls

        _controlDisplay.SetNumberOfControls(_controlInputs);

        if (controlDirection == "Down")
        {

            if (this.downInput != null)
            {
                this.downInputs.Append(keyPress); // Add to list
            }
            else
            {
                this.downInput = keyPress; // Set as current
            }
        }

        if (controlDirection == "Right")
        {
            if (this.rightInput != null)
            {
                this.rightInputs.Append(keyPress); // Add to list
            }
            else
            {
                this.rightInput = keyPress;
            }
        }

        if (controlDirection == "Up")
        {
            if (this.upInput != null)
            {
                this.upInputs.Append(keyPress); // Add to list
            }
            else
            {
                this.upInput = keyPress;
            }
        }

        if (controlDirection == "Left")
        {
            if (this.leftInput != null)
            {
                this.leftInputs.Append(keyPress); // Add to list
            }
            else
            {
                this.leftInput = keyPress;
            }
        }

        Debug.Log(keyPress + controlDirection);
    }

    void FireBullet() {
        /*_canFire = Time.time + _fireRate;

        Instantiate(_bulletPrefab, transform.position + new Vector3(1f, 0, 0), Quaternion.identity);*/
    }

    public void Damage() {

        _controlInputs -= 1;

        if(_controlInputs < 1)
        {
            // TODO: Uncomment
             Destroy(this.gameObject);

            if (_spawnManager)
            {
                _spawnManager.OnPlayerDeath();
            }
        }
    }
}
