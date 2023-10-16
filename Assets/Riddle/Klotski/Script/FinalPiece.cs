using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;
public class FinalPiece : InteractiveUI, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] Transform slotOriginParent;
    public event Action OnPassEvent;

    private void OnEnable()
    {
        KlotskiControll.pass = false;
    }


    public override void OnPress()
    {
        transform.SetParent(transform.parent.parent);
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public override void OnHold(Vector3 pos)
    {
        transform.position = pos;
    }

    public override void OnUnlash(GameObject gameObject)
    {
        if (gameObject == null)
        {
            ResetToDefault();
            return;
        }
        if (KlotskiControll.correct && gameObject.GetComponent<KlotskiSlotItem>() != null)
        {

            if (gameObject.GetComponent<KlotskiSlotItem>().id == 9)
            {
                KlotskiControll.pass = true;
                GameObject slot = gameObject;
                transform.SetParent(gameObject.transform);
                transform.position = slot.transform.position;
                ResetToDefault();
                GetComponent<CanvasGroup>().blocksRaycasts = true;
                OnPassEvent?.Invoke();
            }
            else
            {
                ResetToDefault();
                GetComponent<CanvasGroup>().blocksRaycasts = true;
            }
        }
        else
        {
            ResetToDefault();
        }
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }


    public void OnBeginDrag(PointerEventData eventData)
    {
        OnPress();
    }

    public void OnDrag(PointerEventData eventData)
    {
        OnHold(eventData.position);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        OnUnlash(eventData.pointerCurrentRaycast.gameObject);
    }

    public void ResetToDefault()
    {
        transform.SetParent(slotOriginParent);
        transform.position = slotOriginParent.position;
        GetComponent<CanvasGroup>().blocksRaycasts = true;

    }

}
