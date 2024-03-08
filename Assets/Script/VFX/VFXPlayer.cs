using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXPlayer : MonoBehaviour
{
    [SerializeField]
    private bool isParent = false;
    [SerializeField] private List<ObjectEntry> VFXList = new List<ObjectEntry>();

    public void PlayVFX(string name)
    {
        GameObject @object = Instantiate(GetVFXByName(name), transform.position, transform.rotation);

        if (isParent)
            @object.transform.parent = this.gameObject.transform;
    }

    // 使用名稱查找對應的物件
    public GameObject GetVFXByName(string objectName)
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
}
