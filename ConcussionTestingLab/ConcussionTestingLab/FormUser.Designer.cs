namespace ConcussionTestingLab
{
    partial class FormUser
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
            this.lblUserName = new System.Windows.Forms.Label();
            this.btnMemoryTest = new System.Windows.Forms.Button();
            this.btnReactionTest = new System.Windows.Forms.Button();
            this.btnConcentration = new System.Windows.Forms.Button();
            this.btnAnalysis = new System.Windows.Forms.Button();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.rtbResults = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserName.Location = new System.Drawing.Point(12, 9);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(230, 46);
            this.lblUserName.TabIndex = 0;
            this.lblUserName.Text = "User Name";
            // 
            // btnMemoryTest
            // 
            this.btnMemoryTest.AutoSize = true;
            this.btnMemoryTest.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMemoryTest.Location = new System.Drawing.Point(20, 200);
            this.btnMemoryTest.Name = "btnMemoryTest";
            this.btnMemoryTest.Size = new System.Drawing.Size(202, 30);
            this.btnMemoryTest.TabIndex = 1;
            this.btnMemoryTest.Text = "Take Word Test";
            this.btnMemoryTest.UseVisualStyleBackColor = true;
            this.btnMemoryTest.Click += new System.EventHandler(this.btnMemoryTest_Click);
            // 
            // btnReactionTest
            // 
            this.btnReactionTest.AutoSize = true;
            this.btnReactionTest.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReactionTest.Location = new System.Drawing.Point(20, 253);
            this.btnReactionTest.Name = "btnReactionTest";
            this.btnReactionTest.Size = new System.Drawing.Size(202, 30);
            this.btnReactionTest.TabIndex = 2;
            this.btnReactionTest.Text = "Take Reaction Test";
            this.btnReactionTest.UseVisualStyleBackColor = true;
            this.btnReactionTest.Click += new System.EventHandler(this.btnReactionTest_Click);
            // 
            // btnConcentration
            // 
            this.btnConcentration.AutoSize = true;
            this.btnConcentration.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConcentration.Location = new System.Drawing.Point(20, 308);
            this.btnConcentration.Name = "btnConcentration";
            this.btnConcentration.Size = new System.Drawing.Size(202, 30);
            this.btnConcentration.TabIndex = 3;
            this.btnConcentration.Text = "Take Concentration Test";
            this.btnConcentration.UseVisualStyleBackColor = true;
            this.btnConcentration.Click += new System.EventHandler(this.btnConcentration_Click);
            // 
            // btnAnalysis
            // 
            this.btnAnalysis.AutoSize = true;
            this.btnAnalysis.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnalysis.Location = new System.Drawing.Point(20, 435);
            this.btnAnalysis.Name = "btnAnalysis";
            this.btnAnalysis.Size = new System.Drawing.Size(82, 30);
            this.btnAnalysis.TabIndex = 4;
            this.btnAnalysis.Text = "Analysis";
            this.btnAnalysis.UseVisualStyleBackColor = true;
            this.btnAnalysis.Click += new System.EventHandler(this.btnAnalysis_Click);
            // 
            // btnSubmit
            // 
            this.btnSubmit.AutoSize = true;
            this.btnSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.Location = new System.Drawing.Point(706, 435);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(82, 30);
            this.btnSubmit.TabIndex = 5;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // rtbResults
            // 
            this.rtbResults.Location = new System.Drawing.Point(556, 87);
            this.rtbResults.Name = "rtbResults";
            this.rtbResults.Size = new System.Drawing.Size(232, 324);
            this.rtbResults.TabIndex = 6;
            this.rtbResults.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(384, 24);
            this.label1.TabIndex = 7;
            this.label1.Text = "Please click on the buttons below to take the ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(20, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(398, 24);
            this.label2.TabIndex = 8;
            this.label2.Text = "corresponding test. Click the Analysis button to";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(20, 135);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(378, 24);
            this.label3.TabIndex = 9;
            this.label3.Text = "compare tests. Click Submit to Exit Program.";
            // 
            // FormUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 484);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rtbResults);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.btnAnalysis);
            this.Controls.Add(this.btnConcentration);
            this.Controls.Add(this.btnReactionTest);
            this.Controls.Add(this.btnMemoryTest);
            this.Controls.Add(this.lblUserName);
            this.Name = "FormUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmUser";
            this.Load += new System.EventHandler(this.frmUser_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Button btnMemoryTest;
        private System.Windows.Forms.Button btnReactionTest;
        private System.Windows.Forms.Button btnConcentration;
        private System.Windows.Forms.Button btnAnalysis;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.RichTextBox rtbResults;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}