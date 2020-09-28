namespace PierreARNAUDET.Core.Events
{
    using System;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Events;
    using UnityEngine.EventSystems;

    using PierreARNAUDET.Core.ScriptableObjects.Models;

    #region singular
    [Serializable] public class BoolEvent : UnityEvent<bool> { }
    [Serializable] public class BoundsEvent : UnityEvent<Bounds> { }
    [Serializable] public class ColliderEvent : UnityEvent<Collider> { }
    [Serializable] public class Collider2DEvent : UnityEvent<Collider2D> { }
    [Serializable] public class CollisionDetectionMode2DEvent : UnityEvent<CollisionDetectionMode2D> { }
    [Serializable] public class CompositeCollider2DEvent : UnityEvent<CompositeCollider2D> { }
    [Serializable] public class FloatEvent : UnityEvent<float> { }
    [Serializable] public class GameObjectEvent : UnityEvent<GameObject> { }
    [Serializable] public class GradientEvent : UnityEvent<Gradient> { }
    [Serializable] public class IntEvent : UnityEvent<int> { }
    [Serializable] public class PhysicsMaterial2DEvent : UnityEvent<PhysicsMaterial2D> { }
    [Serializable] public class PointerEventDataEvent : UnityEvent<PointerEventData> { }
    [Serializable] public class QuaternionEvent : UnityEvent<Quaternion> { }
    [Serializable] public class RaycastHitEvent : UnityEvent<RaycastHit> { }
    [Serializable] public class RigidbodyEvent : UnityEvent<Rigidbody> { }
    [Serializable] public class Rigidbody2DEvent : UnityEvent<Rigidbody2D> { }
    [Serializable] public class RigidbodyConstraints2DEvent : UnityEvent<RigidbodyConstraints2D> { }
    [Serializable] public class RigidbodyInterpolation2DEvent : UnityEvent<RigidbodyInterpolation2D> { }
    [Serializable] public class RigidbodySleepMode2DEvent : UnityEvent<RigidbodySleepMode2D> { }
    [Serializable] public class RigidbodyType2DEvent : UnityEvent<RigidbodyType2D> { }
    [Serializable] public class StringEvent : UnityEvent<string> { }
    [Serializable] public class TransformEvent : UnityEvent<Transform> { }
    [Serializable] public class Vector2Event : UnityEvent<Vector2> { }
    [Serializable] public class Vector3Event : UnityEvent<Vector3> { }
    #endregion

    #region multiple
    [Serializable] public class Vector3ListEvent : UnityEvent<List<Vector3>> { }
    [Serializable] public class Vector3ArrayEvent : UnityEvent<Vector3[]> { }
    #endregion

    #region singular scriptable
    #endregion

    #region multiple scriptable
    [Serializable] public class ListVector3ScriptableObjectEvent : UnityEvent<ListVector3ScriptableObject> { }
    #endregion
}