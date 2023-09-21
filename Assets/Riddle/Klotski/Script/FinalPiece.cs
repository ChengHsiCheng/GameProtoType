using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;
public class FinalPiece : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] Transform slotOriginParent;
    public event Action OnPassEvent;

    private void OnEnable()
    {
        KlotskiControll.pass = false;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        transform.SetParent(transform.parent.parent);
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }


    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (eventData.pointerCurrentRaycast.gameObject == null)
        {
            ResetToDefault();
            return;
        }
        if (KlotskiControll.correct && eventData.pointerCurrentRaycast.gameObject.GetComponent<KlotskiSlotItem>() != null)
        {

            if (eventData.pointerCurrentRaycast.gameObject.GetComponent<KlotskiSlotItem>().id == 9)
            {
                KlotskiControll.pass = true;
                GameObject slot = eventData.pointerCurrentRaycast.gameObject;
                transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform);
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

    public void ResetToDefault()
    {
        transform.SetParent(slotOriginParent);
        transform.position = slotOriginParent.position;
        GetComponent<CanvasGroup>().blocksRaycasts = true;

    }
}
