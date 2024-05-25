using UnityEngine;

namespace WowGame
{
    public static class DeppFindTransform
    {
        /// <summary>
        /// 深度查找
        /// </summary>
        /// <param name="root"></param>
        /// <param name="childName"></param>
        /// <returns></returns>
        public static Transform DeepFindChild(this Transform root, string childName)
        {
            Transform result = root.Find(childName);
            if (!result)
            {
                foreach (Transform item in root)
                {
                    result = item.DeepFindChild(childName);
                    if (result != null)
                    {
                        return result;
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// 深度查找组件
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="root"></param>
        /// <param name="childName"></param>
        /// <returns></returns>
        public static T DeepFindChild<T>(this Transform root, string childName) where T : Component
        {
            var child = root.Find(childName);
            var result = default(T);
            if (!child)
            {
                foreach (Transform item in root)
                {
                    result = item.DeepFindChild<T>(childName);

                    if (result != null)
                        return result;
                }
            }
            else
            {
                result = child.GetComponent<T>();
            }
            return result;
        }
    }
}