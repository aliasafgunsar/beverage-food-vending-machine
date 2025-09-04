using Microsoft.Extensions.DependencyInjection;
using VendingMachine.Core.Enums;
using VendingMachine.Core.Extensions;
using VendingMachine.Core.Interfaces;
using VendingMachine.Core.Models;
using VendingMachine.Infrastructure;

namespace VendingMachine.WindowsUI
{
    public partial class Form1 : Form
    {
        private readonly IVendingMachineService _vendingMachineService;
        private Product? _selectedProduct;
        private Order? _currentOrder;

        public Form1()
        {
            InitializeComponent();

            // Event baðlantýlarý
            dataGridViewProducts.SelectionChanged += dataGridViewProducts_SelectionChanged;
            buttonPay.Click += buttonPay_Click;

            // Dependency Injection setup - Basit versiyon
            var productRepository = new VendingMachine.Infrastructure.Repositories.ProductRepository();
            var paymentService = new VendingMachine.Infrastructure.Services.PaymentService();
            _vendingMachineService = new VendingMachine.Infrastructure.Services.VendingMachineService(
                productRepository, paymentService);

            InitializeForm();
        }

        private void InitializeForm()
        {
            // Load products
            LoadProducts();

            // Setup payment methods combo box
            var paymentMethods = Enum.GetValues(typeof(PaymentMethod))
    .Cast<PaymentMethod>()
    .Select(p => new
    {
        Value = p,
        DisplayText = p.GetDescription()
    })
    .ToList();

            comboBoxPaymentMethods.DataSource = paymentMethods;
            comboBoxPaymentMethods.DisplayMember = "DisplayText";
            comboBoxPaymentMethods.ValueMember = "Value";

            // Hide sugar controls initially
            labelSugar.Visible = false;
            numericUpDownSugar.Visible = false;

            // Set default quantity
            numericUpDownQuantity.Value = 1;
            numericUpDownQuantity.Minimum = 1;
            numericUpDownQuantity.Maximum = 10;

            // Set sugar options
            numericUpDownSugar.Minimum = 0;
            numericUpDownSugar.Maximum = 3;
            numericUpDownSugar.Value = 0;

            // Set initial selection text
            labelSelectedProduct.Text = "Selected: None";
        }

        private void LoadProducts()
        {
            var products = _vendingMachineService.GetAvailableProducts();
            dataGridViewProducts.DataSource = products.Select(p => new
            {
                p.Id,
                p.Name,
                p.Price,
                p.Stock,
                p.Type,
                IsHotDrink = p.IsHotDrink ? "Evet" : "Hayýr"
            }).ToList();

            dataGridViewProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Ýlk ürünü otomatik seç
            if (dataGridViewProducts.Rows.Count > 0)
            {
                dataGridViewProducts.Rows[0].Selected = true;
            }
        }

        private void dataGridViewProducts_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewProducts.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridViewProducts.SelectedRows[0];
                int productId = (int)selectedRow.Cells["Id"].Value;

                _selectedProduct = _vendingMachineService.GetAvailableProducts()
                    .FirstOrDefault(p => p.Id == productId);

                UpdateProductSelection();
            }
        }

        private void UpdateProductSelection()
        {
            if (_selectedProduct != null)
            {
                labelSelectedProduct.Text = $"Seçilen Ürün: {_selectedProduct.Name} - {_selectedProduct.Price:C}";

                // Sekerli içeçek görüntüleme
                bool showSugar = _selectedProduct.IsHotDrink;
                labelSugar.Visible = showSugar;
                numericUpDownSugar.Visible = showSugar;
                lblSugar.Visible = showSugar;
                numericUpDownSugar.Visible = showSugar;
            }
        }

        private void buttonSelectProduct_Click(object sender, EventArgs e)
        {
            // Manuel seçim kontrolü - eðer hala nullsa
            if (_selectedProduct == null && dataGridViewProducts.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridViewProducts.SelectedRows[0];
                int productId = (int)selectedRow.Cells["Id"].Value;
                _selectedProduct = _vendingMachineService.GetAvailableProducts()
                    .FirstOrDefault(p => p.Id == productId);
            }

            if (_selectedProduct == null)
            {
                MessageBox.Show("Lütfen Önce bir ürün seçiniz!");
                return;
            }

            try
            {
                int quantity = (int)numericUpDownQuantity.Value;
                SugarAmount sugarAmount = _selectedProduct.IsHotDrink ?
                    (SugarAmount)numericUpDownSugar.Value : SugarAmount.None;

                // Order oluþtur
                _currentOrder = _vendingMachineService.CreateOrder(
                    _selectedProduct.Id, quantity, sugarAmount);

                // Ürün hazýrlama mesajý
                string preparationMessage = _vendingMachineService.PrepareProduct(_currentOrder);
                MessageBox.Show($"{preparationMessage}\nToplam: {_currentOrder.TotalAmount:C}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
        private void buttonPay_Click(object sender, EventArgs e)
        {
            if (_currentOrder == null)
            {
                MessageBox.Show("Lütfen Önce bir ürün seçiniz!.");
                return;
            }

            if (comboBoxPaymentMethods.SelectedItem == null)
            {
                MessageBox.Show("Lütfen bir ödeme tipi seçiniz!.");
                return;
            }

            try
            {
                //Anonymous type'dan Value property'sini al
                var selectedItem = comboBoxPaymentMethods.SelectedItem;
                var paymentMethod = (PaymentMethod)selectedItem.GetType().GetProperty("Value").GetValue(selectedItem);

                decimal amountPaid = 0;

                // Ödeme yöntemi kontrolü 
                if (paymentMethod == PaymentMethod.CashCoin || paymentMethod == PaymentMethod.CashPaper)
                {
                    // For cash payments, ask for amount paid
                    string input = Microsoft.VisualBasic.Interaction.InputBox(
                        $"Ödenen tutarý girin (Toplam: {_currentOrder.TotalAmount:C}):",
                        "Ödeme Tutarý",
                        _currentOrder.TotalAmount.ToString());

                    if (!decimal.TryParse(input, out amountPaid) || amountPaid < _currentOrder.TotalAmount)
                    {
                        MessageBox.Show("Geçersiz tutar veya yetersiz ödeme.");
                        return;
                    }
                }
                else
                {
                    // For card payments, amount paid equals total
                    amountPaid = _currentOrder.TotalAmount;
                }

                // Process payment
                var receipt = _vendingMachineService.ProcessPayment(_currentOrder, paymentMethod, amountPaid);

                // Show receipt
                textBoxReceipt.Text = receipt.ToString();

                MessageBox.Show("Ödeme Baþarýlý! Fiþiniz Oluþturuldu.");

                // Reset for next order
                _currentOrder = null;
                _selectedProduct = null;
                LoadProducts();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ödeme Baþarýsýz: {ex.Message}");
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            _currentOrder = null;
            _selectedProduct = null;
            textBoxReceipt.Clear();
            MessageBox.Show("Sipariþ iptal edildi.");
        }
    }
}