using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace unity_editor_utilities {
    public class CreateAnimationClipEditor {
        static private CreateAnimationClips m_clipgen = new CreateAnimationClips();

        [MenuItem("GameObject/Animation/Create animation clips", false)]
        static private void CreateAnimationClips(MenuCommand cmd) {
            GameObject ctx = cmd.context as GameObject;
            SkinnedMeshRenderer[] smrArray = ctx.GetComponentsInChildren<SkinnedMeshRenderer>();

            for (int i = 0; i < smrArray.Length; i++) m_clipgen.CreateAnimationClipFromSMR(smrArray[i]);
            AssetDatabase.Refresh();
            Debug.Log("[unity_editor_utilities/create animation clip]\nFinished.");
        }
    }
}
