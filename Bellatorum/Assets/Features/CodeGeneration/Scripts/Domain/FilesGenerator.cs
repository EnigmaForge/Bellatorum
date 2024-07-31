using UnityEditor;

namespace Features.CodeGeneration.Domain {
    public static class FilesGenerator {
        [MenuItem("Tools/Code Generation/Generate All")]
        public static void GenerateAll() {
            SceneNamesGenerator.Generate();
        }
    }
}
