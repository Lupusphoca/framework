namespace PierreARNAUDET.Core.PlayerPreferences.Injectors
{
    using UnityEngine;

    using PierreARNAUDET.Core.Injectors;
    using PierreARNAUDET.Core.PlayerPreferences.Models;
    using PierreARNAUDET.Core.Events;

    class StringPlayerPrefInjector : UInjector<StringPlayerPref>
    {
        [SerializeField] StringPlayerPref stringPlayerPref;
        public override StringPlayerPref ObjToInject { get => stringPlayerPref; set => stringPlayerPref = value; }

        [SerializeField] StringEvent @string;

        protected override void InjectObject(StringPlayerPref obj) => @string.Invoke(obj.Value);
    }
}