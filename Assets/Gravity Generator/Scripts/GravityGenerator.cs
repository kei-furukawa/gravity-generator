using UnityEngine;

namespace Gravity
{
    public class GravityGenerator : MonoBehaviour
    {
        [SerializeField] private float m_gravity = 9.8f;
        public float gravity {get {return m_gravity;}}

        private void OnTriggerEnter(Collider other)
        {
            GravityReceiver receiver = other.GetComponent<GravityReceiver>();
            if (receiver == null) return;
            receiver.Add(this);
        }

        private void OnTriggerExit(Collider other)
        {
            GravityReceiver receiver = other.GetComponent<GravityReceiver>();
            if (receiver == null) return;
            receiver.Remove(this);
        }
    }
}
