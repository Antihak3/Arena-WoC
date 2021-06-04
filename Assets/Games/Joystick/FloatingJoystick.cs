using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[System.Serializable]
public enum JoyStickDirection { Horizontal, Vertical, Both}
public class FloatingJoystick : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    public JoyStickDirection JoystickDirection = JoyStickDirection.Both;
    public RectTransform Background;
    public RectTransform Handle;
    public RectTransform tochka;
    [Range(0, 2f)] public float HandleLimit = 1f;
    public Vector2 input = Vector2.zero;
    
    

    //Output
    public float Vertical { get { return input.y; } }
    public float Horizontal { get { return input.x; } }
   public  Vector2 JoyPosition = Vector2.zero;

    public void Update()
    {
        if (input == Vector2.zero)
        {
          
        }
    }


    public void OnPointerDown(PointerEventData eventdata)
    {
        Background.gameObject.SetActive(true);
        OnDrag(eventdata);
        JoyPosition = eventdata.position;
        Background.position = eventdata.position;
        Handle.anchoredPosition = Vector2.zero;
        input = Vector2.zero;

    }
    public void OnDrag(PointerEventData eventdata)
    {
        Vector2 JoyDriection = eventdata.position - JoyPosition;
        input = (JoyDriection.magnitude > Background.sizeDelta.x / 2f) ? JoyDriection.normalized :
            JoyDriection / (Background.sizeDelta.x / 2f);
        if (JoystickDirection == JoyStickDirection.Horizontal)
            input = new Vector2(input.x, 0f);
        if (JoystickDirection == JoyStickDirection.Vertical)
            input = new Vector2(0f, input.y);
        Handle.anchoredPosition = (input * Background.sizeDelta.x / 2f) * HandleLimit;
    }
    public void OnPointerUp(PointerEventData eventdata)
    {

        Background.position = tochka.position;
        input = Vector2.zero;
        Handle.anchoredPosition = Vector2.zero;
    }
}

