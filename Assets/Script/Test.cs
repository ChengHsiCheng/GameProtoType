using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class Test : MonoBehaviour
{

}

// public enum Type
// {
//     a, b, c
// }

// public abstract class Item : MonoBehaviour
// {
//     public virtual Vector3 pos { get; set; }
//     public virtual Vector3 impact { get; set; }
//     public abstract Type Type { get; set; }

//     public abstract void Enter();
//     public abstract void Tick();
//     public abstract void Exit();

//     public void SetImpact(Vector3 impact)
//     {
//         this.impact = impact;
//     }

//     public void SetPos(Vector3 pos)
//     {
//         this.pos = pos;
//     }
// }

// public class Item01 : Item
// {
//     public override Type Type { get; set; } = Type.b;
//     public Collider collider;

//     public override void Enter()
//     {
//         collider.enabled = false;
//     }
//     public override void Tick()
//     {
//         transform.position = pos;
//     }
//     public override void Exit()
//     {
//     }

// }

// public class Player
// {
//     public Item gameObject;

//     private void Update()
//     {
//         //按F取得物件
//         {
//             gameObject.Enter();

//             if (gameObject.Type == Type.a)
//             {
//                 Animation.setTigger("Trigger");

//                 canMove = false;

//                 //呼叫IEnumerator
//             }
//         }

//         //放開F移除物件
//         {
//             gameObject.Exit();


//             if (gameObject)
//             {
//                 gameObject.Tick();
//             }
//         }

//         public IEnumerator aEnter()
//         {
//             yield return new WaitForSeconds(1);

//             gameObject.SetImpact(Vector3.zero);

//             canMove = true;
//         }


//         public IEnumerator aExit()
//         {
//             yield return new WaitForSeconds(1);

//             gameObject.SetImpact(Vector3.zero);

//         }
//     }
