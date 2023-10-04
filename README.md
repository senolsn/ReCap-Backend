# Rent A Car Projesi - Backend

Bu, Rent A Car Projesi'nin backend kısmını içeren depodur. Bu projede kullanılan teknolojiler ve projenin kısa açıklaması aşağıda verilmiştir.

## Proje Açıklaması

Rent A Car Projesi, araç kiralama işlemlerini yönetmek için bir backend uygulamasıdır. Müşterilerin araçları aramasına, kiralama yapmasına ve rezervasyon yapmasına olanak tanır. Ayrıca araçları ve rezervasyonları yönetmek için admin paneli sağlar.

## Kullanılan Teknolojiler

Bu proje aşağıdaki teknolojileri kullanmaktadır:
- **Dil:** C#
- **Framework:** .NET Core
- **Veritabanı:** Entity Framework Core
- **Veritabanı Yönetimi:** SQL Server
- **API Dökümantasyonu:** Swagger
- **Authentication/Authorization:** JSON Web Token (JWT)

## Nasıl Çalıştırılır

1. Repoyu bilgisayarınıza klonlayın.
2. Visual Studio veya Visual Studio Code gibi bir IDE kullanarak projeyi açın.
3. Projenin bağımlılıklarını yüklemek için `dotnet restore` komutunu kullanın.
4. Veritabanını oluşturmak ve verileri eklemek için `dotnet ef database update` komutunu kullanın.
5. Projeyi başlatmak için `dotnet run` komutunu kullanın.

## API Dökümantasyonu

Bu projenin API dökümantasyonuna Swagger arayüzü üzerinden erişebilirsiniz. Proje çalışırken [http://localhost:44317/swagger](http://localhost:44317/swagger) adresine giderek API'yi inceleyebilirsiniz.

**Not:** Projenin çalışabilmesi için bir SQL Server veritabanı bağlantısı yapılandırmanız gerekebilir. Bağlantı dizesi ve diğer konfigürasyon ayarları için `appsettings.json` dosyasını düzenlemeniz gerekebilir.
