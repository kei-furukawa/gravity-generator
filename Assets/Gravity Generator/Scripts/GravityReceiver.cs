using System.Collections.Generic;
using UnityEngine;

namespace Gravity
{
    [RequireComponent(typeof(Rigidbody))]
    public class GravityReceiver : MonoBehaviour
    {
        private List<GravityGenerator> m_senders = null;
        private Rigidbody m_rigidbody = null;

        private void Awake()
        {
            m_senders = new List<GravityGenerator>();
            m_rigidbody = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            foreach (var sender in m_senders)
            {
                Vector3 dir = (sender.transform.position - transform.position).normalized;
                m_rigidbody.AddForce(sender.gravity * m_rigidbody.mass * dir, ForceMode.Force);
            }
        }

        public void Add(GravityGenerator sender)
        {
            m_senders.Add(sender);
        }

        public void Remove(GravityGenerator sender)
        {
            m_senders.Remove(sender);
        }
    }
}
