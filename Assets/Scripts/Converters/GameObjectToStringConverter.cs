namespace Core.Converters
{
    using UnityEngine;
    using UnityEngine.Events;

    using Core.Events;

    public class GameObjectToStringConverter : UConverter<GameObject, string>
    {
        [Header("Events")]
        [SerializeField] StringEvent stringConverted;

        protected override UnityEvent<string> ObjectConverted => stringConverted;

        protected override string ConvertObject(GameObject obj)
        {
            return obj.name;
        }
    }
}
