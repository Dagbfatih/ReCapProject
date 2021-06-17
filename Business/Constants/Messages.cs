using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "Ürün eklendi";
        public static string CarNotAdded = "Ürün eklenemedi";
        public static string CarNameLitte = "Araba ismi en az 2 karakter olmalı";
        public static string CarDetailsGot = "Araba detayları alındı";
        public static string CarDeleted = "Ürün silindi";
        public static string CarUpdated = "Ürün güncellendi";
        public static string CarGot = "Araba getirildi";
        public static string NotCarAvailable = "Araba Mevcut Değil";

        public static string ColorAdded = "Ürün eklendi";
        public static string ColorNotAdded = "Ürün eklenemedi";
        public static string ColorNameLitte = "Araba ismi en az 2 karakter olmalı";
        public static string ColorDetailsGot = "Araba detayları alındı";
        public static string ColorDeleted = "Ürün silindi";
        public static string ColorUpdated = "Ürün güncellendi";

        public static string BrandAdded = "Ürün eklendi";
        public static string BrandDeleted = "Ürün silindi";
        public static string BrandUpdated = "Ürün güncellendi";

        public static string CarImageAdded = "Resim eklendi";
        public static string CarImageDeleted = "Resim silindi";
        public static string CarImageUpdated = "Resim güncellendi";
        public static string CarImagesLimited = "Resim limiti 5'tir";
        public static string CarImageGot = "Resim getirildi";

        public static string CreditCardAdded = "Kredi Kartı Kaydedildi";
        public static string CreditCardDeleted = "Kredi Kartı Silindi";
        public static string CreditCardUpdated = "Kredi Kartı Güncellendi";

        public static string UserAdded = "Kullanıcı getirildi";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string UserRegistered = "Kullanıcı başarıyla kaydedildi";

        public static string PasswordError = "Parola hatası";
        public static string SuccessfulLogin = "Giriş başarılı";
        public static string UserAlreadyExists = "Kullanıcı mevcut";
        public static string AccessTokenCreated = "";
        public static string AuthorizationDenied = "Yetki reddedildi";

        public static string PaymentSuccess = "Ödeme Başarılı";
    }
}
