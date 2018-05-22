namespace NCD.Application.Domain
{
    using System;
    using System.ComponentModel.DataAnnotations;

    //public enum CriminalStatus
    //{
    //    Arrested = 1,
    //    Escaped,
    //    Bailed,
    //    Released
    //}

    //public enum Gender
    //{
    //    Female,
    //    Male
    //}

    public class Person
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(25)]
        public string Alias { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        [Required]
        [StringLength(15)]
        public string Gender { get; set; }

        [Range(50, 250)]
        [Required]
        public int Height { get; set; }

        [Range(50, 250)]
        [Required]
        public int Weight { get; set; }

        public int Status { get; set; }

        [StringLength(250)]
        public string Country { get; set; }

    }

}
