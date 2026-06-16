namespace TELauncher
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            LaunchButton = new Button();
            MapPackList = new ListBox();
            label1 = new Label();
            AddButton = new Button();
            SuspendLayout();
            // 
            // LaunchButton
            // 
            LaunchButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LaunchButton.Location = new Point(12, 12);
            LaunchButton.Name = "LaunchButton";
            LaunchButton.Size = new Size(346, 76);
            LaunchButton.TabIndex = 0;
            LaunchButton.Text = "Launch The Escapists\r\nNo File Pack (Default) Selected";
            LaunchButton.UseVisualStyleBackColor = true;
            LaunchButton.Click += launchButton_Click;
            // 
            // MapPackList
            // 
            MapPackList.FormattingEnabled = true;
            MapPackList.Items.AddRange(new object[] { "No File Pack (Default)" });
            MapPackList.Location = new Point(12, 121);
            MapPackList.Name = "MapPackList";
            MapPackList.Size = new Size(346, 319);
            MapPackList.TabIndex = 1;
            MapPackList.SelectedIndexChanged += MapPackList_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 103);
            label1.Name = "label1";
            label1.Size = new Size(90, 15);
            label1.TabIndex = 2;
            label1.Text = "Select File Pack:";
            // 
            // AddButton
            // 
            AddButton.Location = new Point(12, 446);
            AddButton.Name = "AddButton";
            AddButton.Size = new Size(346, 23);
            AddButton.TabIndex = 3;
            AddButton.Text = "Create File Pack";
            AddButton.UseVisualStyleBackColor = true;
            AddButton.Click += AddButton_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(370, 475);
            Controls.Add(AddButton);
            Controls.Add(label1);
            Controls.Add(MapPackList);
            Controls.Add(LaunchButton);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "MainForm";
            Text = "TELauncher";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button LaunchButton;
        private ListBox MapPackList;
        private Label label1;
        private Button AddButton;
    }
}
