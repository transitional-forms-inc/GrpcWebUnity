using System.IO;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEditor;
using UnityEditor.Callbacks;

public class GrpcWebUnityBuildProcessor : ScriptableObject
{
    public TextAsset script;

    [PostProcessBuild]
    public static void OnPostprocessBuild(BuildTarget target, string pathToBuiltProject)
    {
        var pathOfThisScript = GetCallingFilePath();
        var parent = Directory.GetParent(pathOfThisScript);

        // We assume this file exists in the folder in which this script (GrpcWebUnityBuildProcessor) resides.
        var jsFileName = "GrpcWebUnity.js";
        var srcFile = Path.Combine($"{parent}", jsFileName);
        var destFile = Path.Combine($"{pathToBuiltProject}", jsFileName);
        File.Copy(srcFile, destFile, true);
        Debug.Log(srcFile);
        Debug.Log(destFile);
        Debug.Log(File.Exists(destFile));

    }

    [MenuItem("cheem/Cham")]
    public static void PrintDefaultScript()
    {
        var instance = ScriptableObject.CreateInstance<GrpcWebUnityBuildProcessor>();
        Debug.Log(AssetDatabase.GetAssetPath(instance.script));
        DestroyImmediate(instance);
    }

    // returns the filepath of the code that called this method.
    static string GetCallingFilePath([CallerFilePath] string filename = "")
    {
        return filename;
    }
}
