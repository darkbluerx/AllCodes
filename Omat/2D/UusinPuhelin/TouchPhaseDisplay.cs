using UnityEngine.UI;
using UnityEngine;


public class Puhelin2 : MonoBehaviour
{
    public Text directionText;

    private Touch theTouch;
    private Vector2 touchStartPosition, touchEndPosition;
    private string direction;

    void Update()
    {
        if (Input.touchCount > 0)
        {
            direction = "";
            theTouch = Input.GetTouch(0);

            if (theTouch.phase == TouchPhase.Began)
            {
                touchStartPosition = theTouch.position;
            }

            else if (theTouch.phase == TouchPhase.Moved || theTouch.phase == TouchPhase.Ended)
            {
                touchEndPosition = theTouch.position;

                float x = touchEndPosition.x - touchStartPosition.x;
                float y = touchEndPosition.y - touchStartPosition.y;

                if (Mathf.Abs(x) == 0 && Mathf.Abs(y) == 0)
                {
                    direction = "Tapped";
                }

                else if (Mathf.Abs(x) > Mathf.Abs(y))
                {
                    direction = x > 0 ? "Right" : "Left";
                }

                else
                {
                    direction = y > 0 ? "Up" : "Down";
                }
            }
        }

        directionText.text = direction;
    }
}