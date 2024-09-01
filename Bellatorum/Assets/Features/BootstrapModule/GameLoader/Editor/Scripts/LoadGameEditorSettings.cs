using UnityEditor;
using UnityEngine;

namespace Features.BootstrapModule.GameLoader.Editor {
    public class LoadGameEditorSettings : ScriptableObject {
        private const string SETTINGS_PATH = "Assets/Features/BootstrapModule/GameLoader/Editor/LoadGameEditorSettings.asset";
        public bool StartFromInitialScene = true;

        private static LoadGameEditorSettings _instance;

        public static LoadGameEditorSettings Instance {
            get {
                if (_instance != null)
                    return _instance;

                _instance = AssetDatabase.LoadAssetAtPath<LoadGameEditorSettings>(SETTINGS_PATH);
                if (_instance == null) {
                    _instance = CreateInstance<LoadGameEditorSettings>();
                    AssetDatabase.CreateAsset(_instance, SETTINGS_PATH);
                    AssetDatabase.SaveAssets();
                }

                return _instance;
            }
        }
    }
}