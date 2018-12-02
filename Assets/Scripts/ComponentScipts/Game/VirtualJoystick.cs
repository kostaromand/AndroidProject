using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class VirtualJoystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    private Image bgImg;
    private Image joystickImg;
    private Vector3 inputVector;

    void Start()
    {
        bgImg = GetComponent<Image>();
        joystickImg = transform.GetChild(0).GetComponent<Image>();
    }

    public virtual void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public virtual void OnPointerUp(PointerEventData eventData)
    {
        inputVector = Vector3.zero;
        joystickImg.rectTransform.anchoredPosition = Vector3.zero;
    }

    public virtual void OnDrag(PointerEventData eventData)
    {
        Vector2 pos;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(bgImg.rectTransform, eventData.position, eventData.pressEventCamera, out pos))
        {
            
            pos.x = (pos.x / bgImg.rectTransform.rect.size.x) - 0.5f;
            pos.y = (pos.y / bgImg.rectTransform.rect.size.y) + 0.5f;
            Debug.Log(pos); 
            inputVector = new Vector3(pos.x * 2 + 1, pos.y * 2 - 1);
            inputVector = inputVector.magnitude > 1.0f ? inputVector.normalized : inputVector;
            joystickImg.rectTransform.anchoredPosition = new Vector3((inputVector.x) * (bgImg.rectTransform.rect.size.x / 3), inputVector.y * (bgImg.rectTransform.rect.size.y / 3));
        }
    }
    public float Horizontal()
    {
        if (inputVector.y != 0)
            return inputVector.x;
        else
            return Input.GetAxis("Horizontal");
    }

    public float Vertical()
    {
        if (inputVector.x != 0)
            return inputVector.y;
        else
            return Input.GetAxis("Vertical");
    }

    // Use this for initialization
}
