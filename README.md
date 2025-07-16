👁️ EyeCareAI - Yapay Zeka Destekli Göz Hastalıklarında Erken Teşhis Yapan Web Uygulaması

EyeCareAI, yapay zeka destekli algoritmalar kullanarak göz hastalıklarının erken teşhisini amaçlayan bir web tabanlı uygulamadır.  
Gelişmiş görüntü işleme ve makine öğrenmesi teknikleriyle göz taramalarını analiz eder, potansiyel hastalık belirtilerini tespit eder ve doktora ön değerlendirme sunar.  
Erken teşhis sayesinde tedavi sürecinin daha etkili hale gelmesine katkı sağlamayı hedefler.

---

## ⚙️ Kullanılan Teknolojiler

### 🖥️ Backend
- **ASP.NET Core** – Web API ve MVC yapısıyla güçlü ve ölçeklenebilir bir arka uç geliştirme
- **Entity Framework Core** – ORM (Object-Relational Mapping) aracı
- **MSSQL Server** – İlişkisel veri tabanı yönetim sistemi

### 🌐 Frontend
- **Razor Pages / MVC Views** – ASP.NET Core ile birlikte sunulan dinamik sayfa yapısı
- **HTML5, CSS3, JavaScript** – Temel frontend teknolojileri
- **Bootstrap** – UI bileşenleri ve responsive tasarım için

### 🧩 Diğer
- RESTful API yapısı
- Identity
- Ajax
- Dependency Injection (bağımlılık enjeksiyonu)
- Model-View-Controller (MVC) mimarisi
- JSON ile veri alışverişi
- Swagger: API dokümantasyonu için

---
### 🧩 Mimari
EyeCareAI, sürdürülebilir ve test edilebilir bir yapı sunan 6 katmanlı (N-Tier Architecture) mimari ve Repository Design Pattern ile geliştirilmiştir. Bu yapı, kodun sorumluluklarına göre ayrılmasını sağlar.

📚 Katmanlar:
🎨 Presentation Layer (Sunum Katmanı)

Kullanıcının etkileşimde bulunduğu arayüzdür (Razor Pages & MVC Views).

🧠 Business Layer (İş Katmanı)

Uygulamanın iş mantığını ve kurallarını içerir. Servisler bu katmanda bulunur.

💾 Data Access Layer (Veri Erişim Katmanı)

Entity Framework Core ile veritabanı işlemleri gerçekleştirilir.

Repository Pattern ile veri işlemleri soyutlanmıştır.

📦 Entities Layer (Varlıklar Katmanı)

Domain sınıfları (Hasta, Doktor, AnalizSonucu vb.) burada yer alır.

📤 DTO Layer (Data Transfer Objects)

Katmanlar arası veri taşınırken kullanılan optimize edilmiş veri yapılarıdır.

🧬 AI Layer (Yapay Zeka Katmanı)

Derin öğrenme (CNN) modeliyle göz görüntüleri analiz edilir ve sonuçlar üretilir.

Bu mimari sayesinde uygulama modüler, kolay geliştirilebilir ve test edilebilir bir yapı kazanmıştır.

---
🚀 **Özellikler**

- ✅ **Görsel Tabanlı Göz Analizi**
  - Kullanıcılar göz görüntülerini sisteme yükler.
  - Yüklenen görüntüler yapay zeka tarafından analiz edilir.

- 🔍 **Yapay Zeka ile Erken Teşhis**
  - Eğitimli derin öğrenme modeli potansiyel göz hastalıklarını tanımlar.
  - Erken teşhis sayesinde doktora yönlendirme yapılabilir.

- 🧠 **Makine Öğrenmesi Altyapısı**
  - Görüntü sınıflandırması için CNN (Convolutional Neural Network) mimarisi.
  - Model, çeşitli veri kümeleriyle eğitilmiş ve optimize edilmiştir.

- 📊 **Detaylı Sonuç Ekranı**
  - Analiz sonuçları grafiklerle ve açıklamalarla gösterilir.
  - Hastalık ihtimali oranları kullanıcıya sunulur.

- 🌐 **Web Tabanlı Erişim**
  - Tüm modern tarayıcılardan erişilebilir responsive arayüz.
  - Mobil ve masaüstü uyumlu.

- 🛡️ **Gizlilik ve Güvenlik**
  - Kullanıcı verileri lokal veya güvenli veritabanlarında tutulur.
  - Görseller hiçbir şekilde üçüncü taraflarla paylaşılmaz.

---

📷 **Ekran Görüntüleri**

Aşağıda EyeCareAI web uygulamasına ait çeşitli ekran görüntülerini ve panellerin işleyişine dair açıklamaları bulabilirsiniz.

---

### 🏠 Ana Sayfa & Genel Site Arayüzü

