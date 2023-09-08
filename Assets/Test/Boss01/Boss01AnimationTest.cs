using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class Boss01AnimationTest : MonoBehaviour
{
    [field: SerializeField] public List<ObjectEntry> VFXList { get; private set; } = new List<ObjectEntry>();
    [field: SerializeField] public List<ObjectEntry> VFXPosList { get; private set; } = new List<ObjectEntry>();

    private VFXLiveTime nowVFX;

    private void OnPlayerVFX(string name)
    {
        Vector3 vfxPos = GetVFXPosByName(name).position;
        vfxPos.y = 0;
        nowVFX = Instantiate(GetVFXByName(name), GetVFXPosByName(name).transform).GetComponent<VFXLiveTime>();
    }

    private void DestroyVFX()
    {
        if (!nowVFX)
            return;

        nowVFX.Stop();
        Destroy(nowVFX.gameObject, 0.5f);
    }

    // 使用名稱查找對應的物件
    private GameObject GetVFXByName(string objectName)
    {
        ObjectEntry entry = VFXList.Find(e => e.name == objectName);
        if (entry.gameObject != null)
        {
            return entry.gameObject;
        }
        else
        {
            Debug.LogWarning("找不到名為 " + objectName + " 的物件。");
            return null;
        }
    }

    // 使用名稱查找對應的物件
    private Transform GetVFXPosByName(string objectName)
    {
        ObjectEntry entry = VFXPosList.Find(e => e.name == objectName);
        if (entry.gameObject != null)
        {
            return entry.gameObject.transform;
        }
        else
        {
            Debug.LogWarning("找不到名為 " + objectName + " 的物件。");
            return null;
        }
    }
}
