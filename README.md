SimApi Dapper-EF Güncellemeleri Readme
Bu döküman, projede yapılan temel değişiklikleri ve bu değişikliklerin nerede yapıldığını anlatmaktadır.

1. DapperRepository Sınıfının Tamamlanması
Dosya: SimApi.Data/DapperRepository.cs
Bu dosya, Dapper için temel bir repository sınıfıdır ve Insert, Update, Delete, GetAll ve GetById gibi temel CRUD işlemlerini içerir.

2. Dapper Kullanılan Category Service'nin Hazırlanması
Dosya: SimApi.Operation/CategoryService.cs
Category modeli için Dapper servisi hazırlandı ve CategoryService.cs dosyasında yer almaktadır. Bu servis, Dinamik Dapper repository ile çalışacak şekilde tasarlanmıştır.

3. Category Controller'ının Hazırlanması
Dosya: SimApi.Service/CategoryController.cs
Category modeli için standart bir controller hazırlandı. Controller, GetAll, GetById, Insert, Update ve Delete gibi standart işlemleri içerir.

4. Dependency Injection (DI) İşlemlerinin Autofac ile Değiştirilmesi
Dosya: SimApi.Service/Startup.cs
Tüm DI işlemleri Autofac ile değiştirildi. Bu, Startup.cs dosyasında yer alan ConfigureServices ve ConfigureContainer metodlarındaki değişikliklerle sağlandı.

5. TransactionReportController'ın EF İle Çalışacak Şekilde Güncellenmesi
Dosya: SimApi.Service/Transaction/TransactionReportController.cs
Dapper'dan EF Core'a geçiş yapmak için TransactionReportController güncellendi. Bu değişiklik, controller içerisindeki metodların EF Core kullanacak şekilde yeniden yazılmasını içerir.
