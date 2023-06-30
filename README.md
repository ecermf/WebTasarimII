# WebTasarimII
#Projenin amacı
Bu proje bir basit bir market uygulamasıdır. Ürün adı, kodu, fiyatı eklenip güncellenebiliyor. Silme işlemi de yapılabiliyor. Ve tüm ürünleri görebiliyoruz.
#Çalışma şekli
Ana sayfada ürünler listeleniyor. Ürün ekleme butonuna tıklayınca ürün ekleme sayfasına yönlendiriyor. Güncelleme ve silme işlemlerinde sayfanın yanında silinecek ürünün id bilgisini de gönderiyor. Hangi ürünün silinip, güncellenebileceğini anlıyoruz.
#Geliştirme adımları
Butona tıklayınca ilgili sayfaya yönlendirme işlemi gerçekleştirilir. HomeController içerisinde default olarak post işlemi için boş nesne gönderilir. Form ile product nesnesinin bind edilmesi için. kısıtlamaları isimleri ve geçersiz mesajları alması için.
post action metodu içerisinde EF Core kullanılarak ürün veritabanına eklenir, güncellenir ve silinir.
