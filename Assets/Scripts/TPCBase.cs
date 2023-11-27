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
            //-------------------------------------------------------------------
            // Implement here.
            //-------------------------------------------------------------------
            //-------------------------------------------------------------------
            // Hints:
            //-------------------------------------------------------------------
            // check collision between camera and the player.
            // find the nearest collision point to the player
            // shift the camera position to the nearest intersected point
            //-------------------------------------------------------------------

            LayerMask wallMask = LayerMask.GetMask("Wall");
            RaycastHit[] hits;
            float maxDistance = 3f;

            Vector3 mPlayerPos = mPlayerTransform.position + new Vector3(0, 1.5f, 0);
            Vector3 newCamPos = mCameraTransform.position - mPlayerPos;
           
            hits = Physics.RaycastAll(mPlayerPos, newCamPos, maxDistance, wallMask);

            
            float nearestDistance = float.MaxValue;
            RaycastHit nearestCollisionPoint;

            

            foreach (RaycastHit hit in hits)
            {
                if (hit.transform != mPlayerTransform && hit.collider.tag != "IgnoreCameraCollision")
                {
                    if (hit.distance < nearestDistance)
                    {
                        nearestDistance = hit.distance;
                        nearestCollisionPoint = hit;


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
