# 🚀 ForgeFolio

Modern portfolio yönetim sistemi. ASP.NET Core 9 ve Entity Framework Core ile geliştirilmiştir.

## ✨ Özellikler

- **Frontend**: Responsive tasarım, portfolio gösterimi, iletişim formu
- **Admin Panel**: Dashboard, içerik yönetimi, mesaj yönetimi, yapılacaklar listesi
- **Teknoloji**: ASP.NET Core 9, Entity Framework Core, Bootstrap 5

## 🛠️ Teknolojiler

- **Backend**: ASP.NET Core 9, Entity Framework Core, SQL Server
- **Frontend**: Bootstrap 5, jQuery, Font Awesome
- **Mimari**: MVC Pattern, Dependency Injection, ViewComponents

## 📁 Proje Yapısı

```
ForgeFolio/
├── Controllers/          # MVC Controller'ları
├── DAL/                  # Data Access Layer
├── ViewComponents/       # Yeniden kullanılabilir bileşenler
├── Views/               # Razor view dosyaları
└── wwwroot/             # Statik dosyalar
```

## 🚀 Kurulum

1. **Projeyi klonlayın**
   ```bash
   git clone https://github.com/yourusername/ForgeFolio.git
   cd ForgeFolio
   ```

2. **Bağımlılıkları yükleyin**
   ```bash
   dotnet restore
   ```

3. **Veritabanını oluşturun**
   ```bash
   dotnet ef database update
   ```

4. **Uygulamayı çalıştırın**
   ```bash
   dotnet run
   ```

## 📊 Kullanım

- **Frontend**: `/Default/Index` - Portfolio ana sayfası
- **Admin Panel**: `/Layout/Index` - Yönetim paneli
- **İletişim**: Form üzerinden mesaj gönderme
- **CRUD**: Tüm içerik yönetimi işlemleri

## 🔧 Geliştirme

- **Entity**: `DAL/Entities/` klasörüne yeni model ekleyin
- **Controller**: CRUD işlemleri için controller oluşturun
- **View**: Razor view dosyalarını ekleyin
- **Migration**: `dotnet ef migrations add MigrationName`

## 📝 Lisans

MIT License - Detaylar için `LICENSE` dosyasına bakın.

## 👨‍💻 Geliştirici

**Anıl Akbay** - Full Stack Developer
- GitHub: [@anilakbay](https://github.com/anilakbay)
- Email: anilakbay20@gmail.com

---

⭐ **Bu projeyi beğendiyseniz yıldız vermeyi unutmayın!**