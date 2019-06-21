using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum HorizontalTouchPos { None = 0, Left, Right }
public enum VerticleTouchPos { None = 0, Up, Down, Middle }

public class InputController : MonoBehaviour
{

    public Text T1, T2;
    public HorizontalTouchPos horizPos;
    public VerticleTouchPos vertPos;
    int count = 0;

    Vector2 screenDimension;
    public Vector2 firstTouchPos = Vector2.zero, secondTouchPos = Vector2.zero;

    PlayerController thisController;

    void Start()
    {
        screenDimension = new Vector2(Screen.width, Screen.height);
        thisController = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckTouch();
        //if(Input.GetMouseButtonDown(0))
        //      {
        //          mousePosition = Input.mousePosition;
        //          CheckTouch();
        //          //HorizontalTouch();
        //          //VerticleTouch();
        //      }
    }
    void CheckTouch()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                firstTouchPos = touch.position;
                HorizontalTouch(firstTouchPos);
                count++;
                T1.text = "" + Input.touchCount+count;
                thisController.DoAction(firstTouchPos, secondTouchPos, (int)horizPos, (int)vertPos);
            }
            if (Input.touchCount == 2)
            {
                touch = Input.GetTouch(1);
                if (touch.phase == TouchPhase.Began)
                {
                    secondTouchPos = touch.position;
                    HorizontalTouch(secondTouchPos);
                    count++;
                    T2.text = "" + Input.touchCount + count;
                    thisController.DoAction(firstTouchPos, secondTouchPos, (int)horizPos, (int)vertPos);
                }
            }
        }
        else
        {
            T1.text = "" + Input.touchCount;
            T2.text = "" + Input.touchCount;
            count = 0;
        }
    }

    void HorizontalTouch(Vector2 pos)
    {
        if (pos.x > screenDimension.x / 2)
        {
            horizPos = HorizontalTouchPos.Right;
            secondTouchPos = pos;
            firstTouchPos = Vector2.zero;
        }
        else if (pos.x < screenDimension.x / 2)
        {
            horizPos = HorizontalTouchPos.Left;
            firstTouchPos = pos;
            secondTouchPos = Vector2.zero;
            VerticleTouch(pos);
        }
        else
        {
            horizPos = HorizontalTouchPos.None;
        }
    }
    void VerticleTouch(Vector2 verticlePos)
    {
        if (horizPos == HorizontalTouchPos.Right)
        {
            vertPos = VerticleTouchPos.None;
            return;
        }

        if (verticlePos.y > screenDimension.y / 2)
        {
            vertPos = VerticleTouchPos.Up;
        }
        else if (verticlePos.y < screenDimension.y / 2)
        {
            vertPos = VerticleTouchPos.Down;
        }
        else
        {
            vertPos = VerticleTouchPos.None;
        }
    }

}
