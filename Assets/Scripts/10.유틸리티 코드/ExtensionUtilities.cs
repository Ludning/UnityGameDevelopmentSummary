using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Util
{
    public static class ExtensionUtilities
    {
        public static T MustGetComponent<T>(this GameObject gameObject) where T : Component
        {
            var component = gameObject.GetComponent<T>();
            if (component == null)
            {
                Debug.LogError($"Component of type {typeof(T).Name} is not attached to {gameObject.name}");
            }
            
            return component;
        }
        public static T[] MustGetComponents<T>(this GameObject gameObject) where T : Component
        {
            var components = gameObject.GetComponents<T>();
            if (components.Length == 0)
            {
                Debug.LogError($"Component of type {typeof(T).Name} is not attached to {gameObject.name}");
            }
            return components;
        }
        public static T MustGetComponentInChildren<T>(this GameObject gameObject) where T : Component
        {
            var component = gameObject.GetComponentInChildren<T>();
            if (component == null)
            {
                Debug.LogError($"Component of type {typeof(T).Name} is not attached to any child of {gameObject.name}");
            }
            return component;
        }
        public static T MustGetComponentInParent<T>(this GameObject gameObject) where T : Component
        {
            var component = gameObject.GetComponentInParent<T>();
            if (component == null)
            {
                Debug.LogError($"Component of type {typeof(T).Name} is not attached to any parent of {gameObject.name}");
            }
            return component;
        }
        public static void SafeDestroy(this GameObject gameObject)
        {
            if (gameObject != null)
            {
                Object.Destroy(gameObject);
            }
        }
        public static void SetLayerRecursively(this GameObject gameObject, int newLayer)
        {
            if (gameObject == null)
                return;
    
            gameObject.layer = newLayer;
            foreach (Transform child in gameObject.transform)
            {
                if (child == null) continue;
                SetLayerRecursively(child.gameObject, newLayer);
            }
        }
        
    }
}