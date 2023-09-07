using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MimicSpace
{
    /// <summary>
    /// This is a very basic movement script, if you want to replace it
    /// Just don't forget to update the Mimic's velocity vector with a Vector3(x, 0, z)
    /// </summary>
    public class Movement : MonoBehaviour
    {
        [Header("Controls")]
        [Tooltip("Body Height from ground")]
        [Range(0.5f, 5f)]
        public float height = 0.8f;
        public float speed = 5f;
        Vector3 velocity = Vector3.zero;
        public float velocityLerpCoef = 4f;
        Mimic myMimic;
        Transform target; // Reference to the target GameObject
        public GameObject player;

        private void Start()
        {
            myMimic = GetComponent<Mimic>();
            target = player.transform;
        }

        void Update()
        {
            // Get the target position
            Vector3 targetPosition = target.position; 

            // Calculate the direction towards the target
            Vector3 direction = (targetPosition - transform.position).normalized;

            // Calculate the new velocity using Lerp
            Vector3 newVelocity = Vector3.Lerp(myMimic.velocity, direction * speed, velocityLerpCoef * Time.deltaTime);

            // Assign the new velocity to the mimic to assure great leg placement
            myMimic.velocity = newVelocity;

             // Move the player based on the calculated velocity
            transform.position = transform.position + newVelocity * Time.deltaTime;

            // Adjust the height from the ground
            RaycastHit hit;
            Vector3 destHeight = transform.position;
            if (Physics.Raycast(transform.position + Vector3.up * 5f, -Vector3.up, out hit)) destHeight = new Vector3(transform.position.x, hit.point.y + height, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, destHeight, Time.deltaTime);

            /*
            velocity = Vector3.Lerp(velocity, new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized * speed, velocityLerpCoef * Time.deltaTime);

            // Assigning velocity to the mimic to assure great leg placement
            myMimic.velocity = velocity;

            transform.position = transform.position + velocity * Time.deltaTime;
            RaycastHit hit;
            Vector3 destHeight = transform.position;
            if (Physics.Raycast(transform.position + Vector3.up * 5f, -Vector3.up, out hit))
                destHeight = new Vector3(transform.position.x, hit.point.y + height, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, destHeight, velocityLerpCoef * Time.deltaTime);
            */
        }
    }

}