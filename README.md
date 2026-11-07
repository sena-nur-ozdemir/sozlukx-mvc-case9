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
  <img width="1917" height="862" alt="Screenshot 2026-11-07 152740" src="https://github.com/user-attachments/assets/7cf5286d-891a-4d1c-b2ab-7671c059637d" />
  <br>
  <img width="1897" height="862" alt="Screenshot 2026-11-07 152712" src="https://github.com/user-attachments/assets/d8baa0b8-d34d-4232-a6d3-11c253fd16ba" />
  <br>
  <br>
  <img width="1912" height="862" alt="Screenshot 2026-11-07 153012" src="https://github.com/user-attachments/assets/66d4cac7-81f0-490e-91f5-e830adc6a9ca" />
  <br>
  <img width="1917" height="857" alt="Screenshot 2026-11-07 153101" src="https://github.com/user-attachments/assets/fd60cefa-1877-4d05-bf3e-687099ff21f6" />
  <br>
  <img width="1917" height="860" alt="Screenshot 2026-11-07 153458" src="https://github.com/user-attachments/assets/a4e1fefc-e150-444f-ad7a-5e103331b758" />
  <br>
  <img width="1917" height="847" alt="Screenshot 2026-11-07 153643" src="https://github.com/user-attachments/assets/6851ecb7-09d8-48a5-bf19-965b73990307" />
  <br>
  <img width="1917" height="855" alt="Screenshot 2026-11-07 153212" src="https://github.com/user-attachments/assets/3615b5bc-de02-4bb0-b1d5-d7cece9c3f85" />
  <br>
  <img width="1917" height="812" alt="Screenshot 2026-11-07 153756" src="https://github.com/user-attachments/assets/bd20bc28-6571-48be-b85c-7065864a49ce" />
  <br>
  <img width="1917" height="865" alt="Ekran görüntüsü 2023-12-14 223013" src="https://github.com/user-attachments/assets/05c5fb80-c841-4100-a00c-5ed03852f549" />
  <br>
  <img width="1917" height="866" alt="Screenshot 2026-11-07 153241" src="https://github.com/user-attachments/assets/f8d0220e-729f-46be-809b-e090919973e2" />
  <br>
<img width="1917" height="857" alt="Screenshot 2026-11-07 153328" src="https://github.com/user-attachments/assets/1bea381c-1c52-4706-ace0-1eafd9912317" />
  <br>
</details>

<details>
  <summary><b>🛠️ 2. Yönetim Paneli ve Raporlama</b></summary>
  <br>
  <i>Yapay zekâ desteğiyle tasarlanan yönetim paneli: dashboard, raporlama, kategoriler, yazarlar, başlıklar, entry’ler ve diğer yönetim işlemleri.</i>
  <br><br>
  <b>Yönetici Giriş Ekranı</b>
  <br>
  <img width="1917" height="867" alt="Screenshot 2026-11-07 153837" src="https://github.com/user-attachments/assets/059579e6-d50e-49aa-90c2-3c35ecae91c7" />
  <b>Genel Bakış (Dashboard)</b>
  <br>
  <img width="1891" height="867" alt="Screenshot 2026-11-07 154122" src="https://github.com/user-attachments/assets/5d84c76d-90ec-433b-9fc3-f98b6566b256" />
  <br><br>
  <b>Kategori Yönetimi</b>
  <br>
  <img width="1917" height="870" alt="Screenshot 2026-11-07 154200" src="https://github.com/user-attachments/assets/c02b1406-ebdd-492d-9954-ca1bc84e3b9a" />
  <b>Yeni Kategori Oluşturma</b>
  <br>
  <img width="1917" height="861" alt="Screenshot 2026-11-07 154651" src="https://github.com/user-attachments/assets/66ca4b8e-c223-4de5-b79e-350e4725d16e" />
  <br><br>
  <b>Yazar Yönetimi</b>
  <br>
  <img width="1917" height="862" alt="Screenshot 2026-11-07 154221" src="https://github.com/user-attachments/assets/5c03ff9d-fa45-4870-9e23-e16562dd3c05" />
  <br><br>
  <b>Başlık Yönetimi</b>
  <br>
  <img width="1917" height="857" alt="Screenshot 2026-11-07 154254" src="https://github.com/user-attachments/assets/7f6c487b-2467-493d-842e-0c5292c1fe81" />
  <br><br>
  <b>Yeni Başlık Oluşturma</b>
  <br>
  <img width="1916" height="861" alt="Screenshot 2026-11-07 154639" src="https://github.com/user-attachments/assets/fad14394-7ed4-45d8-aa86-022567b571b1" />
  <br><br>
  <b>Entry Yönetimi</b>
  <br>
  <img width="1917" height="862" alt="Screenshot 2026-11-07 154313" src="https://github.com/user-attachments/assets/2bf7fc26-078b-4b2d-9463-1d4d96b0f655" />
  <br><br>
  <b>Hakkımızda Yönetimi</b>
  <br>
  <img width="1917" height="862" alt="Screenshot 2026-11-07 154325" src="https://github.com/user-attachments/assets/720742f8-52a0-4722-85ef-38bfe11216c1" />
  <br><br>
  <b>Galeri Yönetimi</b>
  <br>
  <img width="1917" height="860" alt="Screenshot 2026-11-07 154338" src="https://github.com/user-attachments/assets/80208ce0-84ff-4bb6-8051-4d2ebfb7bab6" />
  <br><br>
  <b>İletişim Mesajları Yönetimi</b>
  <br>
  <img width="1916" height="855" alt="Screenshot 2026-11-07 154354" src="https://github.com/user-attachments/assets/1e0f8aae-59ed-43b1-8a26-532a172bd912" />
  <br><br>
  <b>İstatistikler ve Raporlar</b>
  <br>
  <img width="1901" height="866" alt="Screenshot 2026-11-07 154431" src="https://github.com/user-attachments/assets/144e5c9a-1dc3-48ec-88a6-b5cfcdf52b68" />
  <br><br>

</details>

---

**👩‍💻 Geliştirici:** [Sena Nur Özdemir](https://github.com/sena-nur-ozdemir)  
**📚 Eğitim kaynağı:** [Murat Yücedağ — MVC Proje Kampı (YouTube)](https://www.youtube.com/playlist?list=PLKnjBHu2xXNNQJehhCg--CzQQMHXTsFAb)

*Eğitim ve portföy amaçlı geliştirilen bir projedir. Ekran görüntülerinde örnek/test içerikleri kullanılmıştır.*
