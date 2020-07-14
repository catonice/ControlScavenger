using UnityEngine;
using UnityEngine.UI;

public class ControlDisplay : MonoBehaviour
{
    public Text controlsText;

    public void SetNumberOfControls(int controls) {
        controlsText.text = "Control Score: " + controls.ToString();
    }
}