![Site Görseli 1](https://github.com/AOghuz/EyeCareAIProject/raw/master/EyeCareAIProject/wwwroot/SS_Images/sitepng/site1.png)  
![Site Görseli 2](https://github.com/AOghuz/EyeCareAIProject/raw/master/EyeCareAIProject/wwwroot/SS_Images/sitepng/site2.png)  
![Site Görseli 3](https://github.com/AOghuz/EyeCareAIProject/raw/master/EyeCareAIProject/wwwroot/SS_Images/sitepng/site3.png)  
![Site Görseli 4](https://github.com/AOghuz/EyeCareAIProject/raw/master/EyeCareAIProject/wwwroot/SS_Images/sitepng/site4.png)  
![Site Görseli 5](https://github.com/AOghuz/EyeCareAIProject/raw/master/EyeCareAIProject/wwwroot/SS_Images/sitepng/site5.png)  
![Site Görseli 6](https://github.com/AOghuz/EyeCareAIProject/raw/master/EyeCareAIProject/wwwroot/SS_Images/sitepng/site6.png)  
![Site Görseli 7](https://github.com/AOghuz/EyeCareAIProject/raw/master/EyeCareAIProject/wwwroot/SS_Images/sitepng/site7.png)  
![Site Görseli 8](https://github.com/AOghuz/EyeCareAIProject/raw/master/EyeCareAIProject/wwwroot/SS_Images/sitepng/site8.png)  
![Site Görseli 9](https://github.com/AOghuz/EyeCareAIProject/raw/master/EyeCareAIProject/wwwroot/SS_Images/sitepng/site9.png)  
![Site Görseli 10](https://github.com/AOghuz/EyeCareAIProject/raw/master/EyeCareAIProject/wwwroot/SS_Images/sitepng/site10.png)  
![Site Görseli 11](https://github.com/AOghuz/EyeCareAIProject/raw/master/EyeCareAIProject/wwwroot/SS_Images/sitepng/site11.png)  
![Site Görseli 12](https://github.com/AOghuz/EyeCareAIProject/raw/master/EyeCareAIProject/wwwroot/SS_Images/sitepng/site12.png)

Ziyaretçilere yönelik hazırlanmış, modern ve kullanıcı dostu bir ana sayfa tasarımıdır.  
Kullanıcıları karşılayan tanıtım içerikleri, giriş yönlendirmeleri ve genel navigasyon bu bölümde yer alır.  


---

### 🧑‍⚕️ Doktor Paneli

![Doktor Paneli 1](https://github.com/AOghuz/EyeCareAIProject/raw/master/EyeCareAIProject/wwwroot/SS_Images/Doktorpng/doktor1.png)  
![Doktor Paneli 2](https://github.com/AOghuz/EyeCareAIProject/raw/master/EyeCareAIProject/wwwroot/SS_Images/Doktorpng/doktor2.png)  
![Doktor Paneli 3](https://github.com/AOghuz/EyeCareAIProject/raw/master/EyeCareAIProject/wwwroot/SS_Images/Doktorpng/doktor3.png)  
![Doktor Paneli 4](https://github.com/AOghuz/EyeCareAIProject/raw/master/EyeCareAIProject/wwwroot/SS_Images/Doktorpng/doktor4.png)

- Yapay zeka tarafından analiz edilmiş hasta sonuçlarını görüntüler.
- Hastanın teşhis geçmişine erişim sağlar.
- Tedavi süreci hakkında not ekleme ve öneri belirtme fonksiyonları bulunur.

---

### 🧑‍💼 Admin Paneli

![Admin Paneli 1](https://github.com/AOghuz/EyeCareAIProject/raw/master/EyeCareAIProject/wwwroot/SS_Images/Adminpng/admin1.png)  
![Admin Paneli 2](https://github.com/AOghuz/EyeCareAIProject/raw/master/EyeCareAIProject/wwwroot/SS_Images/Adminpng/admin2.png)  
![Admin Paneli 3](https://github.com/AOghuz/EyeCareAIProject/raw/master/EyeCareAIProject/wwwroot/SS_Images/Adminpng/admin3.jpg) 
![Admin Paneli 4](https://github.com/AOghuz/EyeCareAIProject/raw/master/EyeCareAIProject/wwwroot/SS_Images/Adminpng/admin4.png)  
![Admin Paneli 5](https://github.com/AOghuz/EyeCareAIProject/raw/master/EyeCareAIProject/wwwroot/SS_Images/Adminpng/admin5.png)  
![Admin Paneli 6](https://github.com/AOghuz/EyeCareAIProject/raw/master/EyeCareAIProject/wwwroot/SS_Images/Adminpng/admin6.png)  
![Admin Paneli 7](https://github.com/AOghuz/EyeCareAIProject/raw/master/EyeCareAIProject/wwwroot/SS_Images/Adminpng/admin7.png)  
![Admin Paneli 8](https://github.com/AOghuz/EyeCareAIProject/raw/master/EyeCareAIProject/wwwroot/SS_Images/Adminpng/admin8.png)  
![Admin Paneli 9](https://github.com/AOghuz/EyeCareAIProject/raw/master/EyeCareAIProject/wwwroot/SS_Images/Adminpng/admin9.png)  
![Admin Paneli 10](https://github.com/AOghuz/EyeCareAIProject/raw/master/EyeCareAIProject/wwwroot/SS_Images/Adminpng/admin10.png)

Yöneticiler için sistem kontrollerinin yapıldığı, kullanıcı ve doktor yönetimi, içerik düzenleme ve duyuru oluşturma gibi özelliklerin bulunduğu admin paneline ait ekran görüntüleridir.

- Kullanıcı (doktor/hasta) yönetimi yapılır.
- Sistem ayarları, yetkilendirme ve log kayıtları görüntülenebilir.
- Yapay zeka model güncellemeleri ve sistem performans takibi bu alandan sağlanır.

---


### 🧑‍🦰 Hasta Paneli

![Hasta Paneli 1](https://github.com/AOghuz/EyeCareAIProject/raw/master/EyeCareAIProject/wwwroot/SS_Images/hastapng/hasta1.png)  
![Hasta Paneli 2](https://github.com/AOghuz/EyeCareAIProject/raw/master/EyeCareAIProject/wwwroot/SS_Images/hastapng/hasta2.png)

- Göz görüntüsü yükleme ve analiz başlatma alanı bulunur.
- Analiz geçmişi, teşhis sonuçları ve sistem önerileri kullanıcıya gösterilir.
- Gerekli durumlarda doktora ulaşma bağlantısı sağlanır.

---



