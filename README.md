# 📖 SözlükX | MVC Sözlük Uygulaması — Case #9

**SözlükX**, kullanıcıların kategorilere göre başlık oluşturabildiği, entry paylaşabildiği ve birbirleriyle mesajlaşabildiği dinamik bir sözlük uygulamasıdır.

Proje, **M&Y Yazılım Eğitim Akademi .NET Full Stack Bootcamp** kapsamında, **Murat Yücedağ'ın YouTube'daki 100 derslik MVC Proje Kampı** serisi temel alınarak **Case #9** çalışması olarak geliştirilmiştir. Eğitimdeki katmanlı mimari ve veritabanı yaklaşımı, SözlükX'e özel arayüzle uygulanmıştır.

## 🧩 N Katmanlı Mimari

- **EntityLayer:** Varlık sınıfları ve tablolar arası ilişkiler
- **DataAccessLayer:** Entity Framework 6, DbContext, Generic Repository ve veri erişim işlemleri
- **BusinessLayer:** Manager sınıfları, iş kuralları ve doğrulamalar
- **Case9MvcSozluk (Presentation):** MVC Controller'ları, Razor View'lar ve kullanıcı arayüzü

**Çalışılan konular:** Code First, Migrations, LINQ, Generic Repository Pattern, CRUD işlemleri, ilişkisel veritabanı, Forms Authentication ve yönetici/yazar yetkilendirmesi.

## 🛠️ Kullanılan Teknolojiler

**C# · ASP.NET MVC 5 · .NET Framework 4.8 · Entity Framework 6 · SQL Server · LINQ · Razor Views · HTML · CSS · JavaScript · Bootstrap**

## 🚀 Proje Özellikleri

- **Sözlük:** Kategoriye bağlı başlıklar, entry'ler, arama ve sıralama
- **Yazar işlemleri:** Kayıt/giriş, profil düzenleme, başlık oluşturma ve kendi entry'lerini yönetme
- **Mesajlaşma:** Gelen kutusu, gönderilenler, taslaklar ve mesaj detayları
- **Yönetim paneli:** Kategori, yazar, başlık ve entry yönetimi; aktif/pasif durum işlemleri
- **Diğer bölümler:** Hakkımızda, iletişim, galeri ve veritabanı verilerinden üretilen istatistikler

## 🎨 Yapay Zekâ Destekli Arayüz Tasarımı

SözlükX'in ön yüzü hazırlanan HTML temasından **Razor View** yapısına uyarlanmıştır. **Yönetim paneli, hazır bir admin şablonu kullanılmadan yapay zekâ desteğiyle tasarlanmış** ve HTML, CSS, JavaScript ile MVC projesine entegre edilmiştir.

> Yapay zekâ, tasarım ve geliştirme sürecinde yardımcı araç olarak kullanılmıştır; uygulama içinde çalışan bir AI modeli veya servisi bulunmamaktadır.

---

## 📸 Ekran Görüntüleri

*Bölüm başlıklarına tıklayarak ilgili ekran görüntülerini açabilirsiniz.*

<details>
  <summary><b>🌐 1. Sözlük ve Genel Sayfalar</b></summary>
  <br>
  <i>Başlık ve entry listeleri, galeri, iletişim ve yazar hesabı ekranları.</i>
  <br><br>
  <b>Sözlük Ana Sayfası — Başlıklar ve Entry’ler</b>
  <br>
  <img width="1912" height="862" alt="Screenshot 2026-11-07 153012" src="https://github.com/user-attachments/assets/66d4cac7-81f0-490e-91f5-e830adc6a9ca" />

  <img width="1917" height="857" alt="Screenshot 2026-11-07 153101" src="https://github.com/user-attachments/assets/fd60cefa-1877-4d05-bf3e-687099ff21f6" />
  
  <img width="1917" height="860" alt="Screenshot 2026-11-07 153458" src="https://github.com/user-attachments/assets/a4e1fefc-e150-444f-ad7a-5e103331b758" />

<img width="1917" height="847" alt="Screenshot 2026-11-07 153643" src="https://github.com/user-attachments/assets/6851ecb7-09d8-48a5-bf19-965b73990307" />

<img width="1917" height="855" alt="Screenshot 2026-11-07 153212" src="https://github.com/user-attachments/assets/3615b5bc-de02-4bb0-b1d5-d7cece9c3f85" />

<img width="1917" height="812" alt="Screenshot 2026-11-07 153756" src="https://github.com/user-attachments/assets/bd20bc28-6571-48be-b85c-7065864a49ce" />

  <br><br>
  <b>Hakkımızda </b>
  <br>
  <img width="1917" height="865" alt="Ekran görüntüsü 2023-12-14 223013" src="https://github.com/user-attachments/assets/05c5fb80-c841-4100-a00c-5ed03852f549" />

  <br><br>
  
  <b>İletişim Formu</b>
  <br>
  <img width="1917" height="866" alt="Screenshot 2026-11-07 153241" src="https://github.com/user-attachments/assets/f8d0220e-729f-46be-809b-e090919973e2" />
  
  <b>Galeri</b>
  <br>
<img width="1917" height="857" alt="Screenshot 2026-11-07 153328" src="https://github.com/user-attachments/assets/1bea381c-1c52-4706-ace0-1eafd9912317" />
  <br><br>

  <b>Yazar Girişi</b>
  <br>
  <img width="1917" height="862" alt="Screenshot 2026-11-07 152740" src="https://github.com/user-attachments/assets/7cf5286d-891a-4d1c-b2ab-7671c059637d" />
  <br><br>
  <b>Yazar Kayıt Formu</b>
  <br>
  <img width="1897" height="862" alt="Screenshot 2026-11-07 152712" src="https://github.com/user-attachments/assets/d8baa0b8-d34d-4232-a6d3-11c253fd16ba" />
  <br><br>
