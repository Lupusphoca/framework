namespace PierreARNAUDET.Core.Helpers
{
    using UnityEngine;
    using UnityEngine.Events;

    public class UniversalActionID : MonoBehaviour
    {
        int tmpValue = 0;
        int @int;
        public int @Int { get => @int; }

        [Header("Settings")]
        [SerializeField] int id;

        [Header("Events")]
        [SerializeField] UnityEvent unityEvent;

        private void Awake()
        {
            @int = id;
            var universalActionsID = FindObjectsOfType<UniversalActionID>();
            for (int i = 0; i < universalActionsID.Length; i++)
            {
                if (this.@int == universalActionsID[i].@Int)
                {
                    Debug.LogWarning($"Universal action with ID : {universalActionsID[i].@Int} already exist, reference an other one ! (Temporary set to value {tmpValue})");
                    @int = tmpValue;
                }
            }
        }

        public void CallAction()
        {
            unityEvent.Invoke();
        }
    }
}
//TODO Instead of using 'FindObjectsOfType' to search all the other UniversalActionID, use a scriptable where all UAID store themself at the Awake.
//TODO This script need an other one named "UniversalActionCaller", that will be used to call a specific UAID CallAction by using his ID.