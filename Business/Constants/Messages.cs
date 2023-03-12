using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public class Messages
    {
        public static string CarAdded = "Araba eklendi.";
        public static string CarDescriptionInvalid = "Araba açıklaması geçersiz.";
        public static string MaintenanceTime="Sistem bakımda.";
        public static string CarsListed="Arabalar listelendi.";
        public static string CarsUpdated="Arabalar güncellendi.";
        public static string CarDeleted= "Arabalar silindi.";
        public static string CustomerAdded="Müşteri eklendi.";
        public static string RentalAdded = "Müşteri eklendi.";
        public static string RentalDeleted="Kiralama eklendi.";
        public static string RentalsUpdated = "Kiralamalar güncellendi." ;
        public static string UserAdded = "Kullanıcı eklendi.";
        public static string UserDeleted = "Kulanıcı güncellendi."   ;
        public static string UsersUpdated = "Kullanıcılar güncellendi."   ;
        public static string BrandsListed = "Markalar eklendi."  ;
        public static string ColorsListed="Renkler listelendi.";
        public static string BrandAdded="Marka eklendi.";
        public static string BrandDeleted="Marka silindi.";
        public static string BrandsUpdated="Markalar güncellendi.";
        public static string ColorAdded = "Renk eklendi.";
        public static string ColorDeleted = "Renk silindi.";
        public static string ColorsUpdated = "Renkler güncellendi.";
        public static string CustomerDeleted = "Müşteri silindi.";
        public static string CustomersUpdated = "Müşteriler güncellendi.";
        public static string CustomersListed = "Müşteriler listelendi.";
        public static string RentalsListed="Kiralamalar listelendi.";
        public static string UsersListed="Kullanıcılar listelendi.";
        public static string CarImageDeleted="Araba görüntüsü silindi.";
        public static string CarImagesListed="Araba görüntüleri listelendi.";
        public static string CarImagesUpdated = "Araba görüntüleri güncellendi.";
        public static string CarImagesAdded = "Araba görüntüleri eklendi.";
        public static string CarImagesListedByCarId="Araba görüntüleri araba ıdlerine göre listelendi.";
        public static string CarImageLimitExceeded="Araba görütülerini koyma limiti aşıldı.";
        public static string UserRegistered="Kullanıcı kaydı alındı.";
        public static string UserNotFound="Kullanıcı bulunamadı.";
        public static string PasswordError="Şifre hatalı";
        public static string SuccessfulLogin="Kayıt başarılı bir şekilde gerçekleşti.";
        public static string UserAlreadyExists="Bu kullanıcı zaten var.";
        public static string AccessTokenCreated="Yetkilendirme yapıldı.";
        internal static SerializationInfo AuthorizationDenied;
        internal static string CustomerNotFound;
        internal static string CarNotFound;
        internal static string CustomerFindeksPointIsNotEnoughForThisCar;
        internal static string RentalDateCannotBeBeforeToday;
        internal static string ReturnDateCannotBeLeftBlankAsThisCarWasAlsoRentedAtALaterDate;
        internal static string ThisCarHasNotBeenReturnedYet;
        internal static string ReturnDateCannotBeEarlierThanRentDate;
        internal static string ThisCarIsAlreadyRentedInSelectedDateRange;
        internal static string UserUpdated;
        internal static string UserPasswordUpdated;
        internal static string LastTwoDigitsOfYearMustBeEntered;
        internal static string CardNumberMustConsistOfLettersOnly;
        internal static string PayIsSuccessfull;
        internal static string CardInformationIsIncorrect;
    }
}
