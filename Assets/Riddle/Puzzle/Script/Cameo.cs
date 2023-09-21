using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Cameo : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    private Vector3 originPos;
    [SerializeField] Image image;
    private Hole hole;
    [SerializeField] private int count;

    private void Start()
    {
        originPos = transform.position;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        transform.localScale = Vector3.one * 0.8f;
        image.raycastTarget = false;

        if (hole)
        {
            hole.DisMosaic();
            hole = null;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Vector3 targetPos = new Vector3();

        transform.localScale = Vector3.one;

        if (eventData.pointerCurrentRaycast.gameObject.tag == "Hole")
        {
            targetPos = eventData.pointerCurrentRaycast.gameObject.transform.position;

            hole = eventData.pointerCurrentRaycast.gameObject.GetComponent<Hole>();

            transform.position = targetPos;

            hole.OnMosaic(count);
        }
        else
        {
            targetPos = originPos;
            transform.position = targetPos;
        }

        image.raycastTarget = true;

    }

    public void OnReset()
    {
        hole = null;
        transform.position = originPos;
    }
}
