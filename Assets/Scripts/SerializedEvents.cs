namespace Core.Events
{
    using System;
    using UnityEngine;
    using UnityEngine.Events;
    using UnityEngine.EventSystems;

    [Serializable] public class GameObjectEvent : UnityEvent<GameObject> { }
    [Serializable] public class PointerEventDataEvent : UnityEvent<PointerEventData> { }
    [Serializable] public class TransformEvent : UnityEvent<Transform> { }
}