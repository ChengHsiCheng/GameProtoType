using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KlotskiSlotItem : InteractiveUI
{
    public int id;
    [HideInInspector] public bool contain;
    bool move;
    bool match = true;
    [SerializeField] KlotskiControll klotskiControll;
    Transform originItem;

    [SerializeField] private AudioLogic audioLogic;


    public void CheckAround()
    {
        switch (id)
        {
            case 1:
                GetSlotProperty(2, 4);
                break;
            case 2:
                GetSlotProperty(1, 3, 5);
                break;
            case 3:
                GetSlotProperty(2, 6);
                break;
            case 4:
                GetSlotProperty(1, 5, 7);
                break;
            case 5:
                GetSlotProperty(2, 4, 6, 8);
                break;
            case 6:
                GetSlotProperty(3, 5, 9);
                break;
            case 7:
                GetSlotProperty(4, 8);
                break;
            case 8:
                GetSlotProperty(5, 7, 9);
                break;
            case 9:
                GetSlotProperty(6, 8);
                break;
        }
    }
    public void GetSlotProperty(int id1, int id2, int id3, int id4)
    {
        int emptyID = 0;
        move = false;
        if (!klotskiControll.slotItems[id1 - 1].contain)
        {
            move = true;
            emptyID = id1;
        }
        if (!klotskiControll.slotItems[id2 - 1].contain)
        {
            move = true;
            emptyID = id2;
        }
        if (!klotskiControll.slotItems[id3 - 1].contain)
        {
            move = true;
            emptyID = id3;
        }
        if (!klotskiControll.slotItems[id4 - 1].contain)
        {
            move = true;
            emptyID = id4;
        }
        if (move)
            MoveToEmpty(emptyID);
    }
    public void GetSlotProperty(int id1, int id2, int id3)
    {
        int emptyID = 0;
        move = false;
        if (!klotskiControll.slotItems[id1 - 1].contain)
        {
            move = true;
            emptyID = id1;
        }

        if (!klotskiControll.slotItems[id2 - 1].contain)
        {
            move = true;
            emptyID = id2;
        }
        if (!klotskiControll.slotItems[id3 - 1].contain)
        {
            move = true;
            emptyID = id3;
        }
        if (move)
            MoveToEmpty(emptyID);
    }
    public void GetSlotProperty(int id1, int id2)
    {
        int emptyID = 0;
        move = false;
        if (!klotskiControll.slotItems[id1 - 1].contain)
        {
            move = true;
            emptyID = id1;
        }

        if (!klotskiControll.slotItems[id2 - 1].contain)
        {
            move = true;
            emptyID = id2;
        }
        if (move)
            MoveToEmpty(emptyID);
    }

    void MoveToEmpty(int emptyID)
    {
        Transform trans = transform.Find("Item");
        klotskiControll.slotItems[emptyID - 1].contain = true;
        contain = false;
        trans.SetParent(klotskiControll.slotItems[emptyID - 1].transform);
        trans.position = trans.parent.position;
        CheckPass(trans.GetComponent<KlotskiItem>(), emptyID);

        audioLogic.PlayAudio("Slip");
    }

    void CheckPass(KlotskiItem item, int emptyID)
    {
        int matchCount = 0;
        if (emptyID == item.id)
        {
            klotskiControll.slotItems[emptyID - 1].match = true;
        }
        else
        {
            match = false;
            klotskiControll.slotItems[emptyID - 1].match = false;

        }
        for (int i = 0; i < 9; i++)
        {
            if (klotskiControll.slotItems[i].match)
                matchCount++;
        }
        if (matchCount == 8)
            KlotskiControll.correct = true;
        else KlotskiControll.correct = false;
    }
    private void Start()
    {
        if (transform.Find("Item") != null)
            originItem = transform.Find("Item");
    }
    private void OnEnable()
    {
        ResetGame();
    }
    void ResetGame()
    {
        if (originItem != null)
        {
            originItem.SetParent(transform);
            originItem.position = transform.position;
        }
        if (id != 9)
            contain = true;
        else contain = false;

        KlotskiControll.correct = false;
        KlotskiControll.pass = false;
    }

    public override void OnPress()
    {
        CheckAround();
    }

    public override void OnHold(Vector3 pos)
    {
    }

    public override void OnUnlash(GameObject gameObject)
    {
    }
}
