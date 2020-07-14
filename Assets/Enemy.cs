using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    float _speed = 2f;
    float _yBounds = 5f;
    float _xBounds = 9f;
    string direction = "";
    // Start is called before the first frame update

    string[] directions = { "Up", "Down", "Left", "Right" };

    void Start()
    {
        int dir = Random.Range(0, 4);
        this.direction = directions[dir];

        TextMeshProUGUI textmeshPro = GetComponentInChildren<TextMeshProUGUI>();
        if (textmeshPro)
        {
            textmeshPro.SetText("" + direction.ToUpper());
        }
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerMovement player = other.transform.GetComponent<PlayerMovement>();

            if (player)
            {
                player.Damage(this.direction); // Todo: determine if different enemies damage different controls
            }

            Destroy(this.gameObject);
        }

        /*if (other.CompareTag("Bullet"))
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }*/
    }
}
