using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    [Table("Categories")]
    public class Category
    {
        private string _name;

        public Category(string name) 
        {
            _name = name;
        }

        //For EF
        public Category() : this("") { }

        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity), Key()]
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Name
        {
            get => this._name;
            set => this._name = value;
        }
    }
}
