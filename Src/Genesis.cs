using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using static MyDataItem;

namespace JsonDataEditor {
    public partial class ItemDataEditor : Form {
        static MyData myData;
        object[] obj;
        ItemTextBox[] itemtext;
        string fileName;
        string filepath;
        bool dataviewshow = true;
        bool isload = false;
        Label[] Labelname;
        public ItemDataEditor() {
            InitializeComponent();

        }

        private void Initialize() {
            Save.Visible = true;
            obj = new object[2];
            obj[0] = new ComboBox();
            dataGridView1.DataSource = myData.items;
            AddDatabtn.Visible = true;
            if (itemtext == null) {
                itemtext = new ItemTextBox[dataGridView1.ColumnCount];
                Labelname = new Label[dataGridView1.ColumnCount];
                for (int i = 0; i < dataGridView1.ColumnCount; i++) {
                    itemtext[i] = new ItemTextBox(i);
                    Labelname[i] = new Label();
                    this.Controls.Add(itemtext[i]);
                    this.Controls.Add(Labelname[i]);
                    //itemtext[i].DataBindings.Add("Text", myData.items, dataGridView1.Columns[i].Name, true);
                    Labelname[i].Text = dataGridView1.Columns[i].Name;
                    if (dataGridView1.Columns[i].Name == "ItemDesc") {
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
            myData = JsonConvert.DeserializeObject<MyData>(dataJson);
            Initialize();

            editBox.Text = myData.items[0].GetAll();


            dataGridView1.DataSource = myData.items;
            SelectOpition.Visible = true;
            refreshList();

            if (myData != null) {
                Dataviewbtn.Enabled = true;

                for (int i = 0; i < dataGridView1.ColumnCount; i++) {

                    itemtext[i].Text = dataGridView1.Rows[SelectOpition.SelectedIndex].Cells[i].Value.ToString();
                    Console.WriteLine();


                }
            }
          ;
            isload = false;
        }

        private void Genesis_TextChanged(object sender, EventArgs e) {
            ItemTextBox textBox = (ItemTextBox)sender;
            if (SelectOpition.SelectedIndex == -1)
                return;
            if (textBox.Text == null)
                dataGridView1.Rows[SelectOpition.SelectedIndex].Cells[textBox.index].Value = null;
            else if (dataGridView1.Columns[textBox.index].Name == "ItemType")
                switch (textBox.Text) {
                    case "-1":
                        dataGridView1.Rows[SelectOpition.SelectedIndex].Cells[textBox.index].Value = ITEMTYPE.Unknown;
                        textBox.Text = dataGridView1.Rows[SelectOpition.SelectedIndex].Cells[textBox.index].Value.ToString();
                        break;
                    case "0":
                        dataGridView1.Rows[SelectOpition.SelectedIndex].Cells[textBox.index].Value = ITEMTYPE.Equip;
                        textBox.Text = dataGridView1.Rows[SelectOpition.SelectedIndex].Cells[textBox.index].Value.ToString();
                        break;
                    case "1":
                        dataGridView1.Rows[SelectOpition.SelectedIndex].Cells[textBox.index].Value = ITEMTYPE.Chips;
                        textBox.Text = dataGridView1.Rows[SelectOpition.SelectedIndex].Cells[textBox.index].Value.ToString();
                        break;
                    default:
                        break;
                }
            else if (dataGridView1.Rows[SelectOpition.SelectedIndex].Cells[textBox.index].Value.ToString() != textBox.Text && !isload) {
                dataGridView1.Rows[SelectOpition.SelectedIndex].Cells[textBox.index].Value = textBox.Text;
                refreshList();
            }
        }
        void refreshList() {

            SelectOpition.DataSource = null;
            SelectOpition.Items.Clear();
            SelectOpition.DataSource = dataGridView1.DataSource;
            SelectOpition.DisplayMember = "ItemName";
            SelectOpition.ValueMember = "ItemID";

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) {


            if (SelectOpition.SelectedIndex != -1) {
                if (itemtext != null)
                    for (int i = 0; i < dataGridView1.ColumnCount; i++) {
                        isload = true;
                        if (dataGridView1.Rows[SelectOpition.SelectedIndex].Cells[i].Value != null)
                            itemtext[i].Text = dataGridView1.Rows[SelectOpition.SelectedIndex].Cells[i].Value.ToString();
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
            string dataJson = JsonConvert.SerializeObject(myData);
            File.WriteAllText(fileName, dataJson);

        }

        private void ShonDataview_Click(object sender, EventArgs e) {
            Button button = (Button)sender;
            if (dataviewshow)
                button.Text = "shon dataview  ";
            else
                button.Text = "shonoff dataview  ";
            dataviewshow = !dataviewshow;
            if (dataGridView1.TabIndex == -1)
                dataGridView1.TabIndex = 0;
            dataGridView1.Visible = dataviewshow;
        }

        private void Create_Click(object sender, EventArgs e) {
            Dataviewbtn.Enabled = true;
            SelectOpition.Visible = true;
            myData = new MyData(new List<MyDataItem>());
            myData.items.Add(new MyDataItem());
            dataGridView1.Visible = true;
            Initialize();
        }

        private void AddData_Click(object sender, EventArgs e) {

            myData.items.Add(new MyDataItem(int.Parse(myData.items[myData.items.Count - 1].ItemID) + 1));
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = myData.items;

            refreshList();

        }


    }
}
