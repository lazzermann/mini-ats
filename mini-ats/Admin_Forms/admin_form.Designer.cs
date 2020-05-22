namespace mini_ats.Admin_Forms
{
    partial class admin_form
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
            this.label1 = new System.Windows.Forms.Label();
            this.add_button = new System.Windows.Forms.Button();
            this.delete_button = new System.Windows.Forms.Button();
            this.change_button = new System.Windows.Forms.Button();
            this.refresh_button = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.phones_view = new System.Windows.Forms.DataGridView();
            this.session_view = new System.Windows.Forms.DataGridView();
            this.Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.first_number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.second_number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.autho_button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.phones_view)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.session_view)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Phones";
            // 
            // add_button
            // 
            this.add_button.Location = new System.Drawing.Point(37, 403);
            this.add_button.Name = "add_button";
            this.add_button.Size = new System.Drawing.Size(97, 23);
            this.add_button.TabIndex = 2;
            this.add_button.Text = "Add phone";
            this.add_button.UseVisualStyleBackColor = true;
            this.add_button.Click += new System.EventHandler(this.add_button_Click);
            // 
            // delete_button
            // 
            this.delete_button.Location = new System.Drawing.Point(152, 403);
            this.delete_button.Name = "delete_button";
            this.delete_button.Size = new System.Drawing.Size(107, 23);
            this.delete_button.TabIndex = 3;
            this.delete_button.Text = "Delete phone";
            this.delete_button.UseVisualStyleBackColor = true;
            this.delete_button.Click += new System.EventHandler(this.delete_button_Click);
            // 
            // change_button
            // 
            this.change_button.Location = new System.Drawing.Point(283, 403);
            this.change_button.Name = "change_button";
            this.change_button.Size = new System.Drawing.Size(125, 23);
            this.change_button.TabIndex = 5;
            this.change_button.Text = "Change number";
            this.change_button.UseVisualStyleBackColor = true;
            this.change_button.Click += new System.EventHandler(this.change_button_Click);
            // 
            // refresh_button
            // 
            this.refresh_button.Location = new System.Drawing.Point(432, 403);
            this.refresh_button.Name = "refresh_button";
            this.refresh_button.Size = new System.Drawing.Size(75, 23);
            this.refresh_button.TabIndex = 6;
            this.refresh_button.Text = "Refresh";
            this.refresh_button.UseVisualStyleBackColor = true;
            this.refresh_button.Click += new System.EventHandler(this.refresh_button_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(291, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "Sessions";
            // 
            // phones_view
            // 
            this.phones_view.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.phones_view.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Number});
            this.phones_view.Location = new System.Drawing.Point(37, 55);
            this.phones_view.Name = "phones_view";
            this.phones_view.RowHeadersWidth = 51;
            this.phones_view.RowTemplate.Height = 24;
            this.phones_view.Size = new System.Drawing.Size(237, 315);
            this.phones_view.TabIndex = 8;
            // 
            // session_view
            // 
            this.session_view.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.session_view.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.first_number,
            this.second_number});
            this.session_view.Location = new System.Drawing.Point(294, 55);
            this.session_view.Name = "session_view";
            this.session_view.RowHeadersWidth = 51;
            this.session_view.RowTemplate.Height = 24;
            this.session_view.Size = new System.Drawing.Size(405, 315);
            this.session_view.TabIndex = 9;
            // 
            // Number
            // 
            this.Number.HeaderText = "Numbers";
            this.Number.MinimumWidth = 6;
            this.Number.Name = "Number";
            this.Number.Width = 125;
            // 
            // first_number
            // 
            this.first_number.HeaderText = "First number";
            this.first_number.MinimumWidth = 6;
            this.first_number.Name = "first_number";
            this.first_number.Width = 125;
            // 
            // second_number
            // 
            this.second_number.HeaderText = "Second number";
            this.second_number.MinimumWidth = 6;
            this.second_number.Name = "second_number";
            this.second_number.Width = 125;
            // 
            // autho_button
            // 
            this.autho_button.Location = new System.Drawing.Point(551, 403);
            this.autho_button.Name = "autho_button";
            this.autho_button.Size = new System.Drawing.Size(95, 23);
            this.autho_button.TabIndex = 10;
            this.autho_button.Text = "Authorizate";
            this.autho_button.UseVisualStyleBackColor = true;
            this.autho_button.Click += new System.EventHandler(this.autho_button_Click);
            // 
            // admin_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(722, 450);
            this.Controls.Add(this.autho_button);
            this.Controls.Add(this.session_view);
            this.Controls.Add(this.phones_view);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.refresh_button);
            this.Controls.Add(this.change_button);
            this.Controls.Add(this.delete_button);
            this.Controls.Add(this.add_button);
            this.Controls.Add(this.label1);
            this.Name = "admin_form";
            this.Text = "admin_form";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.admin_form_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.phones_view)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.session_view)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button add_button;
        private System.Windows.Forms.Button delete_button;
        private System.Windows.Forms.Button change_button;
        private System.Windows.Forms.Button refresh_button;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.DataGridView phones_view;
        public System.Windows.Forms.DataGridView session_view;
        private System.Windows.Forms.DataGridViewTextBoxColumn Number;
        private System.Windows.Forms.DataGridViewTextBoxColumn first_number;
        private System.Windows.Forms.DataGridViewTextBoxColumn second_number;
        private System.Windows.Forms.Button autho_button;
    }
}