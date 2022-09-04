namespace PierreARNAUDET.Core.Helpers
{
    using UnityEngine;

    public class GraphUpdateAstarPath : MonoBehaviour
    {
        public void RecalculateAllGraph()
        {
            AstarPath.active.Scan();
        }
    }
}
