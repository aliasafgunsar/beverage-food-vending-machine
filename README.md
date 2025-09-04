# 📋 Proje Özeti
# Bu proje, 20 yiyecek ve 10 içecek ürün yuvasına sahip, kredi kartı (temaslı/temassız) ve nakit (kağıt/madeni para) ödeme yöntemlerini destekleyen bir otomat simülasyonudur. Sıcak içecekler için şeker miktarı seçeneği sunar.

---

## Kurulum Talimatları

1. **Projeyi Klonla:**
   ```sh
   git clone https://github.com/aliasafgunsar/vending-machine.git
   cd vending-machine
   ```

2. **Solution'ı Açma ve Çalıştırma:**
   ```sh
   dotnet build
   cd VendingMachine.WindowsUI
   dotnet run
   ```

## 🏗️ Proje Mimarisi

Proje, sade ve anlaşılır bir klasör yapısına sahiptir:

```
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

```

### 🏗️ Katmanlar

- **Models/**: 
-> Product.cs - Ürün modeli (ID, Name, Price, Stock, Type, IsHotDrink)
-> Order.cs - Sipariş modeli (Product, Quantity, SugarAmount, TotalAmount)
-> Receipt.cs - Fiş modeli (ProductName, ProductNumber, PaymentMethod, AmountPaid, ChangeAmount)
-> PaymentResult.cs - Ödeme sonuç modeli

- **Enums/**:
-> ProductType.cs - Food, Beverage
-> PaymentMethod.cs - CreditCardContact, CreditCardContactless, CashCoin, CashPaper
-> SugarAmount.cs - None, Low, Medium, High

- **Interfaces/**:
-> IProduct.cs - Ürün interface'i
-> IProductRepository.cs - Repository pattern interface
-> IPaymentService.cs - Ödeme servis interface'i
-> IVendingMachineService.cs - Ana iş mantığı interface'i

- **Services/ (Infrastructure katmanında)**:
-> PaymentService.cs - Ödeme işlemleri implementasyonu
-> VendingMachineService.cs - Ana iş mantığı implementasyonu

- *Repositories/ (Infrastructure katmanında)**:
-> Repositories/ (Infrastructure katmanında)
-> ProductRepository.cs - Ürün veri erişim katmanı

- **WindowsUI/ (UI Katmanı)**:
-> Form1.cs - Ana form ve kullanıcı arayüzü
  
---

## 🛠️ Kullanılan Teknolojiler

- **.NET 6.0 (Windows Forms App)**
- **C# (Nesne yönelimli programlama)**
- **SOLID Principles (Katmanlı mimari)**
- **Dependency Injection (Manuel implementation)**
- **xUnit (Unit test framework)**
- **Moq (Mocking kütüphanesi)**
- **Windows Forms (UI framework)**
- **LINQ (Data manipulation)**
- **OOP Patterns (Repository, Service patterns)**

---

## ✨  Proje Özellikleri

- ✅ 20 yiyecek + 10 içecek ürün yuvası
- ✅ Miktar seçimi (1-10 adet)
- ✅ Sıcak içecekler için şeker miktarı seçeneği (Şekersiz, Az, Orta, Çok)
- ✅ Çoklu ödeme yöntemleri:
- ✅ Temaslı Kredi Kartı, Temassız Kredi Kartı, Nakit (Kağıt Para), Nakit (Madeni Para)
- ✅ Detaylı fiş bilgisi (ürün adı, numara, ödeme yöntemi, para üstü)
- ✅ Türkçe ve kullanıcı dostu arayüz

---

## 🧪 Test Kapsamı

- **Proje, %70'ten fazla test kapsamına sahiptir:**

- Ürün repository testleri
- Ödeme servisi testleri
- Otomat servisi testleri
- Stok kontrolü testleri
- Sipariş oluşturma testleri

---

📝 Lisans
Bu proje MIT lisansı altında lisanslanmıştır.

---

## Not

- Bu proje bir case study olarak .NET Core ve SOLID prensipleri kullanılarak geliştirilmiştir. Gerçek ödeme sistemleri entegre edilmemiştir.

---

## 👨‍💻 Geliştirici

**Ali Asaf Günşar**  
📧 aliasafgunsar@gmail.com  
🌐 [Sitem](https://aliasafgunsar.com)  
🔗 [LinkedIn Profilim](https://linkedin.com/in/aliasafgunsar)
