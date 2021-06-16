using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Movement;
using RPG.Combat;
using RPG.Core;
using System;

namespace RPG.Control // pake namespcae untuk projek lebih teratur
{
    public class PlayerController : MonoBehaviour
    {

        Health health;

        void Start()
        {
            health = GetComponent<Health>();
        }

        // Update is called once per frame
        void Update()
        {
            if (health.IsDead()) return;

            if (InteractWithCombat()) // atau nga boleh tulis bagini if (InteractWithCombat())return;
            {
                return;
            }
            if (InteractWithMovement())
            {
                return;
            }
            
        }

        private bool InteractWithCombat()
        {
            RaycastHit[] hits = Physics.RaycastAll(GetMouseRay());
            foreach (RaycastHit hit in hits)  // ini dp arti setiap objek yang terkena raycast akan dilaksanakan koding ini
            {
               CombatTarget target = hit.transform.GetComponent<CombatTarget>();
                if (target == null) continue;

                if (!GetComponent<Fighter>().CanAttack(target.gameObject)) continue; // continu = jika ini dpe nilai null lanjutkan pada next item di list jadi koding akan di ignore

                if (Input.GetMouseButton(0))
                  {
                      GetComponent<Fighter>().Attack(target.gameObject);
                      
                  }
                return true;
            }
            return false;
        }

        private bool InteractWithMovement()
        {
            RaycastHit hit;
            bool hasHit = Physics.Raycast(GetMouseRay(), out hit); // GetMouseRay() ini sebelumnya tong bking bagini =   Ray ray = GetMouseRay();
            if (hasHit == true)
            {
                if (Input.GetMouseButton(0))
                {
                    GetComponent<Mover>().StartMoveAction(hit.point);
                }
                return true;
            }
            return false;
        }

        private static Ray GetMouseRay() // function yang dp fungsi mengembalikan nilai apa yang di klik mouse
        {
            return Camera.main.ScreenPointToRay(Input.mousePosition);
        }
    }
}

