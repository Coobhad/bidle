using UnityEngine;
using UnityEngine.UI;

public class ButtonClickHandler : MonoBehaviour
{
    public Text scoreText;
    public GameObject cursorText;
    private bool isVisible;

    private void Start()
    {
        scoreText.text = "";
        isVisible = false;
    }

    private void Update()
    {
        if (isVisible)
        {
            cursorText.transform.position = Input.mousePosition;
        }
    }

    public void OnButtonClick()
    {
        isVisible = !isVisible;
        scoreText.text = isVisible ? "+1" : "";
    }
}