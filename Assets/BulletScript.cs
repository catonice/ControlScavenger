using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3f;

    private Vector3 direction = new Vector3(0, 0, 0);
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Translate laser up
        transform.Translate(direction * _speed * Time.deltaTime);

        float _yBounds = 5f;
        float _xBounds = 9f;

        if (transform.position.y > _yBounds || transform.position.y < -_yBounds || transform.position.x > _xBounds || transform.position.x < -_xBounds)
        {
            Destroy(this.gameObject);
        }
    }

    public void SetDirection(Vector3 setDirection)
    {
        this.direction = setDirection;
    }
}
