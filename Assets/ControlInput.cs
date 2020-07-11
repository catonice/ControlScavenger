using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlInput : MonoBehaviour
{
    float _speed = 4f;
    float _yBounds = 5f;
    float _xBounds = 9f;

    public string keyPress;
    public string controlDirection;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * _speed * Time.deltaTime);

        if (transform.position.x <= -_xBounds)
        {
            float randomY = Random.Range(-_yBounds, _yBounds);
            transform.position = new Vector3(_xBounds, randomY, 0);
        }
    }

    public void ConstructControlInput(string keyPress, string controlDirection)
    {
        Debug.Log(keyPress + controlDirection);
        this.controlDirection = controlDirection;
        this.keyPress = keyPress;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerMovement player = other.transform.GetComponent<PlayerMovement>();

            if (player)
            {
                player.AddControl(this.keyPress, this.controlDirection); // Todo: determine if different enemies damage different controls
            }

            Destroy(this.gameObject);

            Debug.Log("Control Hit");
        }
    }
}
