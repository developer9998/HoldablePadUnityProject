using UnityEngine;
using UnityEditor;
using System.IO;
using UnityEngine.UI;

public class Exporter
{
    [MenuItem("Holdable Pad/Build Holdable")]
    static void BuildAllAssetBundles()
    {

        if (!Selection.activeGameObject)
        {
            EditorUtility.DisplayDialog("Build Failed", "Please select the GameObject you want to build.", "OK");
            return;
        }

        var selectedObject = Selection.activeGameObject;

        if (!selectedObject.GetComponent<Descriptor>())
        {
            EditorUtility.DisplayDialog("Build Failed", "Please add the Descriptor component to your empty GameObject.", "OK");
            return;
        }

        Descriptor descriptor = selectedObject.GetComponent<Descriptor>();
        if (!AssetDatabase.IsValidFolder("Assets/ExportedHoldables"))
        {
            AssetDatabase.CreateFolder("Assets", "ExportedHoldables");
        }

        string holdableName = descriptor.Name;
        string holdableAuthor = descriptor.Author;
        string holdableDescription = descriptor.Description;
        string holdableLHand = descriptor.leftHand.ToString();
        string empty = "";
        bool includedName = holdableName != empty;
        bool includedAuthor = holdableAuthor != empty;
        bool includedDescription = holdableDescription != empty;

        if (!includedName)
        {
            EditorUtility.DisplayDialog("Build Failed", "Please include a name in your Descriptor component.", "OK");
            return;
        }
        else if (!includedAuthor)
        {
            EditorUtility.DisplayDialog("Build Failed", "Please include an author in your Descriptor component.", "OK");
            return;
        }
        else if (!includedDescription)
        {
            EditorUtility.DisplayDialog("Build Failed", "Please include a description in your Descriptor component.", "OK");
            return;
        }

        string prefabPath = "Assets/ExportedHoldables/holdABLE.prefab";

        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
        PrefabUtility.SaveAsPrefabAsset(selectedObject.gameObject, prefabPath);
        GameObject contentsRoot = PrefabUtility.LoadPrefabContents(prefabPath);
        contentsRoot.name = "holdABLE";

        Text player_info = contentsRoot.AddComponent<Text>();
        string split = "$"; // splits each of the strings
        player_info.text = holdableName + split + holdableAuthor + split + holdableDescription + split + holdableLHand;

        Object.DestroyImmediate(contentsRoot.GetComponent<Descriptor>());
        if (File.Exists(prefabPath))
        {
            File.Delete(prefabPath);
        }

        string newprefabPath = "Assets/ExportedHoldables/" + contentsRoot.name + ".prefab";
        PrefabUtility.SaveAsPrefabAsset(contentsRoot, newprefabPath);
        PrefabUtility.UnloadPrefabContents(contentsRoot);
        AssetImporter.GetAtPath(newprefabPath).SetAssetBundleNameAndVariant("holdableAssetBundle", "");

        string assetBundleDirectory = "Assets/ExportedHoldables";
        if (!Directory.Exists("Assets/ExportedHoldables"))
        {
            Directory.CreateDirectory(assetBundleDirectory);
        }

        string asset_new = assetBundleDirectory + "/" + holdableName;
        if (File.Exists(asset_new + ".holdable"))
        {
            File.Delete(asset_new + ".holdable");
        }

        BuildPipeline.BuildAssetBundles(assetBundleDirectory, BuildAssetBundleOptions.None, EditorUserBuildSettings.activeBuildTarget);
        if (File.Exists(newprefabPath))
        {
            File.Delete(newprefabPath);
        }

        string asset_manifest = assetBundleDirectory + "/holdableAssetBundle.manifest";
        Debug.Log(asset_manifest);
        if (File.Exists(asset_manifest))
        {
            File.Delete(asset_manifest);
        }

        string folder_manifest = assetBundleDirectory;
        if (File.Exists(folder_manifest))
        {
            File.Delete(folder_manifest);

            File.Delete(folder_manifest + ".manifest");
        }

        string asset_temporary = assetBundleDirectory + "/holdableAssetBundle";
        string metafile = asset_temporary + ".meta";
        if (File.Exists(asset_temporary))
        {

            File.Move(asset_temporary, asset_new + ".holdable");
            Debug.Log(metafile);
        }

        AssetDatabase.Refresh();
        Debug.ClearDeveloperConsole();

        string whichHand = holdableLHand == "true" ? "left" : "right";
        EditorUtility.DisplayDialog("Build Success", $"{holdableName} was successfully built for your {whichHand} hand.", "OK");
    }
}