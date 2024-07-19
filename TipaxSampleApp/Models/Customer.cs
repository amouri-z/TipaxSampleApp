namespace TipaxSampleApp.Models
{
    public class Customer
    {
        public int Id { get; set; }

        /// <summary>
        /// نام
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// نام خانوادگی
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// تاریخ تولد
        /// </summary>
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// شماره تماس
        /// </summary>
        public long PhoneNumber { get; set; }

        /// <summary>
        /// ایمیل
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// شماره حساب بانکی
        /// </summary>
        public string BankAccountNumber { get; set; }
    }
}