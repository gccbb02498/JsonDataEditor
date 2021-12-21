using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using Common.dataBase;
using Microsoft.Win32;
using Newtonsoft.Json;

namespace WpfApp1.Views
{
    /// <summary>
    ///     SkillDataWindow.xaml 的互動邏輯
    /// </summary>
    public partial class SkillDataWindow : Window
    {
        private static List<SkillData>? _skillList;
        private readonly MainWindow _mainWindow;
        private string _fileName = null!;

        public SkillDataWindow(MainWindow mainWindow)
        {
            _mainWindow = mainWindow;
            InitializeComponent();
        }

        private void Initialize()
        {
            if (_skillList!.Count == 0) _skillList.Add(new SkillData(_skillList.Last().SkillID + 1));
            DataGrid.ItemsSource = _skillList;
        }

        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                Path.GetDirectoryName(openFileDialog.FileName);
                _fileName = Path.GetFileName(openFileDialog.FileName);
                _skillList = JsonConvert.DeserializeObject<List<SkillData>>(File.ReadAllText(openFileDialog.FileName));
                Initialize();
            }
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            if (null != null)
            {
            }

            Initialize();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            Save();
        }

        private void Save()
        {
            var saveFileDialog = new SaveFileDialog();

            if (saveFileDialog.ShowDialog() == true)
            {
                _fileName = saveFileDialog.FileName;
                var dataJson = JsonConvert.SerializeObject(_skillList);
                File.WriteAllText(_fileName, dataJson);
            }
        }

        private void ShowHideButton_Click(object sender, RoutedEventArgs e)
        {
        }

        private void AddDataButton_Click(object sender, RoutedEventArgs e)
        {
            _skillList!.Add(new SkillData(_skillList.Last().SkillID + 1));
            RefreshList();
        }

        private void RefreshList()
        {
            DataGrid.ItemsSource = null;
            DataGrid.ItemsSource = _skillList;
        }

        private void SkillDataWindow_OnClosed(object? sender, EventArgs e)
        {
            if (MessageBox.Show("Save Data?", "SaveInfo", MessageBoxButton.YesNo) == MessageBoxResult.Yes) Save();
            _mainWindow.Show();
        }
    }
}