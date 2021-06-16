using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Core
{
    public class FollowCamera : MonoBehaviour
    {
        [SerializeField] private Transform target;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        void LateUpdate() // ini supaya animasi bergerak dulu baru tu camera mengikuti
        {
            transform.position = target.position;
        }
    }

}

