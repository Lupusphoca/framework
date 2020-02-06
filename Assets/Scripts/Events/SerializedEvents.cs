namespace Core.Events
{
    using System;
    using UnityEngine;
    using UnityEngine.Events;
    using UnityEngine.EventSystems;

    [Serializable] public class BoolEvent : UnityEvent<bool> { }
    [Serializable] public class ColliderEvent : UnityEvent<Collider> { }
    [Serializable] public class FloatEvent : UnityEvent<float> { }
    [Serializable] public class GameObjectEvent : UnityEvent<GameObject> { }
    [Serializable] public class PointerEventDataEvent : UnityEvent<PointerEventData> { }
    [Serializable] public class QuaternionEvent : UnityEvent<Quaternion> { }
    [Serializable] public class RaycastHitEvent : UnityEvent<RaycastHit> { }
    [Serializable] public class RigidbodyEvent : UnityEvent<Rigidbody> { }
    [Serializable] public class StringEvent : UnityEvent<string> { }
    [Serializable] public class TransformEvent : UnityEvent<Transform> { }
    [Serializable] public class Vector3Event : UnityEvent<Vector3> { }
}