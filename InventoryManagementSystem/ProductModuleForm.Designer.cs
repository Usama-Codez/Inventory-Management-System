namespace WindowsFormsApplication1
{
    partial class ProductModuleForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductModuleForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.customerButton6 = new WindowsFormsApplication1.CustomerButton();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnPSave = new System.Windows.Forms.Button();
            this.btnPUpdate = new System.Windows.Forms.Button();
            this.btnPClear = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.ComboCat = new System.Windows.Forms.ComboBox();
            this.txtPDesc = new System.Windows.Forms.TextBox();
            this.txtPPrice = new System.Windows.Forms.TextBox();
            this.txtPQty = new System.Windows.Forms.TextBox();
            this.txtPName = new System.Windows.Forms.TextBox();
            this.txtPid = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.customerButton6)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.customerButton6);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(514, 86);
            this.panel1.TabIndex = 0;
            // 
            // customerButton6
            // 
            this.customerButton6.BackColor = System.Drawing.Color.Transparent;
            this.customerButton6.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("customerButton6.BackgroundImage")));
            this.customerButton6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.customerButton6.ImageHover = ((System.Drawing.Image)(resources.GetObject("customerButton6.ImageHover")));
            this.customerButton6.ImageNormal = ((System.Drawing.Image)(resources.GetObject("customerButton6.ImageNormal")));
            this.customerButton6.Location = new System.Drawing.Point(495, 1);
            this.customerButton6.Name = "customerButton6";
            this.customerButton6.Size = new System.Drawing.Size(19, 20);
            this.customerButton6.TabIndex = 14;
            this.customerButton6.TabStop = false;
            this.customerButton6.Click += new System.EventHandler(this.customerButton6_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(216, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(156, 23);
            this.label3.TabIndex = 1;
            this.label3.Text = "Product Module";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 414);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(514, 17);
            this.panel2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(6, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Created BY Usama Akram";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Navy;
            this.label4.Location = new System.Drawing.Point(23, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 16);
            this.label4.TabIndex = 2;
            this.label4.Text = "Product Name";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Navy;
            this.label5.Location = new System.Drawing.Point(59, 85);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 16);
            this.label5.TabIndex = 3;
            this.label5.Text = "Quantity";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Navy;
            this.label6.Location = new System.Drawing.Point(83, 117);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 16);
            this.label6.TabIndex = 4;
            this.label6.Text = "Price";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Navy;
            this.label2.Location = new System.Drawing.Point(42, 149);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Description";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Navy;
            this.label7.Location = new System.Drawing.Point(53, 181);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 16);
            this.label7.TabIndex = 6;
            this.label7.Text = "Catagory";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnPSave
            // 
            this.btnPSave.BackColor = System.Drawing.Color.Transparent;
            this.btnPSave.FlatAppearance.BorderSize = 0;
            this.btnPSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPSave.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.btnPSave.Location = new System.Drawing.Point(319, 236);
            this.btnPSave.Name = "btnPSave";
            this.btnPSave.Size = new System.Drawing.Size(75, 23);
            this.btnPSave.TabIndex = 12;
            this.btnPSave.Text = "Save";
            this.btnPSave.UseVisualStyleBackColor = false;
            this.btnPSave.Click += new System.EventHandler(this.btnPSave_Click);
            // 
            // btnPUpdate
            // 
            this.btnPUpdate.BackColor = System.Drawing.Color.Transparent;
            this.btnPUpdate.FlatAppearance.BorderSize = 0;
            this.btnPUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPUpdate.ForeColor = System.Drawing.Color.GreenYellow;
            this.btnPUpdate.Location = new System.Drawing.Point(238, 236);
            this.btnPUpdate.Name = "btnPUpdate";
            this.btnPUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnPUpdate.TabIndex = 13;
            this.btnPUpdate.Text = "Update";
            this.btnPUpdate.UseVisualStyleBackColor = false;
            this.btnPUpdate.Click += new System.EventHandler(this.btnPUpdate_Click);
            // 
            // btnPClear
            // 
            this.btnPClear.BackColor = System.Drawing.Color.Transparent;
            this.btnPClear.FlatAppearance.BorderSize = 0;
            this.btnPClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPClear.ForeColor = System.Drawing.Color.Blue;
            this.btnPClear.Location = new System.Drawing.Point(157, 236);
            this.btnPClear.Name = "btnPClear";
            this.btnPClear.Size = new System.Drawing.Size(75, 23);
            this.btnPClear.TabIndex = 14;
            this.btnPClear.Text = "Clear";
            this.btnPClear.UseVisualStyleBackColor = false;
            this.btnPClear.Click += new System.EventHandler(this.btnPClear_Click);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.ComboCat);
            this.panel3.Controls.Add(this.txtPDesc);
            this.panel3.Controls.Add(this.txtPPrice);
            this.panel3.Controls.Add(this.txtPQty);
            this.panel3.Controls.Add(this.txtPName);
            this.panel3.Controls.Add(this.txtPid);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.btnPClear);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.btnPUpdate);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.btnPSave);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Location = new System.Drawing.Point(37, 112);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(435, 275);
            this.panel3.TabIndex = 15;
            // 
            // ComboCat
            // 
            this.ComboCat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboCat.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ComboCat.FormattingEnabled = true;
            this.ComboCat.Location = new System.Drawing.Point(129, 178);
            this.ComboCat.Name = "ComboCat";
            this.ComboCat.Size = new System.Drawing.Size(262, 25);
            this.ComboCat.TabIndex = 22;
            // 
            // txtPDesc
            // 
            this.txtPDesc.Location = new System.Drawing.Point(129, 146);
            this.txtPDesc.Name = "txtPDesc";
            this.txtPDesc.Size = new System.Drawing.Size(262, 23);
            this.txtPDesc.TabIndex = 21;
            // 
            // txtPPrice
            // 
            this.txtPPrice.Location = new System.Drawing.Point(129, 114);
            this.txtPPrice.Name = "txtPPrice";
            this.txtPPrice.Size = new System.Drawing.Size(262, 23);
            this.txtPPrice.TabIndex = 20;
            // 
            // txtPQty
            // 
            this.txtPQty.Location = new System.Drawing.Point(129, 82);
            this.txtPQty.Name = "txtPQty";
            this.txtPQty.Size = new System.Drawing.Size(262, 23);
            this.txtPQty.TabIndex = 19;
            // 
            // txtPName
            // 
            this.txtPName.Location = new System.Drawing.Point(129, 50);
            this.txtPName.Name = "txtPName";
            this.txtPName.Size = new System.Drawing.Size(262, 23);
            this.txtPName.TabIndex = 18;
            // 
            // txtPid
            // 
            this.txtPid.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtPid.Location = new System.Drawing.Point(129, 18);
            this.txtPid.Name = "txtPid";
            this.txtPid.Size = new System.Drawing.Size(262, 23);
            this.txtPid.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Navy;
            this.label8.Location = new System.Drawing.Point(49, 21);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 16);
            this.label8.TabIndex = 16;
            this.label8.Text = "Product Id";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(155, 16);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(55, 50);
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            // 
            // ProductModuleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(514, 431);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ProductModuleForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ProductModuleForm";
            this.Load += new System.EventHandler(this.ProductModuleForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.customerButton6)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel3;
        private CustomerButton customerButton6;
        public System.Windows.Forms.Button btnPSave;
        public System.Windows.Forms.Button btnPUpdate;
        public System.Windows.Forms.Button btnPClear;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.ComboBox ComboCat;
        public System.Windows.Forms.TextBox txtPDesc;
        public System.Windows.Forms.TextBox txtPPrice;
        public System.Windows.Forms.TextBox txtPQty;
        public System.Windows.Forms.TextBox txtPName;
        public System.Windows.Forms.TextBox txtPid;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}