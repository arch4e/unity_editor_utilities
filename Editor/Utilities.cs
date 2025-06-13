using UnityEngine;

namespace unity_editor_utilities {
    public class Utilities {
         // return game object relative path
        public string GetRelativePath(GameObject gameObject) {
            string path = gameObject.name;
            Transform transform = (gameObject.GetComponent(typeof(Transform)) as Transform).parent;

            while (true) {
                if (transform != null && transform.gameObject.GetComponent(typeof(Animator)) == null) {
                    path = transform.gameObject.name + "/" + path;
                    transform = transform.parent;
                } else break;
            }

            return path;
        }
    }
}
