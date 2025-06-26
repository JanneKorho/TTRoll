using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TTRoll.Models
{
    public class Character
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
        [Required]
        public string Name { get; set; }
        [Required]
        public string Class {  get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Level must be above 0")]
        public int Level { get; set; }
        [DisplayName("Maximum HP")]
        [Range(1, int.MaxValue, ErrorMessage = "Maximum HP must be above 0")]
        public int MaxHP { get; set; }
        public int CurrentHP { get; set; }
        [DisplayName("Armor Class")]
        [Range(1, int.MaxValue, ErrorMessage = "Armor class must be above 0")]
        public int ArmorClass { get; set; }
        public int Initiative { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Speed must be above 0")]
        public int Speed { get; set; }
        [DisplayName("Proficiency Bonus")]
        public int ProficiencyBonus { get; set; }
    }
}
