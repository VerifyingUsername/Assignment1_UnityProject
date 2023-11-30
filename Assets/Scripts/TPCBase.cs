using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PGGE
{
    // The base class for all third-person camera controllers
    public abstract class TPCBase
    {
        protected Transform mCameraTransform;
        protected Transform mPlayerTransform;
        protected float defaultDistance = 3.0f;

        public Transform CameraTransform
        {
            get
            {
                return mCameraTransform;
            }
        }
        public Transform PlayerTransform
        {
            get
            {
                return mPlayerTransform;
            }
        }

        public TPCBase(Transform cameraTransform, Transform playerTransform)
        {
            mCameraTransform = cameraTransform;
            mPlayerTransform = playerTransform;

        }

        public void RepositionCamera()
        {
            // For objects under the wall layermask
            LayerMask wallMask = LayerMask.GetMask("Wall");

            // Array to check for player, camera, distance between and objects under layer
            RaycastHit[] hits;
            float maxDistance = 3f;

            // Camera Offset
            Vector3 mPlayerPos = mPlayerTransform.position + new Vector3(0, 1.5f, 0);
            Vector3 newCamPos = mCameraTransform.position - mPlayerPos;
           
            // Checks for collision with Raycast all from the array
            hits = Physics.RaycastAll(mPlayerPos, newCamPos, maxDistance, wallMask);
            
            // For nearest collision points
            float nearestDistance = float.MaxValue;
            RaycastHit nearestCollisionPoint;

            foreach (RaycastHit hit in hits)
            {
                // Ensure that object collision is not the player
                if (hit.transform != mPlayerTransform)
                {
                    // current distance is less than recorded distance
                    if (hit.distance < nearestDistance)
                    {
                        // Updates the new collision points
                        nearestDistance = hit.distance;
                        nearestCollisionPoint = hit;

                        // Sets the new collision point as the camera's new position as long as the value is valid
                        if (nearestDistance < Mathf.Infinity)
                        {                        
                            mCameraTransform.position = nearestCollisionPoint.point;
                        }
                    }
                }
            }      
        }
        public abstract void Update();
    }
}
