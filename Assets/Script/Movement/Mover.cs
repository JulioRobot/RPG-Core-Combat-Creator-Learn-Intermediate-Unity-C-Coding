using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using RPG.Core;

// ini script handle semua pergerakan karakter player atau musuh di game
namespace RPG.Movement
{
    public class Mover : MonoBehaviour, IAction
    {
        [SerializeField] Transform target;

        NavMeshAgent navMeshAgent;
        Health health;

        // Start is called before the first frame update
        void Start()
        {
            navMeshAgent = transform.GetComponent<NavMeshAgent>();
            health = GetComponent<Health>();
        }

        // Update is called once per frame
        void Update()
        {
            navMeshAgent.enabled = !health.IsDead();

            UpdateAnimator();

            //GetComponent<NavMeshAgent>().destination = target.position; // [Tutor] ini dp arti ubah posisi nav mesh agent sesuai dengan posisi target
            //agent.SetDestination(target.position);
        }

        public void StartMoveAction(Vector3 _destination)
        {
            GetComponent<ActionScheduler>().StartAction(this);
            MoveTo(_destination);
        }

        public void MoveTo(Vector3 _destination) // ini dikasih public supaya class lain boleh pake
        {
            GetComponent<NavMeshAgent>().destination = _destination;
            navMeshAgent.isStopped = false;
        }

       
        public void Cancel()
        {
            navMeshAgent.isStopped = true;
            Debug.Log("Cancel MOve");
        }

        

        private void UpdateAnimator()
        {
            Vector3 velocity = GetComponent<NavMeshAgent>().velocity;
            Vector3 localVelocity = transform.InverseTransformDirection(velocity);
            float speed = localVelocity.z;
            GetComponent<Animator>().SetFloat("forwardSpeed", speed);
        }

    }
}
