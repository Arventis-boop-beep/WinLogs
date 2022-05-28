
namespace WInLogsViewer
{
    partial class Form1
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
            this.msgTextBox = new System.Windows.Forms.RichTextBox();
            this.table = new System.Windows.Forms.ListView();
            this.Date = new System.Windows.Forms.ColumnHeader();
            this.Type = new System.Windows.Forms.ColumnHeader();
            this.Creator = new System.Windows.Forms.ColumnHeader();
            this.Category = new System.Windows.Forms.ColumnHeader();
            this.explorer = new System.Windows.Forms.ListView();
            this.Log = new System.Windows.Forms.ColumnHeader();
            this.Amount = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // msgTextBox
            // 
            this.msgTextBox.Location = new System.Drawing.Point(430, 541);
            this.msgTextBox.Name = "msgTextBox";
            this.msgTextBox.Size = new System.Drawing.Size(853, 165);
            this.msgTextBox.TabIndex = 1;
            this.msgTextBox.Text = "";
            // 
            // table
            // 
            this.table.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Date,
            this.Type,
            this.Creator,
            this.Category});
            this.table.FullRowSelect = true;
            this.table.GridLines = true;
            this.table.HideSelection = false;
            this.table.Location = new System.Drawing.Point(430, 3);
            this.table.MultiSelect = false;
            this.table.Name = "table";
            this.table.Size = new System.Drawing.Size(862, 532);
            this.table.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.table.TabIndex = 2;
            this.table.UseCompatibleStateImageBehavior = false;
            this.table.View = System.Windows.Forms.View.Details;
            this.table.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.filterLog);
            this.table.MouseClick += new System.Windows.Forms.MouseEventHandler(this.showMessage);
            // 
            // Date
            // 
            this.Date.Text = "Дата";
            // 
            // Type
            // 
            this.Type.Text = "Тип";
            // 
            // Creator
            // 
            this.Creator.Text = "Создатель";
            // 
            // Category
            // 
            this.Category.Text = "Категория";
            // 
            // explorer
            // 
            this.explorer.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Log,
            this.Amount});
            this.explorer.FullRowSelect = true;
            this.explorer.GridLines = true;
            this.explorer.HideSelection = false;
            this.explorer.Location = new System.Drawing.Point(3, 3);
            this.explorer.MultiSelect = false;
            this.explorer.Name = "explorer";
            this.explorer.Size = new System.Drawing.Size(421, 703);
            this.explorer.TabIndex = 3;
            this.explorer.UseCompatibleStateImageBehavior = false;
            this.explorer.View = System.Windows.Forms.View.Details;
            this.explorer.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.chooseLog);
            // 
            // Log
            // 
            this.Log.Text = "Лог";
            // 
            // Amount
            // 
            this.Amount.Text = "Количество";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 718);
            this.Controls.Add(this.explorer);
            this.Controls.Add(this.table);
            this.Controls.Add(this.msgTextBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.RichTextBox msgTextBox;
        private System.Windows.Forms.ListView table;
        private System.Windows.Forms.ColumnHeader Date;
        private System.Windows.Forms.ColumnHeader Type;
        private System.Windows.Forms.ColumnHeader Creator;
        private System.Windows.Forms.ColumnHeader Category;
        private System.Windows.Forms.ListView explorer;
        private System.Windows.Forms.ColumnHeader Log;
        private System.Windows.Forms.ColumnHeader Amount;
    }
}

