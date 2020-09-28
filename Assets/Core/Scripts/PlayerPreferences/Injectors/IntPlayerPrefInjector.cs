namespace PierreARNAUDET.Core.PlayerPreferences.Injectors
{
    using UnityEngine;

    using PierreARNAUDET.Core.Injectors;
    using PierreARNAUDET.Core.PlayerPreferences.Models;
    using PierreARNAUDET.Core.Events;

    class IntPlayerPrefInjector : UInjector<IntPlayerPref>
    {
        [SerializeField] IntPlayerPref intPlayerPref;
        public override IntPlayerPref ObjToInject { get => intPlayerPref; set => intPlayerPref = value; }

        [SerializeField] IntEvent @int;

        protected override void InjectObject(IntPlayerPref obj) => @int.Invoke(obj.Value);
    }
}