namespace VendingMachine.WindowsUI
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
            dataGridViewProducts = new DataGridView();
            comboBoxPaymentMethods = new ComboBox();
            numericUpDownQuantity = new NumericUpDown();
            buttonSelectProduct = new Button();
            labelSelectedProduct = new Label();
            textBoxReceipt = new TextBox();
            numericUpDownSugar = new NumericUpDown();
            labelSugar = new Label();
            buttonPay = new Button();
            buttonCancel = new Button();
            label1 = new Label();
            label2 = new Label();
            lblSugar = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewProducts).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownQuantity).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownSugar).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewProducts
            // 
            dataGridViewProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewProducts.Location = new Point(92, 38);
            dataGridViewProducts.Name = "dataGridViewProducts";
            dataGridViewProducts.Size = new Size(876, 428);
            dataGridViewProducts.TabIndex = 0;
            // 
            // comboBoxPaymentMethods
            // 
            comboBoxPaymentMethods.FormattingEnabled = true;
            comboBoxPaymentMethods.Location = new Point(123, 506);
            comboBoxPaymentMethods.Name = "comboBoxPaymentMethods";
            comboBoxPaymentMethods.Size = new Size(121, 23);
            comboBoxPaymentMethods.TabIndex = 1;
            // 
            // numericUpDownQuantity
            // 
            numericUpDownQuantity.Location = new Point(304, 507);
            numericUpDownQuantity.Name = "numericUpDownQuantity";
            numericUpDownQuantity.Size = new Size(120, 23);
            numericUpDownQuantity.TabIndex = 2;
            // 
            // buttonSelectProduct
            // 
            buttonSelectProduct.Location = new Point(302, 567);
            buttonSelectProduct.Name = "buttonSelectProduct";
            buttonSelectProduct.Size = new Size(93, 36);
            buttonSelectProduct.TabIndex = 3;
            buttonSelectProduct.Text = "Ürün seç";
            buttonSelectProduct.UseVisualStyleBackColor = true;
            buttonSelectProduct.Click += buttonSelectProduct_Click;
            // 
            // labelSelectedProduct
            // 
            labelSelectedProduct.AutoSize = true;
            labelSelectedProduct.Location = new Point(302, 636);
            labelSelectedProduct.Name = "labelSelectedProduct";
            labelSelectedProduct.Size = new Size(83, 15);
            labelSelectedProduct.TabIndex = 4;
            labelSelectedProduct.Text = "Select Product";
            // 
            // textBoxReceipt
            // 
            textBoxReceipt.Location = new Point(304, 699);
            textBoxReceipt.Multiline = true;
            textBoxReceipt.Name = "textBoxReceipt";
            textBoxReceipt.Size = new Size(517, 40);
            textBoxReceipt.TabIndex = 5;
            // 
            // numericUpDownSugar
            // 
            numericUpDownSugar.Location = new Point(481, 506);
            numericUpDownSugar.Name = "numericUpDownSugar";
            numericUpDownSugar.Size = new Size(120, 23);
            numericUpDownSugar.TabIndex = 2;
            // 
            // labelSugar
            // 
            labelSugar.AutoSize = true;
            labelSugar.ForeColor = Color.SeaGreen;
            labelSugar.Location = new Point(304, 671);
            labelSugar.Name = "labelSugar";
            labelSugar.Size = new Size(200, 15);
            labelSugar.TabIndex = 4;
            labelSugar.Text = "Şekerli Ürün Siparişiniz Hazırlanıyor...";
            // 
            // buttonPay
            // 
            buttonPay.Location = new Point(419, 567);
            buttonPay.Name = "buttonPay";
            buttonPay.Size = new Size(114, 36);
            buttonPay.TabIndex = 3;
            buttonPay.Text = "Ödeme yap";
            buttonPay.UseVisualStyleBackColor = true;
            buttonPay.Click += buttonPay_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(565, 567);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(94, 36);
            buttonCancel.TabIndex = 3;
            buttonCancel.Text = "İptal";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(122, 484);
            label1.Name = "label1";
            label1.Size = new Size(104, 15);
            label1.TabIndex = 6;
            label1.Text = "Ödeme tipi seçiniz";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(302, 484);
            label2.Name = "label2";
            label2.Size = new Size(67, 15);
            label2.TabIndex = 6;
            label2.Text = "Adet giriniz";
            // 
            // lblSugar
            // 
            lblSugar.AutoSize = true;
            lblSugar.Location = new Point(481, 484);
            lblSugar.Name = "lblSugar";
            lblSugar.Size = new Size(110, 15);
            lblSugar.TabIndex = 6;
            lblSugar.Text = "Şeker miktarı giriniz";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1019, 762);
            Controls.Add(lblSugar);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBoxReceipt);
            Controls.Add(labelSugar);
            Controls.Add(labelSelectedProduct);
            Controls.Add(buttonCancel);
            Controls.Add(buttonPay);
            Controls.Add(buttonSelectProduct);
            Controls.Add(numericUpDownSugar);
            Controls.Add(numericUpDownQuantity);
            Controls.Add(comboBoxPaymentMethods);
            Controls.Add(dataGridViewProducts);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridViewProducts).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownQuantity).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownSugar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridViewProducts;
        private ComboBox comboBoxPaymentMethods;
        private NumericUpDown numericUpDownQuantity;
        private Button buttonSelectProduct;
        private Label labelSelectedProduct;
        private TextBox textBoxReceipt;
        private NumericUpDown numericUpDownSugar;
        private Label labelSugar;
        private Button buttonPay;
        private Button buttonCancel;
        private Label label1;
        private Label label2;
        private Label lblSugar;
    }
}
