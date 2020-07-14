using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    float _speed = 5f;
    int _controlInputs = 1;
    float _yBounds = 4.5f;
    float _xBounds = 8.4f;

    string downInput;
    string leftInput;
    string rightInput;
    string upInput;

    List<string> downInputs = new List<string>();
    List<string> leftInputs = new List<string>();
    List<string> rightInputs = new List<string>();
    List<string> upInputs = new List<string>();

    private float _fireRate = 0.5f;
    private float _canFire = -1f;

    [SerializeField]
    private GameObject _bulletPrefab;

    [SerializeField]
    private ControlDisplay _controlDisplay;

    [SerializeField]
    private ControlManager _controlManager;

    private SpawnManager _spawnManager;


    // Start is called before the first frame update
    void Start()
    {
        _controlDisplay.SetNumberOfControls(_controlInputs - 1);

        AddControl("w", "Up");
        AddControl("s", "Down");
        AddControl("a", "Left");
        AddControl("d", "Right");

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
        float verticalInput = 0;

        if (rightInput != null)
        {
            if (Input.GetKey(rightInput))
            {
                //Debug.Log(rightInput + " key was pressed");
                horizontalInput = 1;
            }
        }

        if (leftInput != null)
        {
            if (Input.GetKey(leftInput))
            {
                //Debug.Log(leftInput + " key was pressed");
                horizontalInput = -1;
            }
        }

        if (downInput != null)
        {
            if (Input.GetKey(downInput))
            {
                //Debug.Log(downInput + " key was pressed");
                verticalInput = -1;
            }
        }

        if (upInput != null)
        {
            if (Input.GetKey(upInput))
            {
                //Debug.Log(upInput + " key was pressed");
                verticalInput = 1;
            }
        }

        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);

        transform.Translate(direction * _speed * Time.deltaTime);

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -_xBounds, _xBounds), Mathf.Clamp(transform.position.y, -_yBounds, _yBounds), 0);

        if (Input.GetMouseButton(0) && Time.time > _canFire)
        {
            FireBullet();
        }
    }

    public void AddControl(string keyPress, string controlDirection)
    {

        _controlInputs += 1; // Add Controls

        _controlDisplay.SetNumberOfControls(_controlInputs - 1);

        if (controlDirection == "Down")
        {
            _controlManager.AddControl(keyPress, controlDirection);

            if (this.downInput != null)
            {
                this.downInputs.Add(keyPress); // Add to list
            }
            else
            {
                this.downInput = keyPress; // Set as current
                this.downInputs.Add(keyPress);
            }
        }

        if (controlDirection == "Right")
        {
            _controlManager.AddControl(keyPress, controlDirection);

            if (this.rightInput != null)
            {
                this.rightInputs.Add(keyPress); // Add to list
            }
            else
            {
                this.rightInput = keyPress;
                this.rightInputs.Add(keyPress);
            }
        }

        if (controlDirection == "Up")
        {

            _controlManager.AddControl(keyPress, controlDirection);

            if (this.upInput != null)
            {
                this.upInputs.Add(keyPress); // Add to list
            }
            else
            {
                this.upInput = keyPress;
                this.upInputs.Add(keyPress);
            }
        }

        if (controlDirection == "Left")
        {
            _controlManager.AddControl(keyPress, controlDirection);

            if (this.leftInput != null)
            {
                this.leftInputs.Add(keyPress); // Add to list
            }
            else
            {
                this.leftInput = keyPress;
                this.leftInputs.Add(keyPress);
            }
        }

        //Debug.Log(keyPress + controlDirection);
    }

    void FireBullet()
    {
        _canFire = Time.time + _fireRate;

        Vector3 setDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        GameObject bullet1 = Instantiate(_bulletPrefab, transform.position + new Vector3(0.643f, 0, 0), Quaternion.identity);

        var bullet = bullet1.GetComponent<BulletScript>();

        if (bullet)
        {
            bullet.GetComponent<BulletScript>().SetDirection(setDirection);
        }

        _canFire = Time.time + _fireRate;
    }

    public void Damage(string direction)
    {
        bool isDead = false;

        switch (direction)
        {
            case "Up":
                {
                    isDead = this._controlManager.RemoveControlDirection("Up");
                    Debug.Log("COUNT: " + this.upInputs.Count());
                    if (this.upInputs.Count() > 0)
                    {
                        this.upInputs.RemoveAt(0);
                        if (this.upInputs.Count() == 0)
                        {
                            this.upInput = null;
                        }
                        else
                        {
                            this.upInput = this.upInputs[0];
                        }
                    }
                    else
                    {
                        this.upInput = null;
                    }

                    break;
                }
            case "Down":
                {
                    isDead = this._controlManager.RemoveControlDirection("Down");

                    if (this.downInputs.Count() > 0)
                    {
                       this.downInputs.RemoveAt(0);
                        if (this.downInputs.Count() == 0)
                        {
                            this.downInput = null;
                        }
                        else
                        {
                            this.downInput = this.downInputs[0];
                        }
                    }
                    else
                    {
                        this.downInput = null;
                    }
                    break;
                }
            case "Left":
                {
                    isDead = this._controlManager.RemoveControlDirection("Left");

                    if (this.leftInputs.Count() > 0)
                    {
                        this.leftInputs.RemoveAt(0);
                        if (this.leftInputs.Count() == 0)
                        {
                            this.leftInput = null;
                        }
                        else
                        {
                            this.leftInput = this.leftInputs[0];
                        }
                    }
                    else
                    {
                        this.leftInput = null;
                    }
                    break;
                }
            case "Right":
                {
                    isDead = this._controlManager.RemoveControlDirection("Right");

                    if (this.rightInputs.Count() > 0)
                    {
                        this.rightInputs.RemoveAt(0);
                        if (this.rightInputs.Count() == 0)
                        {
                            this.rightInput = null;
                        }
                        else
                        {
                            this.rightInput = this.rightInputs[0];
                        }
                    }
                    else
                    {
                        this.rightInput = null;
                    }
                    break;
                }
            default:
                {
                    break;
                }
        }

        _controlInputs -= 1;

        if (_controlInputs < 1 || isDead)
        {
            Debug.Log("DIED");

            if (_spawnManager)
            {
                Debug.Log("DIED SPAWN");
                _spawnManager.OnPlayerDeath();
            }

            Destroy(this.gameObject);
        }
    }
}
