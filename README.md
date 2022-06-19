# Hafta_5_Bedrhann
1--CQRS yapısında Mediatr ile (src/Core/Application/Features/Quaries/User/GetUser) Controller tarafında gerekli endpointe istek geldiğinde tetiklenip istek içinde ki 
sayfalama, search, filtreleme bilgilerine göre gerekli kullanıcı listenini dönüyor.

2--Controller tarafında CreateUser endpoint'ine istek olduğunda yaratılan veri sonucu src/Infrastructure/Infrastructure/Services/EventService/CreateUserEvent tetiklenir ve gerekli kuyruk oluşturularak gerekli veriler kuyruğa gönderilir.

3--UserBackgroundService ise CreateUserEvent  ile kuyruğa eklenen veriyi izliyor ve yakaladığında txt dosyasına yazıyor.

4-- src/Infrastructure/Infrastructure/Services/UserExportService ile kullanıcıları excel dosyasına export edip SendMailUserListService ile burada yaratılan dosyayı belirlenen gün ve saatlerde belirlenen yere mail atıyoruz.
