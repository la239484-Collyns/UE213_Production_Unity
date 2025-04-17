using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace PathCreation.Examples
{
    // Moves along a path at constant speed.
    // Depending on the end of path instruction, will either loop, reverse, or stop at the end of the path.
    public class PawnFollower : MonoBehaviour
    {
        [Header("Path Manager")]
        public PathCreator pathCreator;
        public EndOfPathInstruction endOfPathInstruction;
        public float speed = 5;
        public Vector3 vehiculeRotation;
        public bool startFromEnd = false;
        public float offset { get; set; }
        public float timeToTravel { get; set; }

        private float distanceTravelled;
        private float currentOffset;
        private InputSystem_Actions controls;



        void Start()
        {
            currentOffset = offset;
            distanceTravelled = 0f;
            if (pathCreator != null)
            {
                // Subscribed to the pathUpdated event so that we're notified if the path changes during the game
                pathCreator.pathUpdated += OnPathChanged;

                if (startFromEnd)
                {
                    distanceTravelled = pathCreator.path.length;
                }
            }
        }

        void Update()
        {
            if (pathCreator != null)
            {
                if (startFromEnd)
                {
                    distanceTravelled -= speed * Time.deltaTime;
                }
                else
                {
                    distanceTravelled += speed * Time.deltaTime;
                }

                transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction) + (transform.right * currentOffset) + transform.up;
                transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled, endOfPathInstruction) * Quaternion.Euler(vehiculeRotation.x, vehiculeRotation.y, vehiculeRotation.z);

            }
        }

        // If the path changes during the game, update the distance travelled so that the follower's position on the new path
        // is as close as possible to its position on the old path
        void OnPathChanged()
        {
            distanceTravelled = pathCreator.path.GetClosestDistanceAlongPath(transform.position);
        }
        public void ComputeTravelTime()
        {
            timeToTravel = (pathCreator.path.length / ((speed * Time.deltaTime) * (1f / Time.deltaTime)));
        }
    }
}