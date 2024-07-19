using System.ComponentModel.DataAnnotations;

namespace TipaxSampleApp.ViewModels
{
    public class CustomerViewModel
    {
        /// <summary>
        /// شناسه مشتری
        /// </summary>
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// نام
        /// </summary>
        [Required]
        public string FirstName { get; set; }

        /// <summary>
        /// نام خانوادگی
        /// </summary>
        [Required]
        public string LastName { get; set; }

        /// <summary>
        /// تاریخ تولد
        /// </summary>
        [Required]
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// شماره تماس
        /// </summary>
        [Required]
        public long PhoneNumber { get; set; }

        /// <summary>
        /// ایمیل
        /// </summary>
        [Required]
        public string Email { get; set; }

        /// <summary>
        /// شماره حساب بانکی
        /// </summary>
        [Required]
        public string BankAccountNumber { get; set; }
    }
}