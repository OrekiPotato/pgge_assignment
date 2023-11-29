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

        protected float rayOffset = 2f;

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
            Vector3 rayStartPoint = mPlayerTransform.position + Vector3.up * rayOffset; // Set where the startpoint of the ray will be. 

            Ray ray = new Ray(rayStartPoint, mCameraTransform.position - rayStartPoint); // Ray connecting cameraPos to the offset'd playerPos

            float maxRayDistance = 5f;
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, maxRayDistance))
            {
                
                Vector3 collidingPoint = hit.point;
                mCameraTransform.position = collidingPoint;
            }
 
            Debug.DrawRay(rayStartPoint, ray.direction * maxRayDistance, Color.black); // Check to see if ray even exist...
        }

        public abstract void Update();
    }
}
