
namespace Stameska.View
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.HandleLable = new System.Windows.Forms.Label();
            this.BladeLengthLabel = new System.Windows.Forms.Label();
            this.DiametrLabel = new System.Windows.Forms.Label();
            this.BladeHeightLabel = new System.Windows.Forms.Label();
            this.WidthLabel = new System.Windows.Forms.Label();
            this.CreateButton = new System.Windows.Forms.Button();
            this.ButPanel = new System.Windows.Forms.Panel();
            this.radioButtonCornerModel = new System.Windows.Forms.RadioButton();
            this.radioButtonStraightModel = new System.Windows.Forms.RadioButton();
            this.ChiselWidthTextBox = new System.Windows.Forms.TextBox();
            this.BladeHeigthTextBox = new System.Windows.Forms.TextBox();
            this.RingTextBox = new System.Windows.Forms.TextBox();
            this.BladeLengthTextBox = new System.Windows.Forms.TextBox();
            this.HandleTextBox = new System.Windows.Forms.TextBox();
            this.headLableBut = new System.Windows.Forms.Label();
            this.toolTipInformation = new System.Windows.Forms.ToolTip(this.components);
            this.panelChiselPhoto = new System.Windows.Forms.Panel();
            this.ButPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // HandleLable
            // 
            this.HandleLable.AutoSize = true;
            this.HandleLable.Location = new System.Drawing.Point(42, 74);
            this.HandleLable.Name = "HandleLable";
            this.HandleLable.Size = new System.Drawing.Size(100, 17);
            this.HandleLable.TabIndex = 7;
            this.HandleLable.Text = "Hangle length ";
            // 
            // BladeLengthLabel
            // 
            this.BladeLengthLabel.AutoSize = true;
            this.BladeLengthLabel.Location = new System.Drawing.Point(42, 124);
            this.BladeLengthLabel.Name = "BladeLengthLabel";
            this.BladeLengthLabel.Size = new System.Drawing.Size(87, 17);
            this.BladeLengthLabel.TabIndex = 8;
            this.BladeLengthLabel.Text = "Blade length";
            // 
            // DiametrLabel
            // 
            this.DiametrLabel.AutoSize = true;
            this.DiametrLabel.Location = new System.Drawing.Point(42, 224);
            this.DiametrLabel.Name = "DiametrLabel";
            this.DiametrLabel.Size = new System.Drawing.Size(92, 17);
            this.DiametrLabel.TabIndex = 9;
            this.DiametrLabel.Text = "Ring diametr ";
            // 
            // BladeHeightLabel
            // 
            this.BladeHeightLabel.AutoSize = true;
            this.BladeHeightLabel.Location = new System.Drawing.Point(42, 175);
            this.BladeHeightLabel.Name = "BladeHeightLabel";
            this.BladeHeightLabel.Size = new System.Drawing.Size(87, 17);
            this.BladeHeightLabel.TabIndex = 10;
            this.BladeHeightLabel.Text = "Blade height";
            // 
            // WidthLabel
            // 
            this.WidthLabel.AutoSize = true;
            this.WidthLabel.Location = new System.Drawing.Point(42, 274);
            this.WidthLabel.Name = "WidthLabel";
            this.WidthLabel.Size = new System.Drawing.Size(82, 17);
            this.WidthLabel.TabIndex = 11;
            this.WidthLabel.Text = "Chisel width";
            // 
            // CreateButton
            // 
            this.CreateButton.Enabled = false;
            this.CreateButton.Location = new System.Drawing.Point(104, 326);
            this.CreateButton.Name = "CreateButton";
            this.CreateButton.Size = new System.Drawing.Size(140, 30);
            this.CreateButton.TabIndex = 5;
            this.CreateButton.Text = "Create model";
            this.CreateButton.UseVisualStyleBackColor = true;
            this.CreateButton.Click += new System.EventHandler(this.CreateButton_Click);
            // 
            // ButPanel
            // 
            this.ButPanel.Controls.Add(this.radioButtonCornerModel);
            this.ButPanel.Controls.Add(this.radioButtonStraightModel);
            this.ButPanel.Controls.Add(this.ChiselWidthTextBox);
            this.ButPanel.Controls.Add(this.BladeHeigthTextBox);
            this.ButPanel.Controls.Add(this.RingTextBox);
            this.ButPanel.Controls.Add(this.BladeLengthTextBox);
            this.ButPanel.Controls.Add(this.HandleTextBox);
            this.ButPanel.Controls.Add(this.headLableBut);
            this.ButPanel.Controls.Add(this.BladeLengthLabel);
            this.ButPanel.Controls.Add(this.CreateButton);
            this.ButPanel.Controls.Add(this.WidthLabel);
            this.ButPanel.Controls.Add(this.BladeHeightLabel);
            this.ButPanel.Controls.Add(this.DiametrLabel);
            this.ButPanel.Controls.Add(this.HandleLable);
            this.ButPanel.Location = new System.Drawing.Point(0, 149);
            this.ButPanel.Name = "ButPanel";
            this.ButPanel.Size = new System.Drawing.Size(348, 371);
            this.ButPanel.TabIndex = 14;
            // 
            // radioButtonCornerModel
            // 
            this.radioButtonCornerModel.AutoSize = true;
            this.radioButtonCornerModel.Location = new System.Drawing.Point(186, 36);
            this.radioButtonCornerModel.Name = "radioButtonCornerModel";
            this.radioButtonCornerModel.Size = new System.Drawing.Size(111, 21);
            this.radioButtonCornerModel.TabIndex = 7;
            this.radioButtonCornerModel.Text = "Corner blade";
            this.radioButtonCornerModel.UseVisualStyleBackColor = true;
            this.radioButtonCornerModel.Click += new System.EventHandler(this.radioButtonModel_Click);
            // 
            // radioButtonStraightModel
            // 
            this.radioButtonStraightModel.AutoSize = true;
            this.radioButtonStraightModel.Checked = true;
            this.radioButtonStraightModel.Location = new System.Drawing.Point(25, 36);
            this.radioButtonStraightModel.Name = "radioButtonStraightModel";
            this.radioButtonStraightModel.Size = new System.Drawing.Size(117, 21);
            this.radioButtonStraightModel.TabIndex = 6;
            this.radioButtonStraightModel.TabStop = true;
            this.radioButtonStraightModel.Text = "Straight blade";
            this.radioButtonStraightModel.UseVisualStyleBackColor = true;
            this.radioButtonStraightModel.Click += new System.EventHandler(this.radioButtonModel_Click);
            // 
            // ChiselWidthTextBox
            // 
            this.ChiselWidthTextBox.Location = new System.Drawing.Point(197, 272);
            this.ChiselWidthTextBox.Name = "ChiselWidthTextBox";
            this.ChiselWidthTextBox.Size = new System.Drawing.Size(100, 22);
            this.ChiselWidthTextBox.TabIndex = 4;
            this.ChiselWidthTextBox.Text = "27";
            this.ChiselWidthTextBox.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            this.ChiselWidthTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ChiselWidthTextBox_KeyPress);
            this.ChiselWidthTextBox.Leave += new System.EventHandler(this.ChiselWidthTextBox_Leave);
            // 
            // BladeHeigthTextBox
            // 
            this.BladeHeigthTextBox.Location = new System.Drawing.Point(197, 172);
            this.BladeHeigthTextBox.Name = "BladeHeigthTextBox";
            this.BladeHeigthTextBox.Size = new System.Drawing.Size(100, 22);
            this.BladeHeigthTextBox.TabIndex = 2;
            this.BladeHeigthTextBox.Text = "15";
            this.BladeHeigthTextBox.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            this.BladeHeigthTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.BladeHeigthTextBox_KeyPress);
            this.BladeHeigthTextBox.Leave += new System.EventHandler(this.BladeHeigthTextBox_Leave);
            // 
            // RingTextBox
            // 
            this.RingTextBox.Location = new System.Drawing.Point(197, 221);
            this.RingTextBox.Name = "RingTextBox";
            this.RingTextBox.Size = new System.Drawing.Size(100, 22);
            this.RingTextBox.TabIndex = 3;
            this.RingTextBox.Text = "17";
            this.RingTextBox.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            this.RingTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.RingTextBox_KeyPress);
            this.RingTextBox.Leave += new System.EventHandler(this.RingTextBox_Leave);
            // 
            // BladeLengthTextBox
            // 
            this.BladeLengthTextBox.Location = new System.Drawing.Point(197, 122);
            this.BladeLengthTextBox.Name = "BladeLengthTextBox";
            this.BladeLengthTextBox.Size = new System.Drawing.Size(100, 22);
            this.BladeLengthTextBox.TabIndex = 1;
            this.BladeLengthTextBox.Text = "133";
            this.BladeLengthTextBox.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            this.BladeLengthTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.BladeLengthTextBox_KeyPress);
            this.BladeLengthTextBox.Leave += new System.EventHandler(this.BladeLengthTextBox_Leave);
            // 
            // HandleTextBox
            // 
            this.HandleTextBox.Location = new System.Drawing.Point(197, 71);
            this.HandleTextBox.Name = "HandleTextBox";
            this.HandleTextBox.Size = new System.Drawing.Size(100, 22);
            this.HandleTextBox.TabIndex = 0;
            this.HandleTextBox.Text = "120";
            this.HandleTextBox.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            this.HandleTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.HandleTextBox_KeyPress);
            this.HandleTextBox.Leave += new System.EventHandler(this.HandleTextBox_Leave);
            // 
            // headLableBut
            // 
            this.headLableBut.AutoSize = true;
            this.headLableBut.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.headLableBut.Location = new System.Drawing.Point(77, 8);
            this.headLableBut.Name = "headLableBut";
            this.headLableBut.Size = new System.Drawing.Size(187, 25);
            this.headLableBut.TabIndex = 17;
            this.headLableBut.Text = "Chisel parameters";
            // 
            // panelChiselPhoto
            // 
            this.panelChiselPhoto.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelChiselPhoto.BackgroundImage")));
            this.panelChiselPhoto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelChiselPhoto.Location = new System.Drawing.Point(0, 0);
            this.panelChiselPhoto.Name = "panelChiselPhoto";
            this.panelChiselPhoto.Size = new System.Drawing.Size(345, 143);
            this.panelChiselPhoto.TabIndex = 15;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(342, 523);
            this.Controls.Add(this.ButPanel);
            this.Controls.Add(this.panelChiselPhoto);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(360, 570);
            this.MinimumSize = new System.Drawing.Size(360, 570);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chisel creater";
            this.ButPanel.ResumeLayout(false);
            this.ButPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Label HandleLable;
        private System.Windows.Forms.Label BladeLengthLabel;
        private System.Windows.Forms.Label DiametrLabel;
        private System.Windows.Forms.Label BladeHeightLabel;
        private System.Windows.Forms.Label WidthLabel;
        private System.Windows.Forms.Button CreateButton;
        private System.Windows.Forms.Panel ButPanel;
        private System.Windows.Forms.Label headLableBut;
        private System.Windows.Forms.ToolTip toolTipInformation;
        private System.Windows.Forms.Panel panelChiselPhoto;
        private System.Windows.Forms.TextBox ChiselWidthTextBox;
        private System.Windows.Forms.TextBox BladeHeigthTextBox;
        private System.Windows.Forms.TextBox RingTextBox;
        private System.Windows.Forms.TextBox BladeLengthTextBox;
        private System.Windows.Forms.TextBox HandleTextBox;
        private System.Windows.Forms.RadioButton radioButtonCornerModel;
        private System.Windows.Forms.RadioButton radioButtonStraightModel;
    }
}

