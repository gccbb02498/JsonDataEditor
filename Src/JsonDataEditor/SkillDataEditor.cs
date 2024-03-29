﻿using JsonDataEditor.dataBase;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JsonDataEditor {
    public partial class SkillDataEditor : Form {

        
        static SkillDatas skills;
        static List<SkillInfo> skillData;
        object[] obj;
        ItemTextBox[] itemtext;
        string fileName;
        string filepath;
        bool dataviewshow = true;
        bool isload = false;
        Label[] Labelname;

        public SkillDataEditor() {
            InitializeComponent();
        }

        private void Initialize() {
            if (skills == null)
                skills = new SkillDatas(new List<SkillInfo>());
            skillData = skills.skillDatas;
            if(skillData.Count == 0)
                skillData.Add(new SkillInfo());
            skillDataView.Visible = dataviewshow;
            Dataviewbtn.Enabled = true;
            Save.Visible = true;
            obj = new object[2];
            obj[0] = new ComboBox();
            skillDataView.DataSource = skills.skillDatas;
            AddDatabtn.Visible = true;

            if (itemtext == null) {
                itemtext = new ItemTextBox[skillDataView.ColumnCount];
                Labelname = new Label[skillDataView.ColumnCount];
                for (int i = 0; i < skillDataView.ColumnCount; i++) {
                    itemtext[i] = new ItemTextBox(i);
                    Labelname[i] = new Label();
                    this.Controls.Add(itemtext[i]);
                    this.Controls.Add(Labelname[i]);
                    //itemtext[i].DataBindings.Add("Text", myData.items, dataGridView1.Columns[i].Name, true);
                    Labelname[i].Text = skillDataView.Columns[i].Name;
                    if (skillDataView.Columns[i].Name == "ItemDesc") {
                        itemtext[i].Multiline = true;
                        itemtext[i].Height *= 3;
                        itemtext[i].ScrollBars = ScrollBars.Vertical;
                    }
                    else
                        itemtext[i].AutoSize = true;
                    Labelname[i].AutoSize = true;
                    Labelname[i].SetBounds(10, (5 + (i == 0 ? 10 : itemtext[i - 1].Location.Y + itemtext[i - 1].Height)), Labelname[i].Width, Labelname[i].Height);

                    itemtext[i].SetBounds(80, (5 + (i == 0 ? 10 : itemtext[i - 1].Location.Y + itemtext[i - 1].Height)), 2 * itemtext[i].Width, itemtext[i].Height);
                    itemtext[i].TextChanged += Genesis_TextChanged;
                }

            }
        }

        private void Openfilebtn_Click(object sender, EventArgs e) {

            isload = true;
            openFileDialog.FileName = "";
            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
                return;
            filepath = Path.GetDirectoryName(openFileDialog.FileName);
            fileName = Path.GetFileName(openFileDialog.FileName);
            string dataJson = File.ReadAllText(openFileDialog.FileName);
            skills = JsonConvert.DeserializeObject<SkillDatas>(dataJson);
            Initialize();




            skillDataView.DataSource = skills.skillDatas;
            SelectOpition.Visible = true;
            refreshList();

            if (skills != null) {
                Dataviewbtn.Enabled = true;

                for (int i = 0; i < skillDataView.ColumnCount; i++) {
                    if (skillDataView.Rows[SelectOpition.SelectedIndex].Cells[i].Value != null)
                    {
                        itemtext[i].Text = skillDataView.Rows[SelectOpition.SelectedIndex].Cells[i].Value.ToString();
                        Console.WriteLine(itemtext[i].Text = skillDataView.Rows[SelectOpition.SelectedIndex].Cells[i].Value.ToString());
                    }

                }
            }

            isload = false;
        }

        private void Genesis_TextChanged(object sender, EventArgs e) {
            ItemTextBox textBox = (ItemTextBox)sender;
            if (SelectOpition.SelectedIndex == -1)
                return;
            DataGridViewCell s = skillDataView.Rows[SelectOpition.SelectedIndex].Cells[textBox.index];
            if (textBox.Text == null)
                skillDataView.Rows[SelectOpition.SelectedIndex].Cells[textBox.index].Value = null;

            else if (s .Value==null || s.ToString() != textBox.Text && !isload) {
                skillDataView.Rows[SelectOpition.SelectedIndex].Cells[textBox.index].Value = textBox.Text;
                refreshList();
            }
        }
        void refreshList() {

            SelectOpition.DataSource = null;
            SelectOpition.Items.Clear();
            SelectOpition.DataSource = skillDataView.DataSource;
            SelectOpition.DisplayMember = "SkillName";
            SelectOpition.ValueMember = "SkillID";

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) {


            if (SelectOpition.SelectedIndex != -1) {
                if (itemtext != null)
                    for (int i = 0; i < skillDataView.ColumnCount; i++) {
                        isload = true;
                        if (skillDataView.Rows[SelectOpition.SelectedIndex].Cells[i].Value != null) {
                            itemtext[i].Text = skillDataView.Rows[SelectOpition.SelectedIndex].Cells[i].Value.ToString();
                        }

                        isload = false;
                        itemtext[i].Visible = true;
                        itemtext[i].AutoSize = true;

                    }
            }
        }

        private void Save_Click(object sender, EventArgs e) {
            saveFileDialog.FileName = openFileDialog.SafeFileName;

            if (saveFileDialog.ShowDialog() == DialogResult.Cancel)
                return;
            //if (Path.GetExtension(openFileDialog.SafeFileName) == "")

            fileName = saveFileDialog.FileName;
            string dataJson = JsonConvert.SerializeObject(skills);
            File.WriteAllText(fileName, dataJson);

        }

        private void ShonDataview_Click(object sender, EventArgs e) {
            Button button = (Button)sender;
            if (dataviewshow)
                button.Text = "shon dataview  ";
            else
                button.Text = "shonoff dataview  ";
            dataviewshow = !dataviewshow;
            if (skillDataView.TabIndex == -1)
                skillDataView.TabIndex = 0;
            skillDataView.Visible = dataviewshow;
        }

        private void Create_Click(object sender, EventArgs e) {
            if (skills != null)
                skills = null;
            SelectOpition.Visible = true;
            
            Initialize();
            refreshList();

        }

        private void AddData_Click(object sender, EventArgs e) {

            skillData.Add(new SkillInfo(skillData[skillData.Count - 1].SkillID + 1));
            skillDataView.DataSource = null;
            skillDataView.DataSource = skillData;

            refreshList();

        }

       
    }
}
