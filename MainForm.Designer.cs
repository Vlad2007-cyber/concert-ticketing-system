namespace lab2OOP
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        private MaterialSkin.Controls.MaterialTextBox searchTextBox;
        private MaterialSkin.Controls.MaterialButton searchBtn;
        private System.Windows.Forms.Button addRecordBtn;
        private System.Windows.Forms.Button showListBtn;
        private System.Windows.Forms.ListView computerListView;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.TextBox processorTextBox;
        private System.Windows.Forms.TextBox ramTextBox;
        private System.Windows.Forms.TextBox storageTextBox;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label processorLabel;
        private System.Windows.Forms.Label ramLabel;
        private System.Windows.Forms.Label storageLabel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.searchTextBox = new MaterialSkin.Controls.MaterialTextBox();
            this.searchBtn = new MaterialSkin.Controls.MaterialButton();
            this.addRecordBtn = new System.Windows.Forms.Button();
            this.showListBtn = new System.Windows.Forms.Button();
            this.computerListView = new System.Windows.Forms.ListView();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.processorTextBox = new System.Windows.Forms.TextBox();
            this.ramTextBox = new System.Windows.Forms.TextBox();
            this.storageTextBox = new System.Windows.Forms.TextBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.processorLabel = new System.Windows.Forms.Label();
            this.ramLabel = new System.Windows.Forms.Label();
            this.storageLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();

            // 
            // searchTextBox
            // 
            this.searchTextBox.AnimateReadOnly = false;
            this.searchTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.searchTextBox.Depth = 0;
            this.searchTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.searchTextBox.Hint = "Enter name, processor or time...";
            this.searchTextBox.LeadingIcon = null;
            this.searchTextBox.Location = new System.Drawing.Point(20, 80);
            this.searchTextBox.MaxLength = 50;
            this.searchTextBox.MouseState = MaterialSkin.MouseState.OUT;
            this.searchTextBox.Multiline = false;
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(250, 50);
            this.searchTextBox.TabIndex = 0;
            this.searchTextBox.Text = "";
            this.searchTextBox.TrailingIcon = null;

            // 
            // searchBtn
            // 
            this.searchBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.searchBtn.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.searchBtn.Depth = 0;
            this.searchBtn.HighEmphasis = true;
            this.searchBtn.Icon = null;
            this.searchBtn.Location = new System.Drawing.Point(290, 92);
            this.searchBtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.searchBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.searchBtn.Name = "searchBtn";
            this.searchBtn.NoAccentTextColor = System.Drawing.Color.Empty;
            this.searchBtn.Size = new System.Drawing.Size(78, 36);
            this.searchBtn.TabIndex = 1;
            this.searchBtn.Text = "Search";
            this.searchBtn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.searchBtn.UseAccentColor = false;
            this.searchBtn.UseVisualStyleBackColor = true;

            // 
            // computerListView
            // 
            this.computerListView.FullRowSelect = true;
            this.computerListView.GridLines = true;
            this.computerListView.HideSelection = false;
            this.computerListView.Location = new System.Drawing.Point(20, 145);
            this.computerListView.Name = "computerListView";
            this.computerListView.Size = new System.Drawing.Size(570, 315);
            this.computerListView.TabIndex = 2;
            this.computerListView.UseCompatibleStateImageBehavior = false;
            this.computerListView.View = System.Windows.Forms.View.Details;

            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(620, 80);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(101, 15);
            this.nameLabel.TabIndex = 3;
            this.nameLabel.Text = "Computer name";

            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(620, 105);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(170, 23);
            this.nameTextBox.TabIndex = 4;

            // 
            // processorLabel
            // 
            this.processorLabel.AutoSize = true;
            this.processorLabel.Location = new System.Drawing.Point(620, 145);
            this.processorLabel.Name = "processorLabel";
            this.processorLabel.Size = new System.Drawing.Size(58, 15);
            this.processorLabel.TabIndex = 5;
            this.processorLabel.Text = "Processor";

            // 
            // processorTextBox
            // 
            this.processorTextBox.Location = new System.Drawing.Point(620, 170);
            this.processorTextBox.Name = "processorTextBox";
            this.processorTextBox.Size = new System.Drawing.Size(170, 23);
            this.processorTextBox.TabIndex = 6;

            // 
            // ramLabel
            // 
            this.ramLabel.AutoSize = true;
            this.ramLabel.Location = new System.Drawing.Point(620, 210);
            this.ramLabel.Name = "ramLabel";
            this.ramLabel.Size = new System.Drawing.Size(32, 15);
            this.ramLabel.TabIndex = 7;
            this.ramLabel.Text = "RAM";

            // 
            // ramTextBox
            // 
            this.ramTextBox.Location = new System.Drawing.Point(620, 235);
            this.ramTextBox.Name = "ramTextBox";
            this.ramTextBox.Size = new System.Drawing.Size(170, 23);
            this.ramTextBox.TabIndex = 8;

            // 
            // storageLabel
            // 
            this.storageLabel.AutoSize = true;
            this.storageLabel.Location = new System.Drawing.Point(620, 275);
            this.storageLabel.Name = "storageLabel";
            this.storageLabel.Size = new System.Drawing.Size(47, 15);
            this.storageLabel.TabIndex = 9;
            this.storageLabel.Text = "Storage";

            // 
            // storageTextBox
            // 
            this.storageTextBox.Location = new System.Drawing.Point(620, 300);
            this.storageTextBox.Name = "storageTextBox";
            this.storageTextBox.Size = new System.Drawing.Size(170, 23);
            this.storageTextBox.TabIndex = 10;

            // 
            // addRecordBtn
            // 
            this.addRecordBtn.Location = new System.Drawing.Point(620, 355);
            this.addRecordBtn.Name = "addRecordBtn";
            this.addRecordBtn.Size = new System.Drawing.Size(170, 40);
            this.addRecordBtn.TabIndex = 11;
            this.addRecordBtn.Text = "Add Record";
            this.addRecordBtn.UseVisualStyleBackColor = true;
            this.addRecordBtn.Click += new System.EventHandler(this.addRecordBtn_Click);

            // 
            // showListBtn
            // 
            this.showListBtn.Location = new System.Drawing.Point(620, 410);
            this.showListBtn.Name = "showListBtn";
            this.showListBtn.Size = new System.Drawing.Size(170, 40);
            this.showListBtn.TabIndex = 12;
            this.showListBtn.Text = "Show List";
            this.showListBtn.UseVisualStyleBackColor = true;
            this.showListBtn.Click += new System.EventHandler(this.showListBtn_Click);

            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(830, 500);
            this.Controls.Add(this.showListBtn);
            this.Controls.Add(this.addRecordBtn);
            this.Controls.Add(this.storageTextBox);
            this.Controls.Add(this.storageLabel);
            this.Controls.Add(this.ramTextBox);
            this.Controls.Add(this.ramLabel);
            this.Controls.Add(this.processorTextBox);
            this.Controls.Add(this.processorLabel);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.computerListView);
            this.Controls.Add(this.searchBtn);
            this.Controls.Add(this.searchTextBox);
            this.Name = "MainForm";
            this.Text = "Computer System";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}