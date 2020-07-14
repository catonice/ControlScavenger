using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ControlInput : MonoBehaviour
{
    float _speed = 2f;
    float _yBounds = 5f;
    float _xBounds = 9f;

    public string keyPress;
    public string controlDirection;

    // Start is called before the first frame update
    void Start()
    {
        TextMeshProUGUI textmeshPro = GetComponentInChildren<TextMeshProUGUI>();
        if (textmeshPro)
        {
            textmeshPro.SetText("" + keyPress.ToUpper());
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

    public void UpdateText()
    {
        //Debug.Log("UPDATETEXT");
        TextMeshPro textmeshPro = GetComponentInChildren<TextMeshPro>();
        if (textmeshPro)
        {
            //Debug.Log("UPDATETEXT" + keyPress);
            textmeshPro.SetText(">" + keyPress);
        }
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

            //Debug.Log("Control Hit");
        }
    }
}
