using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEditor;
using UnityEngine;

public class MyEditor : EditorWindow {
    private string m_path = "./Assets/Editor/config/MyEditor.ini";
    //輸入文字的內容
    private string m_text;
    //
    public static Rect windePosition = new Rect(0, 0, 500, 500);
    private float m_left;
    private float m_top;
    public NewItemManager NewItemManager;

    public List<BackpackItem> itemList;

    [MenuItem("Window/MyWindowEditor")]
    static void AddWindow() {
        //創建窗口
        MyEditor window = (MyEditor)EditorWindow.GetWindowWithRect(typeof(MyEditor), windePosition, true, "windoow name");
        window.Show();
    }

    private void LoadConfig() {
        if (!File.Exists(m_path)) {
            Initiallze();
        }
        else
            ReadINI();
    }

    private void ReadINI() {
        string[] temp = new string[2];
        int number = 0;
        using (StreamReader readder = new StreamReader(m_path)) {
            while (readder.EndOfStream == false) {
                temp[number] = readder.ReadLine();
                number++;
            }
        }
        m_left = GetNumber(temp[0]);
        m_top = GetNumber(temp[1]);
        windePosition = new Rect(m_left, m_top, 500, 500);
        
    }

    private float GetNumber(string str) {
        char[] data = str.ToCharArray();
        int index = str.IndexOf("=");
        StringBuilder number = new StringBuilder();
        for (int i = index + 1; i < data.Length; i++) {
            number.Append(data[i]);
        }
        //       Debug.Log(number);
        return float.Parse(number.ToString());
    }
    private void WriteINI(float left, object top) {
        //第一個參數為檔案位置，若該位置無檔案則自動創建；
        //第二個參數為true代表將資料寫在原先資料的後面，為false則將原先資料全部清除後再重新寫入新的內容，預設為false；
        //第三個參數則為文件的編碼方式
        //string str = System.Environment.CurrentDirectory;
        Debug.Log(left);
        using (StreamWriter writer = new StreamWriter(m_path, false, Encoding.UTF8)) {
            writer.Write("LEFT=" + left);
            writer.Write("\nTOP=" + top);
        }
    }

    private void Initiallze() {
        windePosition = new Rect(0, 0, 500, 500);
    }

    public void Awake() {
        //
        LoadConfig();
        AddWindow();
        NewItemManager.Instance.LoadItemConfig();
        this.itemList = NewItemManager.Instance.BackPackItemList;

    }

    private void OnGUI() {
        //
        m_text = EditorGUILayout.TextField("輸入文字", m_text);

    }
    private void OnDestroy() {
        
        WriteINI(position.xMin, position.yMin);
        windePosition = new Rect(position.xMin, position.yMin, 500, 500);
    }
    

}
