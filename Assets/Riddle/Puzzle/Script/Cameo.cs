using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Cameo : InteractiveUI, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    private Vector3 originPos;
    [SerializeField] Image image;
    private Hole hole;
    [SerializeField] private int count;

    [SerializeField] private AudioLogic audioLogic;

    private bool isHold;

    private void OnEnable()
    {
        originPos = transform.position;
    }

    public override void OnPress()
    {
        audioLogic.PlayAudio("Select");
        transform.localScale = Vector3.one * 0.8f;
        image.raycastTarget = false;

        if (hole)
        {
            hole.DisMosaic();
            hole = null;
        }
    }

    public override void OnHold(Vector3 pos)
    {
        transform.position = pos;
    }

    public override void OnUnlash(GameObject gameObject)
    {
        audioLogic.PlayAudio("Embed");

        Vector3 targetPos = new Vector3();

        transform.localScale = Vector3.one;

        if (gameObject.tag == "Hole")
        {
            targetPos = gameObject.transform.position;

            hole = gameObject.GetComponent<Hole>();

            transform.position = targetPos;

            transform.localScale = Vector3.one * 0.3f;

            hole.OnMosaic(count);
        }
        else
        {
            targetPos = originPos;

            transform.localScale = Vector3.one;

            transform.position = targetPos;
        }

        image.raycastTarget = true;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnPress();
    }

    public void OnDrag(PointerEventData eventData)
    {
        OnHold(eventData.position);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        OnUnlash(eventData.pointerCurrentRaycast.gameObject);
    }

    public void OnReset()
    {
        transform.localScale = Vector3.one;
        hole = null;

        transform.position = originPos;
    }
}
