using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextScroller : MonoBehaviour
{
    

    public float scrollSpeed;
    public bool scrolling = false;
    public float stopScrollPositionY;
    public float startScrollPositionY;
    private float restartTimeMarker = 0;
    public bool stopWithinView;
    public Vector2 startPosition;
    private float previousFloat;

    void Start()
    {
        //ResetPosition();
    }
       

    void Update()
    {        
        if (scrolling == true)
        {
            float newPosition = ((Time.time - restartTimeMarker) * scrollSpeed);
            transform.localPosition = startPosition + Vector2.up * newPosition;

            if (transform.localPosition.y >= stopScrollPositionY)
            {
                scrolling = false;
            }

        }       
    }



    public void ResetPosition()
    {
        var parentRectTransform = transform.parent.GetComponent<RectTransform>();
        var rectTransform = transform.GetComponent<RectTransform>();
        //Debug.Log("**************************rectTransform size delta y = " + rectTransform.sizeDelta.y);


        startScrollPositionY = 0;
        stopScrollPositionY = 0;

        startScrollPositionY = (parentRectTransform.rect.yMin - (rectTransform.sizeDelta.y / 2));

        stopScrollPositionY = parentRectTransform.rect.yMax;




        if (stopWithinView == true)
        {

            stopScrollPositionY = parentRectTransform.rect.yMin;
            stopScrollPositionY += (rectTransform.rect.height + 15);
        }
        else
        {
            stopScrollPositionY += (rectTransform.rect.height / 2);
        }
        //Debug.Log("stopScrollPosiiton = " + stopScrollPositionY);
        //Debug.Log("transform.position.y = " + transform.position.y);
        //Debug.Log("transform.localPosition.y = " + transform.localPosition.y);
        //Debug.Log("startposition.y= " + startPosition.y);
        //Debug.Log("startScrollPosition = " + startScrollPositionY);


        startPosition = new Vector3(0, startScrollPositionY, 0);
        Rect tempRect = transform.GetComponent<RectTransform>().rect;
        tempRect.yMax = parentRectTransform.rect.yMin;
        restartTimeMarker = Time.time;

    }

}
