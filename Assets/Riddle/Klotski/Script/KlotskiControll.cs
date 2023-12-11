using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KlotskiControll : Riddle
{
    [SerializeField] public KlotskiSlotItem[] slotItems { get => GetComponentsInChildren<KlotskiSlotItem>(); }
    public static bool correct;
    public static bool pass;

    [SerializeField] FinalPiece finalPiece;

    private void OnEnable()
    {
        finalPiece.OnPassEvent += OnPass;
    }

    private void OnDisable()
    {
        finalPiece.OnPassEvent -= OnPass;

    }

}
