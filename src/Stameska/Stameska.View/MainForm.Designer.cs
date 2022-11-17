
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
            this.HangleLable = new System.Windows.Forms.Label();
            this.BladeLengthLabel = new System.Windows.Forms.Label();
            this.DiametrLabel = new System.Windows.Forms.Label();
            this.BladeHeightLabel = new System.Windows.Forms.Label();
            this.WidthLabel = new System.Windows.Forms.Label();
            this.CreateButton = new System.Windows.Forms.Button();
            this.ButPanel = new System.Windows.Forms.Panel();
            this.ChiselWidthTextBox = new System.Windows.Forms.TextBox();
            this.BladeHeigthTextBox = new System.Windows.Forms.TextBox();
            this.RingTextBox = new System.Windows.Forms.TextBox();
            this.BladeLengthTextBox = new System.Windows.Forms.TextBox();
            this.HangleTextBox = new System.Windows.Forms.TextBox();
            this.headLableBut = new System.Windows.Forms.Label();
            this.toolTipInformation = new System.Windows.Forms.ToolTip(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.ButPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // HangleLable
            // 
            this.HangleLable.AutoSize = true;
            this.HangleLable.Location = new System.Drawing.Point(44, 57);
            this.HangleLable.Name = "HangleLable";
            this.HangleLable.Size = new System.Drawing.Size(100, 17);
            this.HangleLable.TabIndex = 7;
            this.HangleLable.Text = "Hangle length ";
            // 
            // BladeLengthLabel
            // 
            this.BladeLengthLabel.AutoSize = true;
            this.BladeLengthLabel.Location = new System.Drawing.Point(44, 107);
            this.BladeLengthLabel.Name = "BladeLengthLabel";
            this.BladeLengthLabel.Size = new System.Drawing.Size(87, 17);
            this.BladeLengthLabel.TabIndex = 8;
            this.BladeLengthLabel.Text = "Blade length";
            // 
            // DiametrLabel
            // 
            this.DiametrLabel.AutoSize = true;
            this.DiametrLabel.Location = new System.Drawing.Point(44, 207);
            this.DiametrLabel.Name = "DiametrLabel";
            this.DiametrLabel.Size = new System.Drawing.Size(92, 17);
            this.DiametrLabel.TabIndex = 9;
            this.DiametrLabel.Text = "Ring diametr ";
            // 
            // BladeHeightLabel
            // 
            this.BladeHeightLabel.AutoSize = true;
            this.BladeHeightLabel.Location = new System.Drawing.Point(44, 158);
            this.BladeHeightLabel.Name = "BladeHeightLabel";
            this.BladeHeightLabel.Size = new System.Drawing.Size(87, 17);
            this.BladeHeightLabel.TabIndex = 10;
            this.BladeHeightLabel.Text = "Blade height";
            // 
            // WidthLabel
            // 
            this.WidthLabel.AutoSize = true;
            this.WidthLabel.Location = new System.Drawing.Point(44, 257);
            this.WidthLabel.Name = "WidthLabel";
            this.WidthLabel.Size = new System.Drawing.Size(82, 17);
            this.WidthLabel.TabIndex = 11;
            this.WidthLabel.Text = "Chisel width";
            // 
            // CreateButton
            // 
            this.CreateButton.Location = new System.Drawing.Point(106, 309);
            this.CreateButton.Name = "CreateButton";
            this.CreateButton.Size = new System.Drawing.Size(140, 30);
            this.CreateButton.TabIndex = 12;
            this.CreateButton.Text = "Create model";
            this.CreateButton.UseVisualStyleBackColor = true;
            this.CreateButton.Click += new System.EventHandler(this.CreateButton_Click);
            // 
            // ButPanel
            // 
            this.ButPanel.Controls.Add(this.ChiselWidthTextBox);
            this.ButPanel.Controls.Add(this.BladeHeigthTextBox);
            this.ButPanel.Controls.Add(this.RingTextBox);
            this.ButPanel.Controls.Add(this.BladeLengthTextBox);
            this.ButPanel.Controls.Add(this.HangleTextBox);
            this.ButPanel.Controls.Add(this.headLableBut);
            this.ButPanel.Controls.Add(this.BladeLengthLabel);
            this.ButPanel.Controls.Add(this.CreateButton);
            this.ButPanel.Controls.Add(this.WidthLabel);
            this.ButPanel.Controls.Add(this.BladeHeightLabel);
            this.ButPanel.Controls.Add(this.DiametrLabel);
            this.ButPanel.Controls.Add(this.HangleLable);
            this.ButPanel.Location = new System.Drawing.Point(0, 149);
            this.ButPanel.Name = "ButPanel";
            this.ButPanel.Size = new System.Drawing.Size(348, 371);
            this.ButPanel.TabIndex = 14;
            // 
            // ChiselWidthTextBox
            // 
            this.ChiselWidthTextBox.Location = new System.Drawing.Point(199, 255);
            this.ChiselWidthTextBox.Name = "ChiselWidthTextBox";
            this.ChiselWidthTextBox.Size = new System.Drawing.Size(100, 22);
            this.ChiselWidthTextBox.TabIndex = 18;
            this.ChiselWidthTextBox.TextChanged += new System.EventHandler(this.ChiselWidthTextBox_TextChanged);
            this.ChiselWidthTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ChiselWidthTextBox_KeyPress);
            this.ChiselWidthTextBox.Leave += new System.EventHandler(this.ChiselWidthTextBox_Leave);
            // 
            // BladeHeigthTextBox
            // 
            this.BladeHeigthTextBox.Location = new System.Drawing.Point(199, 155);
            this.BladeHeigthTextBox.Name = "BladeHeigthTextBox";
            this.BladeHeigthTextBox.Size = new System.Drawing.Size(100, 22);
            this.BladeHeigthTextBox.TabIndex = 18;
            this.BladeHeigthTextBox.TextChanged += new System.EventHandler(this.BladeHeigthTextBox_TextChanged);
            this.BladeHeigthTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.BladeHeigthTextBox_KeyPress);
            this.BladeHeigthTextBox.Leave += new System.EventHandler(this.BladeHeigthTextBox_Leave);
            // 
            // RingTextBox
            // 
            this.RingTextBox.Location = new System.Drawing.Point(199, 204);
            this.RingTextBox.Name = "RingTextBox";
            this.RingTextBox.Size = new System.Drawing.Size(100, 22);
            this.RingTextBox.TabIndex = 18;
            this.RingTextBox.TextChanged += new System.EventHandler(this.RingTextBox_TextChanged);
            this.RingTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.RingTextBox_KeyPress);
            this.RingTextBox.Leave += new System.EventHandler(this.RingTextBox_Leave);
            // 
            // BladeLengthTextBox
            // 
            this.BladeLengthTextBox.Location = new System.Drawing.Point(199, 105);
            this.BladeLengthTextBox.Name = "BladeLengthTextBox";
            this.BladeLengthTextBox.Size = new System.Drawing.Size(100, 22);
            this.BladeLengthTextBox.TabIndex = 18;
            this.BladeLengthTextBox.TextChanged += new System.EventHandler(this.BladeLengthTextBox_TextChanged);
            this.BladeLengthTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.BladeLengthTextBox_KeyPress);
            this.BladeLengthTextBox.Leave += new System.EventHandler(this.BladeLengthTextBox_Leave);
            // 
            // HangleTextBox
            // 
            this.HangleTextBox.Location = new System.Drawing.Point(199, 54);
            this.HangleTextBox.Name = "HangleTextBox";
            this.HangleTextBox.Size = new System.Drawing.Size(100, 22);
            this.HangleTextBox.TabIndex = 18;
            this.HangleTextBox.TextChanged += new System.EventHandler(this.HangleTextBox_TextChanged);
            this.HangleTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.HangleTextBox_KeyPress);
            this.HangleTextBox.Leave += new System.EventHandler(this.HangleTextBox_Leave);
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
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(345, 143);
            this.panel1.TabIndex = 15;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(342, 503);
            this.Controls.Add(this.ButPanel);
            this.Controls.Add(this.panel1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(360, 550);
            this.MinimumSize = new System.Drawing.Size(360, 550);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chisel creater";
            this.ButPanel.ResumeLayout(false);
            this.ButPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Label HangleLable;
        private System.Windows.Forms.Label BladeLengthLabel;
        private System.Windows.Forms.Label DiametrLabel;
        private System.Windows.Forms.Label BladeHeightLabel;
        private System.Windows.Forms.Label WidthLabel;
        private System.Windows.Forms.Button CreateButton;
        private System.Windows.Forms.Panel ButPanel;
        private System.Windows.Forms.Label headLableBut;
        private System.Windows.Forms.ToolTip toolTipInformation;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox ChiselWidthTextBox;
        private System.Windows.Forms.TextBox BladeHeigthTextBox;
        private System.Windows.Forms.TextBox RingTextBox;
        private System.Windows.Forms.TextBox BladeLengthTextBox;
        private System.Windows.Forms.TextBox HangleTextBox;
    }
}

