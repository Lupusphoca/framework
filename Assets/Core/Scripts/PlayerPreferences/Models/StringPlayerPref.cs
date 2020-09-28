namespace PierreARNAUDET.Core.PlayerPreferences.Models
{
    using UnityEngine;

    [CreateAssetMenu(fileName = nameof(StringPlayerPref), menuName = "Core/PlayerPref/String")]
    public class StringPlayerPref : UPlayerPref<string> { }
}