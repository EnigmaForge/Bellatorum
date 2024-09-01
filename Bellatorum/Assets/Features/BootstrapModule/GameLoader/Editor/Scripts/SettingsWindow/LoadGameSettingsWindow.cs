using UnityEditor;
using UnityEngine;

namespace Features.BootstrapModule.GameLoader.Editor.SettingsWindow {
    public class LoadGameSettingsWindow : EditorWindow {
        private LoadGameEditorSettings _editorSettings;

        [MenuItem("Tools/Load Game Settings", priority = 0)]
        public static void ShowWindow() =>
            GetWindow<LoadGameSettingsWindow>("Load Game Settings");

        private void OnEnable() =>
            _editorSettings = LoadGameEditorSettings.Instance;

        private void OnGUI() {
            GUILayout.Label("Editor Settings", EditorStyles.boldLabel);

            _editorSettings.StartFromInitialScene = EditorGUILayout.Toggle("Start From Initial Scene", _editorSettings.StartFromInitialScene);
        }
    }
}
