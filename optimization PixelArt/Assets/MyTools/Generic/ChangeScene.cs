#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.SceneManagement;


public class ChangeScene : Editor
{
    [MenuItem("Open Scene/Loading #1")]
    public static void OpenLoading()
    {
        OpenScene(Const.SCENE_LOADING);
    }

    [MenuItem("Open Scene/Home #2")]
    public static void OpenHome()
    {
        OpenScene(Const.SCENE_HOME);
    }

    [MenuItem("Open Scene/Game #3")]
    public static void OpenGame()
    {
        OpenScene(Const.SCENE_GAME);
    }

    [MenuItem("Open Scene/Adventure #4")]
    public static void OpenUI()
    {
        OpenScene(Const.SCENE_ADVENTURE);
    }

    [MenuItem("Open Scene/Test #5")]
    public static void OpenTest()
    {
        OpenScene(Const.SCENE_TEST);
    }

    private static void OpenScene(string sceneName)
    {
        if (EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
        {
            EditorSceneManager.OpenScene("Assets/Game/Scenes/" + sceneName + ".unity");
        }
    }
}
#endif
