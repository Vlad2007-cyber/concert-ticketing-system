using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace lab2OOP
{
    public partial class MainForm : MaterialForm
    {
        private ComputerManager computerManager = new ComputerManager();

        public MainForm()
        {
            InitializeComponent();

            searchBtn.Click += searchBtn_Click;

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

            computerListView.View = View.Details;
            computerListView.FullRowSelect = true;
            computerListView.GridLines = true;

            computerListView.Columns.Add("#", 40);
            computerListView.Columns.Add("Name", 140);
            computerListView.Columns.Add("Processor", 140);
            computerListView.Columns.Add("RAM", 80);
            computerListView.Columns.Add("Storage", 100);
            computerListView.Columns.Add("Created", 150);
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
                    devices,
                    DateTime.Now);

                computerManager.Add(computer);

                FileManager.Add(driver);
                FileManager.Add(systemUnit);
                FileManager.Add(monitor);
                FileManager.Add(mouse);
                FileManager.Add(computer);

                ListViewItem item = new ListViewItem(
                    (computerListView.Items.Count + 1).ToString());

                item.SubItems.Add(computer.Name ?? "");
                item.SubItems.Add(systemUnit.Processor ?? "");
                item.SubItems.Add(systemUnit.RAM.ToString());
                item.SubItems.Add(systemUnit.StorageCapacity.ToString());
                item.SubItems.Add(computer.CreatedAt.ToString("dd.MM.yyyy HH:mm"));

                computerListView.Items.Add(item);

                nameTextBox.Clear();
                processorTextBox.Clear();
                ramTextBox.Clear();
                storageTextBox.Clear();

                MessageBox.Show("Record added successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void showListBtn_Click(object sender, EventArgs e)
        {
            if (computerManager.Count == 0)
            {
                MessageBox.Show("The list is empty.");
                return;
            }

            string result = "";

            for (int i = 0; i < computerManager.Count; i++)
            {
                Computer computer = computerManager[i];

                result +=
                    $"{i + 1}. " +
                    $"Name: {computer.Name}, " +
                    $"Processor: {computer.SystemUnit?.Processor}, " +
                    $"RAM: {computer.SystemUnit?.RAM} GB, " +
                    $"Storage: {computer.SystemUnit?.StorageCapacity} GB, " +
                    $"Created: {computer.CreatedAt:dd.MM.yyyy HH:mm}\n";
            }

            MessageBox.Show(result, "Computer List");
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            computerListView.Items.Clear();

            List<Computer> foundComputers = computerManager.Search(searchTextBox.Text);

            if (foundComputers.Count == 0)
            {
                MessageBox.Show("Nothing found.");
                return;
            }

            for (int i = 0; i < foundComputers.Count; i++)
            {
                Computer computer = foundComputers[i];

                ListViewItem item = new ListViewItem((i + 1).ToString());

                item.SubItems.Add(computer.Name ?? "");
                item.SubItems.Add(computer.SystemUnit?.Processor ?? "");
                item.SubItems.Add(computer.SystemUnit?.RAM.ToString() ?? "");
                item.SubItems.Add(computer.SystemUnit?.StorageCapacity.ToString() ?? "");
                item.SubItems.Add(computer.CreatedAt.ToString("dd.MM.yyyy HH:mm"));

                computerListView.Items.Add(item);
            }
        }
    }
}