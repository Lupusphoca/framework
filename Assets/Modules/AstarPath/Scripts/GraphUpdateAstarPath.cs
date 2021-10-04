namespace PierreARNAUDET.Core.Helpers
{
    using UnityEngine;
    using UnityEngine.Events;

    public class GraphUpdateAstarPath : MonoBehaviour
    {
        public void RecalculateAllGraph()
        {
            AstarPath.active.Scan();
        }
    }
}
