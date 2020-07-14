using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ControlManager : MonoBehaviour
{
    [SerializeField]
    VerticalLayoutGroup up;

    [SerializeField]
    VerticalLayoutGroup down;

    [SerializeField]
    VerticalLayoutGroup left;

    [SerializeField]
    VerticalLayoutGroup right;

    [SerializeField]
    public GameObject KeyIcon;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddControl(string keyPress, string direction)
    {
        GameObject keyIcon = Instantiate(KeyIcon) as GameObject;
        keyIcon.name = keyPress;

        var key = keyIcon.GetComponent<UIKeyInput>();

        if (key)
        {
            key.UpdateText("" + keyPress);
        }

        switch (direction)
        {
            case "Up":
                {
                    keyIcon.transform.SetParent(this.up.transform, false);
                    break;
                }
            case "Down":
                {
                    keyIcon.transform.SetParent(this.down.transform, false);
                    break;
                }
            case "Left":
                {
                    keyIcon.transform.SetParent(this.left.transform, false);
                    break;
                }
            case "Right":
                {
                    keyIcon.transform.SetParent(this.right.transform, false);
                    break;
                }
            default:
                {
                    keyIcon.transform.SetParent(this.up.transform, false);
                    break;
                }
        }
    }

    public void RemoveControl(string keyPress, string direction)
    {
        if (keyPress != null && direction != null)
        {
            switch (direction)
            {
                case "Up":
                    {
                        var keyIcon = this.up.transform.Find(keyPress);

                        if (keyIcon)
                        {
                            Destroy(keyIcon.gameObject);
                        }
                        break;
                    }
                case "Down":
                    {
                        var keyIcon = this.down.transform.Find(keyPress);
                        if (keyIcon)
                        {
                            Destroy(keyIcon);
                        }
                        break;
                    }
                case "Left":
                    {
                        var keyIcon = this.left.transform.Find(keyPress);
                        if (keyIcon)
                        {
                            Destroy(keyIcon);
                        }
                        break;
                    }
                case "Right":
                    {
                        var keyIcon = this.right.transform.Find(keyPress);
                        if (keyIcon)
                        {
                            Destroy(keyIcon);
                        }
                        break;
                    }
                default:
                    {
                        var keyIcon = this.up.transform.Find(keyPress);
                        if (keyIcon)
                        {
                            Destroy(keyIcon);
                        }
                        break;
                    }
            }
        }
    }
    
    public bool RemoveControlDirection(string direction)
    {
        if (direction != null)
        {
            switch (direction)
            {
                case "Up":
                    {
                        if (this.up.transform.childCount > 0)
                        {
                            var keyIcon = this.up.transform.GetChild(0);
                            var text = keyIcon.GetComponent<TextMeshProUGUI>();
                            if (text)
                            {
                                Debug.Log("REMOVED ITEM IS: " + keyIcon.GetComponent<TextMeshProUGUI>().text.ToString());
                            }

                            if (keyIcon)
                            {
                                Destroy(keyIcon.gameObject);
                            }
                        }
                        else
                        {
                            return true;
                        }
                        break;
                    }
                case "Down":
                    {
                        if (this.down.transform.childCount > 0)
                        {
                            var keyIcon = this.down.transform.GetChild(0);
                            if (keyIcon)
                            {
                                Destroy(keyIcon.gameObject);
                            }
                        }
                        else
                        {
                            return true;
                        }
                        break;
                    }
                case "Left":
                    {
                        if (this.left.transform.childCount > 0)
                        {
                            var keyIcon = this.left.transform.GetChild(0);
                            if (keyIcon)
                            {
                                Destroy(keyIcon.gameObject);
                            }
                        }
                        else
                        {
                            return true;
                        }
                        break;
                    }
                case "Right":
                    {
                        if (this.right.transform.childCount > 0)
                        {
                            var keyIcon = this.right.transform.GetChild(0);
                            if (keyIcon)
                            {
                                Destroy(keyIcon.gameObject);
                            }
                        }
                        else
                        {
                            return true;
                        }
                        break;
                    }
                default:
                    {
                        if (this.up.transform.childCount > 0)
                        {
                            var keyIcon = this.up.transform.GetChild(1);
                            if (keyIcon)
                            {
                                Destroy(keyIcon.gameObject);
                            }
                        }
                        else
                        {
                            return true;
                        }
                        break;
                    }
            }

            return false;
            
        }

        return false;
    }
}
