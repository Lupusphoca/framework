namespace PierreARNAUDET.Core.Mathematics
{
    using UnityEngine;

    using PierreARNAUDET.Core.Events;

    public class Vector3Lerp : MonoBehaviour
    {
        [Header ("Data")]
        [SerializeField] Vector3 actuelVector3;
        public Vector3 ActuelVector3 { get => actuelVector3; set => actuelVector3 = value; }
        [SerializeField] Vector3 desiredVector3;
        public Vector3 DesiredVector3 { get => desiredVector3; set => desiredVector3 = value; }
        [SerializeField] float lerpSpeed;
        public float LerpSpeed { get => lerpSpeed; set => lerpSpeed = value; }

        [Header ("Events")]
        [SerializeField] Vector3Event result;

        public void Lerp ()
        {
            if (actuelVector3 == Vector3.zero || desiredVector3 == Vector3.zero || lerpSpeed == 0)
            {
                Debug.LogWarning("One data is maybe missing !");
            }
            Vector3 vector3 = Vector3.Lerp(actuelVector3, desiredVector3, lerpSpeed);
            result.Invoke(vector3);
        }
    }
}