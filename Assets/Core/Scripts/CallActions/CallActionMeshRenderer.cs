namespace PierreARNAUDET.Core.CallActions
{
    using UnityEngine;

    public class CallActionMeshRenderer : MonoBehaviour
    {
        [Header("Data")]
        [SerializeField] MeshRenderer meshRenderer;
        public MeshRenderer MeshRenderer { get => meshRenderer; set => meshRenderer = value; }

        #region Material
        [Header("Data : Material")]
        [SerializeField] Material material;
        public Material Material { get => material; set => material = value; }
        [SerializeField] int materialIndex;
        public int MaterialIndex { get => materialIndex; set => materialIndex = value; }

        /// <summary>
        /// Change material of the referenced mesh renderer with already given
        /// </summary>
        public void SetMaterial()
        {
            SetMaterial(material);
        }

        /// <summary>
        /// Change material of the referenced mesh renderer
        /// </summary>
        /// <param name="newMaterial">New material set on the mesh renderer</param>
        public void SetMaterial(Material newMaterial)
        {
            Material[] materials = meshRenderer.materials;
            materials[materialIndex] = newMaterial;
            meshRenderer.materials = materials;
        }
        #endregion region
    }
}