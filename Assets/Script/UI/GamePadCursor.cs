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
        UnityEngine.Cursor.visible = false;

        if (GameManager.controlMethod == ControlMethod.Keyboard)
            MouseOperate();

        if (GameManager.controlMethod == ControlMethod.Gamepad)
            GamePadOperate();
    }

    private void MouseOperate()
    {
        transform.position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);

        if (Input.GetMouseButton(0))
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

    private void GamePadOperate()
    {
        transform.position += new Vector3(inputReader.Stick.x, inputReader.Stick.y, 0).normalized * speed * Time.deltaTime;

        if (inputReader.isClick)
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


        if (inputReader.Stick != Vector2.zero)
        {
            speed = Mathf.Min(speed += 150 * Time.deltaTime, maxSpeed);
        }
        else
        {
            speed = minSpeed;
        }
    }

    private void OnPress()
    {
        Debug.Log(CursorEvent(transform.position));
        interactiveUI = CursorEvent(transform.position).GetComponent<InteractiveUI>();

        if (interactiveUI)
        {
            interactiveUI.OnPress();
        }
    }

    private void OnHold()
    {
        if (interactiveUI)
        {
            interactiveUI.OnHold(transform.position);
        }
    }

    private void OnUnlash()
    {
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
