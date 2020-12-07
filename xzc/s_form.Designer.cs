namespace xzc
{
    partial class s_form
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
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnLook = new System.Windows.Forms.Button();
            this.txtLKWord = new System.Windows.Forms.TextBox();
            this.s_label1 = new System.Windows.Forms.Label();
            this.cboxLCondition = new System.Windows.Forms.ComboBox();
            this.dbaseBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.xzcDataSet = new xzc.xzcDataSet();
            this.d_baseTableAdapter = new xzc.xzcDataSetTableAdapters.d_baseTableAdapter();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbaseBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xzcDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(434, 25);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(247, 334);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(789, 269);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(107, 49);
            this.button1.TabIndex = 1;
            this.button1.Text = "获取数据";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(789, 324);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(107, 49);
            this.button2.TabIndex = 1;
            this.button2.Text = "退出";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnLook
            // 
            this.btnLook.Location = new System.Drawing.Point(264, 278);
            this.btnLook.Name = "btnLook";
            this.btnLook.Size = new System.Drawing.Size(62, 40);
            this.btnLook.TabIndex = 1;
            this.btnLook.Text = "查询";
            this.btnLook.UseVisualStyleBackColor = true;
            this.btnLook.Click += new System.EventHandler(this.btnLook_Click);
            // 
            // txtLKWord
            // 
            this.txtLKWord.Font = new System.Drawing.Font("SimSun", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtLKWord.Location = new System.Drawing.Point(88, 289);
            this.txtLKWord.Name = "txtLKWord";
            this.txtLKWord.Size = new System.Drawing.Size(157, 29);
            this.txtLKWord.TabIndex = 2;
            // 
            // s_label1
            // 
            this.s_label1.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.s_label1.Location = new System.Drawing.Point(29, 296);
            this.s_label1.Name = "s_label1";
            this.s_label1.Size = new System.Drawing.Size(53, 20);
            this.s_label1.TabIndex = 3;
            this.s_label1.Text = "关键字";
            // 
            // cboxLCondition
            // 
            this.cboxLCondition.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.dbaseBindingSource, "NumbID", true));
            this.cboxLCondition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxLCondition.FormattingEnabled = true;
            this.cboxLCondition.Items.AddRange(new object[] {
            "工号",
            "姓名"});
            this.cboxLCondition.Location = new System.Drawing.Point(62, 339);
            this.cboxLCondition.Name = "cboxLCondition";
            this.cboxLCondition.Size = new System.Drawing.Size(183, 20);
            this.cboxLCondition.TabIndex = 4;
            // 
            // dbaseBindingSource
            // 
            this.dbaseBindingSource.DataMember = "d_base";
            this.dbaseBindingSource.DataSource = this.xzcDataSet;
            // 
            // xzcDataSet
            // 
            this.xzcDataSet.DataSetName = "xzcDataSet";
            this.xzcDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // d_baseTableAdapter
            // 
            this.d_baseTableAdapter.ClearBeforeFill = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(67, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 25);
            this.label1.TabIndex = 5;
            this.label1.Text = "ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(200, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 25);
            this.label2.TabIndex = 6;
            this.label2.Text = "Name";
            // 
            // s_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(924, 390);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboxLCondition);
            this.Controls.Add(this.s_label1);
            this.Controls.Add(this.txtLKWord);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnLook);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "s_form";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbaseBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xzcDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnLook;
        private System.Windows.Forms.TextBox txtLKWord;
        private System.Windows.Forms.Label s_label1;
        private System.Windows.Forms.ComboBox cboxLCondition;
        private xzcDataSet xzcDataSet;
        private System.Windows.Forms.BindingSource dbaseBindingSource;
        private xzcDataSetTableAdapters.d_baseTableAdapter d_baseTableAdapter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

