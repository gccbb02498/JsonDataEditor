using JsonDataEditor.dataBase;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using JsonDataEditor.Manager;
namespace JsonDataEditor
{
    public partial class SkillDataEditor : Form
    {
        private static SkillDatas skills;
        private static List<SkillInfo> skillData;
        private object[] obj;
        private ItemTextBox[] itemtext;
        private string fileName;
        private string filepath;
        private bool dataviewshow = true;
        private bool isload = false;
        private Label[] Labelname;

        public SkillDataEditor()
        {
            InitializeComponent();
            BaseDataManager.Instance.GetBase(Basetype.SkillInfo);
        }

        private void Initialize()
        {
            if (skills == null)
                skills = new SkillDatas(new List<SkillInfo>());
            skillData = skills.skillDatas;
            if (skillData.Count == 0)
                skillData.Add(new SkillInfo());
            skillDataView.Visible = dataviewshow;
            Dataviewbtn.Enabled = true;
            Save.Visible = true;
            obj = new object[2];
            obj[0] = new ComboBox();
            skillDataView.DataSource = skills.skillDatas;
            AddDatabtn.Visible = true;

            if (itemtext == null)
                itemtext = new ItemTextBox[skillDataView.ColumnCount];
            if (Labelname == null)
                Labelname = new Label[skillDataView.ColumnCount];

            for (int i = 0; i < skillDataView.ColumnCount; i++)
            {
                if (itemtext[i] == null)
                {
                    itemtext[i] = new ItemTextBox(i);
                    this.Controls.Add(itemtext[i]);
                    itemtext[i].SetBounds(80, (5 + (i == 0 ? 10 : itemtext[i - 1].Location.Y + itemtext[i - 1].Height)), 2 * itemtext[i].Width, itemtext[i].Height);
                    itemtext[i].TextChanged += Genesis_TextChanged;
                }
                if (Labelname[i] == null)
                {
                    Labelname[i] = new Label();
                    this.Controls.Add(Labelname[i]);
                    Labelname[i].AutoSize = true;
                    Labelname[i].SetBounds(10, (5 + (i == 0 ? 10 : itemtext[i - 1].Location.Y + itemtext[i - 1].Height)), Labelname[i].Width, Labelname[i].Height);
                }
                //itemtext[i].DataBindings.Add("Text", myData.items, dataGridView1.Columns[i].Name, true);
                object obj = skillDataView.Rows[0].Cells[i].Value;
                itemtext[i].Text = obj == null ? string.Empty : obj.ToString();
                Labelname[i].Text = skillDataView.Columns[i].Name;
                if (skillDataView.Columns[i].Name == "ItemDesc")
                {
                    itemtext[i].Multiline = true;
                    itemtext[i].Height *= 3;
                    itemtext[i].ScrollBars = ScrollBars.Vertical;
                }
                else
                    itemtext[i].AutoSize = true;
            }
        }

        private void Openfilebtn_Click(object sender, EventArgs e)
        {
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

            if (skills != null)
            {
                Dataviewbtn.Enabled = true;

                for (int i = 0; i < skillDataView.ColumnCount; i++)
                {
                    if (skillDataView.Rows[SelectOpition.SelectedIndex].Cells[i].Value != null)
                    {
                        itemtext[i].Text = skillDataView.Rows[SelectOpition.SelectedIndex].Cells[i].Value.ToString();
                        Console.WriteLine(itemtext[i].Text = skillDataView.Rows[SelectOpition.SelectedIndex].Cells[i].Value.ToString());
                    }
                }
            }

            isload = false;
        }

        private void Genesis_TextChanged(object sender, EventArgs e)
        {
            ItemTextBox textBox = (ItemTextBox)sender;
            if (SelectOpition.SelectedIndex == -1)
                return;
            DataGridViewCell s = skillDataView.Rows[SelectOpition.SelectedIndex].Cells[textBox.index];
            if (textBox.Text == null)
                skillDataView.Rows[SelectOpition.SelectedIndex].Cells[textBox.index].Value = null;
            else if (s.Value == null || s.ToString() != textBox.Text && !isload)
            {
                skillDataView.Rows[SelectOpition.SelectedIndex].Cells[textBox.index].Value = textBox.Text;
                refreshList();
            }
        }

        private void refreshList()
        {
            SelectOpition.DataSource = null;
            SelectOpition.Items.Clear();
            SelectOpition.DataSource = skillDataView.DataSource;
            SelectOpition.DisplayMember = "SkillName";
            SelectOpition.ValueMember = "SkillID";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SelectOpition.SelectedIndex != -1)
            {
                if (itemtext != null)
                    for (int i = 0; i < skillDataView.ColumnCount; i++)
                    {
                        isload = true;

                        object obj = skillDataView.Rows[SelectOpition.SelectedIndex].Cells[i].Value;
                        itemtext[i].Text = obj == null ? string.Empty : obj.ToString();

                        isload = false;
                        itemtext[i].Visible = true;
                        itemtext[i].AutoSize = true;
                    }
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            saveFileDialog.FileName = openFileDialog.SafeFileName;

            if (saveFileDialog.ShowDialog() == DialogResult.Cancel)
                return;
            //if (Path.GetExtension(openFileDialog.SafeFileName) == "")

            fileName = saveFileDialog.FileName;
            string dataJson = JsonConvert.SerializeObject(skills);
            File.WriteAllText(fileName, dataJson);
        }

        private void ShonDataview_Click(object sender, EventArgs e)
        {
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

        private void Create_Click(object sender, EventArgs e)
        {
            if (skills != null)
                skills = null;
            SelectOpition.Visible = true;
            Initialize();
            refreshList();
        }

        private void AddData_Click(object sender, EventArgs e)
        {
            //skillData.Add(new SkillInfo(skillData[skillData.Count - 1].SkillID + 1));
            skillDataView.DataSource = null;
            skillDataView.DataSource = skillData;

            refreshList();
        }

        private void SkillDataEditor_Load(object sender, EventArgs e)
        {
        }

        private void SkillDataEditor_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }
    }
}