using System.IO;
using Features.CodeGeneration.Core;
using UnityEditor;
using UnityEngine;

namespace Features.CodeGeneration.Domain {
    public static class SceneNamesGenerator {
        [MenuItem("Tools/Code Generation/Generate/Scene Names")]
        public static void Generate() {
            ICodeGenerator codeGenerator = new CodeGenerator();
            codeGenerator.SetName("SceneNames")
                         .SetPath(Application.dataPath + "/Features/CodeGeneration/Scripts/GeneratedFiles")
                         .GenerateClass(GenerateClassProperties());
        }

        private static string GenerateClassProperties() {
            string content = string.Empty;
            for (int sceneIndex = 0; sceneIndex < EditorBuildSettings.scenes.Length; sceneIndex++) {
                EditorBuildSettingsScene sceneSettings = EditorBuildSettings.scenes[sceneIndex];
                string sceneName = GetNameFromPath(sceneSettings);
                content += "        public static string " + sceneName.Replace(" ", "") + " => \"" + sceneName + "\";" + (sceneIndex < EditorBuildSettings.scenes.Length - 1 ? "\n" : string.Empty);
            }

            return content;
        }

        private static string GetNameFromPath(EditorBuildSettingsScene sceneSettings) {
            string name = Path.GetFileName(sceneSettings.path);
            return Path.GetFileNameWithoutExtension(name);
        }
    }
}