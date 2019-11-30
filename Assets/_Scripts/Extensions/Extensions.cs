using UnityEngine;
using System.Collections;

namespace Splitten.Extensions
{
    public static class Extensions
    {
        public static T GetAddComponent<T>(this MonoBehaviour obj) where T : Component
        {
            var component = obj.gameObject.GetComponent<T>();

            if (component != null)
                return component;

            obj.gameObject.AddComponent<T>();
            return component;
        }
    }

}
