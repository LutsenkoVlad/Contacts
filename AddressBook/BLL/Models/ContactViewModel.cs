using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.BLL.Models
{
    public class ContactViewModel
    {
        public int ContactId { get; set; }

        [Required]
        public string Login { get; set; }

        [Required]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Incorrect address")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Address { get; set; }

        public bool IsPrivateBirthDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime? BirthDate { get; set; }

        public bool IsPrivatePhoto { get; set; }

        public byte[] ImageData { get; set; }

        public string ImageMimeType { get; set; }

        public IList<PhoneViewModel> Phones { get; set; }

        public ContactViewModel()
        {
            Phones = new List<PhoneViewModel>();
        }

        public ContactViewModel(int ContactId,string Login,string Password, string FirstName, string LastName, string Country, string City,
                                string Email, string Address,bool IsPrivateBirthDate,DateTime? BirthDate,IList<PhoneViewModel> Phones,
                                string ImageMimeType,byte[] ImageData)
        {
            this.ContactId = ContactId;
            this.Login = Login;
            this.Password = Password;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Country = Country;
            this.City = City;
            this.Email = Email;
            this.Address = Address;
            this.IsPrivateBirthDate = IsPrivateBirthDate;
            this.BirthDate = BirthDate;
            this.Phones = new List<PhoneViewModel>();
            foreach(var phone in Phones)
            {
                this.Phones.Add(new PhoneViewModel(phone.PhoneId,phone.ContactId,phone.PhoneTypeId, phone.Number, phone.Type));
            }
            this.ImageMimeType = ImageMimeType;
            this.ImageData = ImageData;
        }
    }
}
