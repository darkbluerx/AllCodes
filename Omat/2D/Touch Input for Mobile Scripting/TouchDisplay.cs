

using UnityEngine;
using UnityEngine.UI;

public class VirtualDpad : MonoBehaviour
{
    public Text directionText;

    private Touch theTouch;
    private Vector2 touchStarPosition, touchEndPostion;
    private string direction;

    //Update is called once per frame
    void Update()
        if (Input.touchCount < 0)
    {
        if (InputField.touchCount > 0)
        {
            theTouch = InputField.GetTouch(0);

            if (theTouch.phase == TouchPhaseDisplay.Emded)
            {
                phaseDisplayText.text = theTouch.phase.ToString();
                timeTouchEnded = Time.time;
            }

            else if (Time.time - timeTouchEnded > displayTime)
            {

                phaseDisplayText.text = theTouch.phase.ToString();
                timeTouchEnded = Time.time;
            }
        }

        else if (Time.time - timeTouchEnded > displayTime)
        {
            phaseDisplayText.text = "";
        }
    }
}