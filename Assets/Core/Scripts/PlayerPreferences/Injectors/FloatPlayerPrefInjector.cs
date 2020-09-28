namespace PierreARNAUDET.Core.PlayerPreferences.Injectors
{
    using UnityEngine;

    using PierreARNAUDET.Core.Injectors;
    using PierreARNAUDET.Core.PlayerPreferences.Models;
    using PierreARNAUDET.Core.Events;

    class FloatPlayerPrefInjector : UInjector<FloatPlayerPref>
    {
        [SerializeField] FloatPlayerPref floatPlayerPref;
        public override FloatPlayerPref ObjToInject { get => floatPlayerPref; set => floatPlayerPref = value; }

        [SerializeField] FloatEvent @float;

        protected override void InjectObject(FloatPlayerPref obj) => @float.Invoke(obj.Value);
    }
}