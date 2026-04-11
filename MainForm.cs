using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace lab2OOP
{
    public partial class MainForm : MaterialForm
    {
        private List<Computer> computers = new List<Computer>();

        public MainForm()
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Blue600,
                Primary.Blue700,
                Primary.Blue200,
                Accent.LightBlue200,
                TextShade.WHITE);

            computerListView.Columns.Clear();
            computerListView.Columns.Add("#", 40);
            computerListView.Columns.Add("Name", 140);
            computerListView.Columns.Add("Processor", 140);
            computerListView.Columns.Add("RAM", 80);
            computerListView.Columns.Add("Storage", 100);
        }

        private void addRecordBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(nameTextBox.Text) ||
                string.IsNullOrWhiteSpace(processorTextBox.Text) ||
                string.IsNullOrWhiteSpace(ramTextBox.Text) ||
                string.IsNullOrWhiteSpace(storageTextBox.Text))
            {
                MessageBox.Show("Fill in all fields.");
                return;
            }

            if (!int.TryParse(ramTextBox.Text, out int ram))
            {
                MessageBox.Show("RAM must be a number.");
                return;
            }

            if (!int.TryParse(storageTextBox.Text, out int storage))
            {
                MessageBox.Show("Storage must be a number.");
                return;
            }

            try
            {
                Driver driver = new Driver(
                    Guid.NewGuid(),
                    "Universal Driver",
                    "1.0",
                    true,
                    true);

                SystemUnit systemUnit = new SystemUnit(
                    Guid.NewGuid(),
                    "Main System Unit",
                    driver,
                    processorTextBox.Text,
                    ram,
                    storage);

                Monitor monitor = new Monitor(
                    Guid.NewGuid(),
                    "Main Monitor",
                    driver,
                    24.0,
                    "1920x1080");

                Mouse mouse = new Mouse(
                    Guid.NewGuid(),
                    "Main Mouse",
                    driver,
                    "Wireless",
                    1600);

                List<Device> devices = new List<Device>
                {
                    monitor,
                    mouse
                };

                Computer computer = new Computer(
                    Guid.NewGuid(),
                    nameTextBox.Text,
                    systemUnit,
                    devices);

                computers.Add(computer);

                FileManager.Add(driver);
                FileManager.Add(systemUnit);
                FileManager.Add(monitor);
                FileManager.Add(mouse);
                FileManager.Add(computer);

                ListViewItem item = new ListViewItem((computerListView.Items.Count + 1).ToString());
                item.SubItems.Add(computer.Name ?? "");
                item.SubItems.Add(systemUnit.Processor ?? "");
                item.SubItems.Add(systemUnit.RAM.ToString());
                item.SubItems.Add(systemUnit.StorageCapacity.ToString());

                computerListView.Items.Add(item);

                nameTextBox.Clear();
                processorTextBox.Clear();
                ramTextBox.Clear();
                storageTextBox.Clear(); MessageBox.Show("Record added successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void showListBtn_Click(object sender, EventArgs e)
        {
            string result = Computer.ViewList();

            if (string.IsNullOrWhiteSpace(result))
            {
                MessageBox.Show("The list is empty.");
                return;
            }

            MessageBox.Show(result, "Linked List");
        }
    }
}