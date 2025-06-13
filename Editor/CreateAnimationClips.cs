using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace unity_editor_utilities {
    public class CreateAnimationClips {
        private Utilities m_utils = new Utilities();

        public void CreateAnimationClipFromSMR(SkinnedMeshRenderer smr) {
            string exportFolder = "Assets/Exports/";
            Mesh   mesh = smr.sharedMesh;

            // check export directory
            if (!System.IO.Directory.Exists(exportFolder)) System.IO.Directory.CreateDirectory(exportFolder);

            // create animation clips
            for (int i = 0; i < mesh.blendShapeCount; i++) {
                AnimationClip clip;
                string blendShapeName = mesh.GetBlendShapeName(i);
                string filePath = exportFolder + blendShapeName + ".anim";

                try {
                    // load animation clip
                    if (!System.IO.File.Exists(filePath)) {
                        clip = new AnimationClip();
                        AssetDatabase.CreateAsset(clip, filePath);
                    } else {
                        clip = AssetDatabase.LoadAssetAtPath<AnimationClip>(filePath);
                    }

                    // set curve for animation clip
                    clip.SetCurve(m_utils.GetRelativePath(smr.gameObject),
                                typeof(SkinnedMeshRenderer),
                                "blendShape." + blendShapeName,
                                new AnimationCurve(new Keyframe(0.0f, 100)));

                } catch (System.Exception e) {
                    Debug.LogError("[unity_editor_utilities/create animation clip]\nFailed to create animation clip for " + blendShapeName + "\n" + e.Message);
                }
            }
        }
    }
}
