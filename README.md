📋 Proje Özeti
Bu proje, 20 yiyecek ve 10 içecek ürün yuvasına sahip, kredi kartı (temaslı/temassız) ve nakit (kağıt/madeni para) ödeme yöntemlerini destekleyen bir otomat simülasyonudur. Sıcak içecekler için şeker miktarı seçeneği sunar.

🏗️ Proje Mimarisi
text
VendingMachine/
├── Core/
│   ├── Enums/
│   │   ├── PaymentMethod.cs
│   │   ├── ProductType.cs
│   │   └── SugarAmount.cs
│   ├── Extensions/
│   │   └── EnumExtensions.cs
│   ├── Interfaces/
│   │   ├── IPaymentService.cs
│   │   ├── IProduct.cs
│   │   ├── IProductRepository.cs
│   │   └── IVendingMachineService.cs
│   └── Models/
│       ├── Order.cs
│       ├── Product.cs
│       └── Receipt.cs
├── Infrastructure/
│   ├── Repositories/
│   │   └── ProductRepository.cs
│   └── Services/
│       ├── PaymentService.cs
│       └── VendingMachineService.cs
├── Tests/
│   ├── Repositories/
│   │   └── ProductRepository.Tests.cs
│   └── Services/
│       └── VendingMachineService.Tests.cs
└── WindowsUI/
    ├── Form1.cs
    ├── Form1.Designer.cs
    └── Program.cs
🚀 Kurulum Talimatları
Gereksinimler
.NET 6.0 veya üzeri

Visual Studio 2022 veya VS Code

Projeyi Çalıştırma
Projeyi klonlayın:

bash
git clone https://github.com/kullanici-adi/vending-machine.git
cd vending-machine
Solution'ı açın:

bash
dotnet build
Windows UI projesini çalıştırın:

bash
cd VendingMachine.WindowsUI
dotnet run
🧩 Kullanılan Teknolojiler
.NET 6.0 - Ana framework

Windows Forms - Kullanıcı arayüzü

MSTest - Unit testler

SOLID Principles - Yazılım tasarım prensipleri

Dependency Injection - Bağımlılık yönetimi

✨ Özellikler
✅ 20 yiyecek + 10 içecek ürün yuvası

✅ Miktar seçimi (1-10 adet)

✅ Sıcak içecekler için şeker miktarı seçeneği (Şekersiz, Az, Orta, Çok)

✅ Çoklu ödeme yöntemleri:

Temaslı Kredi Kartı

Temassız Kredi Kartı

Nakit (Kağıt Para)

Nakit (Madeni Para)

✅ Detaylı fiş bilgisi (ürün adı, numara, ödeme yöntemi, para üstü)

✅ Türkçe ve kullanıcı dostu arayüz

🧪 Test Kapsamı
Proje, %70'ten fazla test kapsamına sahiptir:

bash
cd VendingMachine.Tests
dotnet test
Testler aşağıdaki senaryoları kapsar:

Ürün repository testleri

Ödeme servisi testleri

Otomat servisi testleri

Stok kontrolü testleri

Sipariş oluşturma testleri

📸 Ekran Görüntüleri
(Bu kısmı projeyi çalıştırdıktan sonra ekran görüntüleriyle doldurabilirsiniz)

🔧 Geliştirme
Yeni Özellik Ekleme
Proje SOLID prensiplerine uygun şekilde tasarlandığı için yeni özellikler kolayca eklenebilir:

Yeni kampanya eklemek için:

Yeni bir service interface'i oluşturun

Mevcut servislere dependency injection ile ekleyin

Yeni ödeme yöntemi eklemek için:

PaymentMethod enum'una yeni değer ekleyin

PaymentService'i güncelleyin

Kod Yapısı
csharp
// Örnek servis kullanımı
var productRepository = new ProductRepository();
var paymentService = new PaymentService();
var vendingMachineService = new VendingMachineService(productRepository, paymentService);

// Sipariş oluşturma
var order = vendingMachineService.CreateOrder(productId, quantity, sugarAmount);

// Ödeme işlemi
var receipt = vendingMachineService.ProcessPayment(order, paymentMethod, amountPaid);
📝 Lisans
Bu proje MIT lisansı altında lisanslanmıştır.

👨‍💻 Geliştirici
Ali Asaf Günşar
📧 aliasafgunsar@gmail.com
🌐 Portfolyo Website
🔗 LinkedIn Profili

Not: Bu proje bir case study olarak .NET Core ve SOLID prensipleri kullanılarak geliştirilmiştir. Gerçek ödeme sistemleri entegre edilmemiştir.
