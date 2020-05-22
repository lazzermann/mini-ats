using mini_ats.Telephone_Line;
namespace mini_ats
{
    partial class authorization_form
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

            //telephone.safe(test.path, test.data.phones);
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.authorizate_text_box = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.autho_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // authorizate_text_box
            // 
            this.authorizate_text_box.Location = new System.Drawing.Point(27, 53);
            this.authorizate_text_box.Name = "authorizate_text_box";
            this.authorizate_text_box.Size = new System.Drawing.Size(210, 22);
            this.authorizate_text_box.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Input number here :";
            // 
            // autho_button
            // 
            this.autho_button.Location = new System.Drawing.Point(27, 97);
            this.autho_button.Name = "autho_button";
            this.autho_button.Size = new System.Drawing.Size(95, 23);
            this.autho_button.TabIndex = 2;
            this.autho_button.Text = "Authorizate";
            this.autho_button.UseVisualStyleBackColor = true;
            this.autho_button.Click += new System.EventHandler(this.autho_button_Click);
            // 
            // authorization_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 132);
            this.Controls.Add(this.autho_button);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.authorizate_text_box);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "authorization_form";
            this.Text = "Authorization";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.authorization_form_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox authorizate_text_box;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button autho_button;
    }
}

