using UnityEngine;
using UnityEngine.UI;

public class ControlDisplay : MonoBehaviour
{
    public Text controlsText;

    public void SetNumberOfControls(int controls) {
        controlsText.text = "CONTROLS: " + controls.ToString();
    }
}
