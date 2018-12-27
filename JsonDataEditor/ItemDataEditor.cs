using System.Collections.Generic;
using System.IO;

public class ItemDataEditor  {
    public MyData myData;
    public List<MyDataItem> items;
    private bool isPrettyPrint = false;
    string filePath = "";
    string dataJson;
    private int index;
    string[] options;

    //[MenuItem("Window/Item Data Editor")]
    //static void Init() {
    //    GetWindow(typeof(ItemDataEditor)).Show();
    //}
    //private void OnGUI() {
    //    #region LoadData Button & CreateData Button & PrettyPrint Toggle & SaveData Button

    //    EditorGUILayout.Space();

    //    if (GUILayout.Button("Load Item data"))
    //        LoadingJsonData();

    //    EditorGUILayout.Space();

    //    if (GUILayout.Button("Create json data"))
    //        CreateNewData();

    //    EditorGUILayout.Space();

    //    GUILayout.BeginHorizontal();

    //    isPrettyPrint = GUILayout.Toggle(isPrettyPrint, "Pretty Print");

    //    if (GUILayout.Button("Save data"))
    //        SaveJsonData();

    //    GUILayout.EndHorizontal();

    //    #endregion

    //    EditorGUILayout.Space();
    //    #region Handle Data box
    //    GUILayout.BeginHorizontal();

    //    GUILayout.EndHorizontal();
    //    GUILayout.BeginVertical("Box");
    //    if (myData != null) {
    //        GUILayout.Label(filePath);
    //        SerializedObject serializedObject = new SerializedObject(this);
    //        SerializedProperty serializedProperty = serializedObject.FindProperty("myData");
    //        EditorGUILayout.PropertyField(serializedProperty, true);
    //        serializedObject.ApplyModifiedProperties();


    //    }
    //    else {

    //    }
    //    GUILayout.EndVertical();

        //#endregion
    }

//    private void SaveJsonData() {
//        filePath = EditorUtility.SaveFilePanel("Save json data file", Application.streamingAssetsPath, "", "json");
//        if (!string.IsNullOrEmpty(filePath)) {

//            string dataJson = JsonConvert.SerializeObject(myData);
//            File.WriteAllText(filePath, dataJson);
//        }
//    }



//    private void CreateNewData() {
//        filePath = "";
//        myData = new MyData();
//    }

//    private void LoadingJsonData() {
//        filePath = EditorUtility.OpenFilePanel("Select json data file", Application.streamingAssetsPath, "json");
//        if (!string.IsNullOrEmpty(filePath)) {
//            string dataJson = File.ReadAllText(filePath);
//            myData = JsonConvert.DeserializeObject<MyData>(dataJson);
//            items = myData.items;
//        }

//    }
//}
