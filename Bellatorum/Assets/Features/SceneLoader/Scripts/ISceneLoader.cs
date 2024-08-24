namespace Features.SceneLoader {
    public interface ISceneLoader {
        public void Load(string sceneName);
        public void UnLoad(string sceneName);
    }
}