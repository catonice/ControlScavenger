using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIKeyInput : MonoBehaviour
{
    [SerializeField]
    string keyInput;
    // Start is called before the first frame update
    void Start()
    {
        TextMeshProUGUI textmeshPro = GetComponentInChildren<TextMeshProUGUI>();
        if (textmeshPro)
        {
            textmeshPro.SetText("" + keyInput.ToUpper());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateText(string keyPress)
    {
        keyInput = keyPress;
        TextMeshProUGUI textmeshPro = GetComponentInChildren<TextMeshProUGUI>();
        if (textmeshPro)
        {
            textmeshPro.SetText("" + keyPress.ToUpper());
        }
    }
}
