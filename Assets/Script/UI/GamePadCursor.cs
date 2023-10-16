using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class GamePadCursor : MonoBehaviour
{
    private UIInputReader inputReader;
    private InteractiveUI interactiveUI;
    private bool isClick;
    private float speed;
    private float minSpeed = 100;
    private float maxSpeed = 700;

    private void Start()
    {
        inputReader = GameManager.sceneController.UIInputReader;
    }

    private void Update()
    {
        transform.position += new Vector3(inputReader.Stick.x, inputReader.Stick.y, 0).normalized * speed * Time.deltaTime;

        if (inputReader.Stick != Vector2.zero)
        {
            speed = Mathf.Min(speed += 150 * Time.deltaTime, maxSpeed);
        }
        else
        {
            speed = minSpeed;
        }

        if (inputReader.isInteractive)
        {
            if (isClick)
            {
                OnHold();
            }
            else
            {
                OnPress();
                isClick = true;
            }
        }
        else if (isClick)
        {
            OnUnlash();
            isClick = false;
        }
    }

    private void OnPress()
    {
        Debug.Log("A");

        interactiveUI = CursorEvent(transform.position).GetComponent<InteractiveUI>();

        if (interactiveUI)
        {
            interactiveUI.OnPress();
        }
    }

    private void OnHold()
    {
        Debug.Log(CursorEvent(transform.position) + "B");

        if (interactiveUI)
        {
            interactiveUI.OnHold(transform.position);
        }
    }

    private void OnUnlash()
    {
        Debug.Log(CursorEvent(transform.position) + "C");

        if (interactiveUI)
        {
            interactiveUI.OnUnlash(CursorEvent(transform.position));
            interactiveUI = null;
        }
    }

    public GameObject CursorEvent(Vector2 position)
    {
        EventSystem eventSystem = EventSystem.current;
        PointerEventData pointerEventData = new PointerEventData(eventSystem);
        pointerEventData.position = position;

        List<RaycastResult> uiRaycastResultCache = new List<RaycastResult>();
        eventSystem.RaycastAll(pointerEventData, uiRaycastResultCache);
        if (uiRaycastResultCache.Count > 0)
            return uiRaycastResultCache[0].gameObject;
        return null;
    }
}