</details>


<details>
  <summary><b>✍️ 2. Yazar İşlemleri ve Mesajlaşma</b></summary>
  <br>
  <i>Yazarların kendi başlıklarını ve entry’lerini yönetebildiği, gelen/gönderilen mesajları görüntüleyebildiği ekranlar.</i>
  <br><br>
  <b>Başlıklarım — Yazarın İçerik Yönetimi</b>
  <br>
  <img width="1200" alt="Başlıklarım — Yazarın İçerik Yönetimi" src="screenshots/02_Yazar_Islemleri/03_Basliklarim.png" />
  <br><br>
  <b>Yeni Entry Oluşturma</b>
  <br>
  <img width="1200" alt="Yeni Entry Oluşturma" src="screenshots/02_Yazar_Islemleri/01_Yeni_Entry_Penceresi.png" />
  <br><br>
  <b>Gelen Kutusu</b>
  <br>
  <img width="1200" alt="Gelen Kutusu" src="screenshots/02_Yazar_Islemleri/04_Gelen_Kutusu.png" />
  <br><br>
  <b>Gönderilen Mesajlar</b>
  <br>
  <img width="1200" alt="Gönderilen Mesajlar" src="screenshots/02_Yazar_Islemleri/02_Gonderilen_Mesajlar.png" />
  <br><br>
  <b>Mesaj Detayı</b>
  <br>
  <img width="1200" alt="Mesaj Detayı" src="screenshots/02_Yazar_Islemleri/05_Mesaj_Detayi.png" />
  <br><br>
</details>


<details>
  <summary><b>🛠️ 3. Yönetim Paneli ve Raporlama</b></summary>
  <br>
  <i>Yapay zekâ desteğiyle tasarlanan yönetim paneli: dashboard, raporlama, kategoriler, yazarlar, başlıklar, entry’ler ve diğer yönetim işlemleri.</i>
  <br><br>
  <b>Genel Bakış (Dashboard)</b>
  <br>
  <img width="1200" alt="Genel Bakış (Dashboard)" src="screenshots/03_Yonetim_Paneli/02_Genel_Bakis.png" />
  <br><br>
  <b>İstatistikler ve Raporlar</b>
  <br>
  <img width="1200" alt="İstatistikler ve Raporlar" src="screenshots/03_Yonetim_Paneli/10_Istatistikler.png" />
  <br><br>
  <b>Kategori Yönetimi</b>
  <br>
  <img width="1200" alt="Kategori Yönetimi" src="screenshots/03_Yonetim_Paneli/03_Kategori_Yonetimi.png" />
  <br><br>
  <b>Yazar Yönetimi</b>
  <br>
  <img width="1200" alt="Yazar Yönetimi" src="screenshots/03_Yonetim_Paneli/04_Yazar_Yonetimi.png" />
  <br><br>
  <b>Başlık Yönetimi</b>
  <br>
  <img width="1200" alt="Başlık Yönetimi" src="screenshots/03_Yonetim_Paneli/05_Baslik_Yonetimi.png" />
  <br><br>
  <b>Entry Yönetimi</b>
  <br>
  <img width="1200" alt="Entry Yönetimi" src="screenshots/03_Yonetim_Paneli/06_Entry_Yonetimi.png" />
  <br><br>
  <b>Yeni Başlık Oluşturma</b>
  <br>
  <img width="1200" alt="Yeni Başlık Oluşturma" src="screenshots/03_Yonetim_Paneli/11_Yeni_Baslik.png" />
  <br><br>
  <b>Yeni Kategori Oluşturma</b>
  <br>
  <img width="1200" alt="Yeni Kategori Oluşturma" src="screenshots/03_Yonetim_Paneli/12_Yeni_Kategori.png" />
  <br><br>
  <b>Hakkımızda Yönetimi</b>
  <br>
  <img width="1200" alt="Hakkımızda Yönetimi" src="screenshots/03_Yonetim_Paneli/07_Hakkimizda_Yonetimi.png" />
  <br><br>
  <b>Galeri Yönetimi</b>
  <br>
  <img width="1200" alt="Galeri Yönetimi" src="screenshots/03_Yonetim_Paneli/08_Galeri_Yonetimi.png" />
  <br><br>
  <b>İletişim Mesajları Yönetimi</b>
  <br>
  <img width="1200" alt="İletişim Mesajları Yönetimi" src="screenshots/03_Yonetim_Paneli/09_Iletisim_Yonetimi.png" />
  <br><br>
  <b>Yönetici Giriş Ekranı</b>
  <br>
  <img width="1200" alt="Yönetici Giriş Ekranı" src="screenshots/03_Yonetim_Paneli/01_Yonetici_Giris.png" />
  <br><br>
</details>

---

**👩‍💻 Geliştirici:** [Sena Nur Özdemir](https://github.com/sena-nur-ozdemir)  
**📚 Eğitim kaynağı:** [Murat Yücedağ — MVC Proje Kampı (YouTube)](https://www.youtube.com/playlist?list=PLKnjBHu2xXNNQJehhCg--CzQQMHXTsFAb)

*Eğitim ve portföy amaçlı geliştirilen bir projedir. Ekran görüntülerinde örnek/test içerikleri kullanılmıştır.*
