namespace ProjecteMarioM2M4
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            textBox1 = new TextBox();
            label1 = new Label();
            openFileDialog = new OpenFileDialog();
            button1 = new Button();
            SuspendLayout();
            //
            // textBox1
            //
            textBox1.Location = new System.Drawing.Point(25, 57);
            textBox1.Name = "textBox1";
            textBox1.Size = new System.Drawing.Size(470, 27);
            textBox1.TabIndex = 0;
            textBox1.TextChanged += new System.EventHandler(textBox1_TextChanged);
            //
            // label1
            //
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(25, 24);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(81, 20);
            label1.TabIndex = 1;
            label1.Text = "XML Parser";
            //
            // openFileDialog
            //
            openFileDialog.FileName = "openFileDialog";
            //
            // button1
            //
            button1.Location = new System.Drawing.Point(25, 108);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(101, 31);
            button1.TabIndex = 2;
            button1.Text = "Load";
            button1.UseVisualStyleBackColor = true;
            button1.Click += new System.EventHandler(onClick);
            //
            // Form1
            //
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(575, 167);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Name = "Form1";
            Text = "Form1";
            Load += new System.EventHandler(Form1_Load);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private Label label1;
        private OpenFileDialog openFileDialog;
        private Button button1;
    }
}