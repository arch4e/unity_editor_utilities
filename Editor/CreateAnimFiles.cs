using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace UTK {
    public class CreateAnimFiles : MonoBehaviour {
        /* --- menu items --- */
        [MenuItem("GameObject/Unity Tool Kit/Create .anim files", false)]
        static private void CreateAnimFilesMenu(MenuCommand cmd) {
            GameObject ctx = cmd.context as GameObject;
            SkinnedMeshRenderer[] smrArray = ctx.GetComponentsInChildren<SkinnedMeshRenderer>();

            for (int i = 0; i < smrArray.Length; i++) CreateAnimFilesFromSMR(smrArray[i]);
            Debug.Log("UTK: Finished.");
        }

        /* --- internal functions: CreateAnimFiles --- */
        static private void CreateAnimFilesFromSMR(SkinnedMeshRenderer smr) {
            string exportFolder = "Assets/Exports/";
            Mesh mesh = smr.sharedMesh;

            // check export directory
            if (!System.IO.Directory.Exists(exportFolder)) System.IO.Directory.CreateDirectory(exportFolder);

            // create animation clips
            for (int i = 0; i < mesh.blendShapeCount; i++) {
                AnimationClip clip;
                string blendShapeName = mesh.GetBlendShapeName(i);
                string filePath = exportFolder + blendShapeName + ".anim";

                // load animation clip
                if (!System.IO.File.Exists(filePath)) {
                    clip = new AnimationClip();
                    AssetDatabase.CreateAsset(clip, filePath);
                } else {
                    clip = AssetDatabase.LoadAssetAtPath<AnimationClip>(filePath);
                }

                clip.SetCurve(GetRelativePath(smr.gameObject),
                            typeof(SkinnedMeshRenderer),
                            "blendShape." + blendShapeName,
                            new AnimationCurve(new Keyframe(0.0f, 100)));

                AssetDatabase.Refresh();
            }
        }

        static private string GetRelativePath(GameObject gameObject) {
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
