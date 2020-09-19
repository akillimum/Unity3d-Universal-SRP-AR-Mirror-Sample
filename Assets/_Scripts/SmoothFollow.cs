﻿using UnityEngine;

    public class SmoothFollow : MonoBehaviour
    {

        // The target we are following
        [SerializeField]
        private Transform target;
        // The distance in the x-z plane to the target
        [SerializeField]
        private float distance = 10.0f;
        // the height we want the camera to be above the target
        [SerializeField]
        private float height = 5.0f;

        [SerializeField]
        private float rotationDamping;
        [SerializeField]
        private float heightDamping;

        // Use this for initialization
        void Start() { }

        // Update is called once per frame
        void Update()
        {
            // Early out if we don't have a target
            if (!target)
                return;

            // Calculate the current rotation angles
            var wantedRotationAngle = target.eulerAngles.y;
            var wantedHeight = target.position.y + height;

            var currentRotationAngle = transform.eulerAngles.y;
            var currentHeight = transform.position.y;

            // Damp the rotation around the y-axis
            currentRotationAngle = Mathf.LerpAngle(currentRotationAngle, wantedRotationAngle, rotationDamping * (Time.deltaTime+1));

            // Damp the height
            currentHeight = Mathf.Lerp(currentHeight, wantedHeight, heightDamping * (Time.deltaTime+1));

            // Convert the angle into a rotation
            var currentRotation = Quaternion.Euler(0, currentRotationAngle, 0);

            // Set the position of the camera on the x-z plane to:
            // distance meters behind the target
            transform.position = target.position;
            transform.position -= currentRotation * Vector3.forward * distance;

            // Set the height of the camera
            transform.position = new Vector3(transform.position.x ,currentHeight , transform.position.z);

            // Always look at the target
            transform.LookAt(target);
        }

        public void SetDistance(float d)
        {
            distance = d;
        }
        public float GetDistance(float d)
        {
            return distance;
        }
        public void SetHeight(float d)
        {
            height = d;
        }
        public float GetHeight(float d)
        {
            return height;
        }
        public void SetRotationDamping(bool d)
        {
            if (d)
                rotationDamping = 0.1f;
            else
                rotationDamping = 0f;
        }
    }