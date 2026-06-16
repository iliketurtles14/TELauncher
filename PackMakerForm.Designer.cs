namespace TELauncher
{
    partial class PackMakerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PackMakerForm));
            SelectListBox = new ListBox();
            AddFileButton = new Button();
            CreateButton = new Button();
            CancelButton = new Button();
            label1 = new Label();
            NameTextBox = new TextBox();
            label2 = new Label();
            AddedListBox = new ListBox();
            RemoveFileButton = new Button();
            label3 = new Label();
            SuspendLayout();
            // 
            // SelectListBox
            // 
            SelectListBox.FormattingEnabled = true;
            SelectListBox.Items.AddRange(new object[] { "Custom Tileset Texture", "Custom Ground Texture", "save1 Folder", "save2 Folder", "save3 Folder", "Music Folder", "Custom Speech File", "global.dat File", "items_eng.dat File", "data_eng.dat File", "val.dat File" });
            SelectListBox.Location = new Point(13, 29);
            SelectListBox.Name = "SelectListBox";
            SelectListBox.Size = new Size(138, 169);
            SelectListBox.TabIndex = 0;
            SelectListBox.SelectedIndexChanged += SelectListBox_SelectedIndexChanged;
            // 
            // AddFileButton
            // 
            AddFileButton.Font = new Font("Segoe UI Black", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            AddFileButton.Location = new Point(156, 29);
            AddFileButton.Name = "AddFileButton";
            AddFileButton.Size = new Size(25, 25);
            AddFileButton.TabIndex = 1;
            AddFileButton.Text = "+";
            AddFileButton.UseVisualStyleBackColor = true;
            AddFileButton.Click += AddFileButton_Click;
            // 
            // CreateButton
            // 
            CreateButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            CreateButton.Location = new Point(334, 231);
            CreateButton.Name = "CreateButton";
            CreateButton.Size = new Size(75, 23);
            CreateButton.TabIndex = 2;
            CreateButton.Text = "Create";
            CreateButton.UseVisualStyleBackColor = true;
            CreateButton.Click += CreateButton_Click;
            // 
            // CancelButton
            // 
            CancelButton.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            CancelButton.Location = new Point(253, 231);
            CancelButton.Name = "CancelButton";
            CancelButton.Size = new Size(75, 23);
            CancelButton.TabIndex = 3;
            CancelButton.Text = "Cancel";
            CancelButton.UseVisualStyleBackColor = true;
            CancelButton.Click += CancelButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 11);
            label1.Name = "label1";
            label1.Size = new Size(143, 15);
            label1.TabIndex = 4;
            label1.Text = "Select files/folders to add:";
            // 
            // NameTextBox
            // 
            NameTextBox.Location = new Point(13, 231);
            NameTextBox.Name = "NameTextBox";
            NameTextBox.Size = new Size(138, 23);
            NameTextBox.TabIndex = 5;
            NameTextBox.Text = "No Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(13, 213);
            label2.Name = "label2";
            label2.Size = new Size(153, 15);
            label2.TabIndex = 6;
            label2.Text = "Set a name for the file pack:";
            // 
            // AddedListBox
            // 
            AddedListBox.FormattingEnabled = true;
            AddedListBox.Location = new Point(220, 29);
            AddedListBox.Name = "AddedListBox";
            AddedListBox.Size = new Size(189, 199);
            AddedListBox.TabIndex = 7;
            AddedListBox.SelectedIndexChanged += AddedListBox_SelectedIndexChanged_1;
            // 
            // RemoveFileButton
            // 
            RemoveFileButton.Font = new Font("Segoe UI Black", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            RemoveFileButton.Location = new Point(189, 203);
            RemoveFileButton.Name = "RemoveFileButton";
            RemoveFileButton.Size = new Size(25, 25);
            RemoveFileButton.TabIndex = 8;
            RemoveFileButton.Text = "-";
            RemoveFileButton.UseVisualStyleBackColor = true;
            RemoveFileButton.Click += RemoveFileButton_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(220, 11);
            label3.Name = "label3";
            label3.Size = new Size(56, 15);
            label3.TabIndex = 9;
            label3.Text = "File pack:";
            // 
            // PackMakerForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(422, 266);
            Controls.Add(label3);
            Controls.Add(RemoveFileButton);
            Controls.Add(AddedListBox);
            Controls.Add(label2);
            Controls.Add(NameTextBox);
            Controls.Add(label1);
            Controls.Add(CancelButton);
            Controls.Add(CreateButton);
            Controls.Add(AddFileButton);
            Controls.Add(SelectListBox);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "PackMakerForm";
            Text = "Create File Pack";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox SelectListBox;
        private Button AddFileButton;
        private Button CreateButton;
        private Button CancelButton;
        private Label label1;
        private TextBox NameTextBox;
        private Label label2;
        private ListBox AddedListBox;
        private Button RemoveFileButton;
        private Label label3;
    }
}