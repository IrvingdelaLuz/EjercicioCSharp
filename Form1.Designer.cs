
namespace WindowsFormsApp1
{
    partial class formNumero
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
            this.labelNum = new System.Windows.Forms.Label();
            this.numRegister = new System.Windows.Forms.NumericUpDown();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnResult = new System.Windows.Forms.Button();
            this.labelResult = new System.Windows.Forms.Label();
            this.txtResult = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numRegister)).BeginInit();
            this.SuspendLayout();
            // 
            // labelNum
            // 
            this.labelNum.AutoSize = true;
            this.labelNum.Location = new System.Drawing.Point(12, 43);
            this.labelNum.Name = "labelNum";
            this.labelNum.Size = new System.Drawing.Size(93, 13);
            this.labelNum.TabIndex = 0;
            this.labelNum.Text = "Numero a ingresar";
            // 
            // numRegister
            // 
            this.numRegister.Location = new System.Drawing.Point(111, 41);
            this.numRegister.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.numRegister.Name = "numRegister";
            this.numRegister.Size = new System.Drawing.Size(120, 20);
            this.numRegister.TabIndex = 1;
            this.numRegister.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(237, 41);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Agregar";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnResult
            // 
            this.btnResult.Location = new System.Drawing.Point(318, 41);
            this.btnResult.Name = "btnResult";
            this.btnResult.Size = new System.Drawing.Size(75, 23);
            this.btnResult.TabIndex = 3;
            this.btnResult.Text = "Resultado";
            this.btnResult.UseVisualStyleBackColor = true;
            this.btnResult.Click += new System.EventHandler(this.btnResult_Click);
            // 
            // labelResult
            // 
            this.labelResult.AutoSize = true;
            this.labelResult.Location = new System.Drawing.Point(15, 109);
            this.labelResult.Name = "labelResult";
            this.labelResult.Size = new System.Drawing.Size(96, 13);
            this.labelResult.TabIndex = 4;
            this.labelResult.Text = "Numero q se repite";
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(118, 109);
            this.txtResult.Name = "txtResult";
            this.txtResult.ReadOnly = true;
            this.txtResult.Size = new System.Drawing.Size(194, 20);
            this.txtResult.TabIndex = 5;
            // 
            // formNumero
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 303);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.labelResult);
            this.Controls.Add(this.btnResult);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.numRegister);
            this.Controls.Add(this.labelNum);
            this.Name = "formNumero";
            this.Text = "Numero Repetido";
            ((System.ComponentModel.ISupportInitialize)(this.numRegister)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelNum;
        private System.Windows.Forms.NumericUpDown numRegister;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnResult;
        private System.Windows.Forms.Label labelResult;
        private System.Windows.Forms.TextBox txtResult;
    }
}

