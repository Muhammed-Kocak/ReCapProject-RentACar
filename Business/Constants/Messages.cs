using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        #region Entity
        public static string EntityListed = "Listelendi!";
        public static string EntityDeleted = "Silindi!";
        public static string EntityUpdated = "Güncellendi!";
        public static string EntityAdded = "Eklendi!";
        #endregion
        #region System
        public static string Maintenancetime = "Sistemimiz Bakımda!";
        #endregion
        #region Rules
        //General
        public static string Empty = "Boş Geçilebilir";
        public static string NotEmpty = "Boş Bırakılmaz!";
        public static string MinimumLenght = "Minimum uzunluk yanlış!";
        public static string MaximumLenght = "Maximum uzunluk yanlış!";
        public static string EntityNameInvalid = "İsim Geçersiz!";
        //CarValidator
        public static string WrongPriceEntry = "Günlük Fiyatı 0 Olamaz";
        public static string IncorrectYearUse = "Yıl Yazımı Yanlış";
        //ColorValidator

        //CustomerValidator

        //RentalValidator
        public static string CheckDate = "Yazılan gün/saat şu anki gün/saat ile aynı ya da ileri bir tarihli olmalıdır. ";
        public static string CheckRent = "Araç Kiralanamaz! (Şu an kullanımda)";

        //UserValidator
        public static string IsEmailUnique = "Aynı E-Mail'den Mevcut. LÜTFEN GİRİŞ YAPINIZ!";
        public static string EmailCheck = "Standart E-Mail Yazımında hata var lütfen kontrol ediniz.";


        //BrandValidator

        //CarImageValidator
        public static string FileSizeError = "Dosya boyutu en fazla 500kb olmalıdır.";
        public static string UnsupportedFileType = "Dosya türü desteklenmiyor";

        #endregion
        #region General

        #endregion
        #region CarImages
        public static string CarImageAddLimit = "Bir arabanın en fazla 5 resmini yükleyebilirsin";

        public static string CarImageAdded = "Resim başarıyla yüklendi";

        public static string CarImageDeleted = "Resim silindi";

        public static string GetErrorCarDetails = "Araç bilgisi bulunamadı";
        #endregion
        #region Auth
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Şifre hatalı";
        public static string SuccessfulLogin = "Sisteme giriş başarılı";
        public static string UserAlreadyExists = "Bu kullanıcı zaten mevcut";
        public static string UserRegistered = "Kullanıcı başarıyla kaydedildi";
        public static string AccessTokenCreated = "Access token başarıyla oluşturuldu";

        public static string AuthorizationDenied = "Yetkiniz yok";
        internal static string GetSuccessCarMessage = "";

        public static string GetErrorCarMessage = "";
        #endregion
        #region Rental
        public static string AddRentalMessage = "Araç kiralama işlemi başarıyla eklendi.";

        public static string DeleteRentalMessage = "Araç kiralama işlemi başarıyla silindi.";
        public static string EditRentalMessage = "Araç kiralama işlemi başarıyla güncellendi.";
        public static string GetSuccessRentalMessage = "Araç kiralama işlemi bilgisi / bilgileri getirildi.";
        public static string GetErrorRentalMessage = "Araç kiralama işlemi bilgisi / bilgileri getirilemedi.";
        public static string CarAvaible = "Araç kiralanmaya uygundur.";
        public static string CarNotAvaible = "Araç kiralanmaya uygun değildir.";
        public static string CarNotDeliverTheCar = "Araç teslim almaya uygun değildir.";
        public static string CarDeliverTheCar = "Araç teslim alındı.";
        public static string ErrorRentalFKMessage = "Müşteri ve araba alanlarını tekrar kontrol ediniz..";
        public static string InsufficientBalance = "Yetersiz bakiye";
        public static string PaymentCompleted = "Ödeme yapıldı";
        #endregion
    }
}
