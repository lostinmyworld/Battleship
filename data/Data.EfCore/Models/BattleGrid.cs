using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.EfCore.Models
{
    public class BattleGrid
    {
        [Key]
        [DatabaseGenerat‌ed(DatabaseGeneratedOp‌​tion.None)]
        public int Id { get; set; }
        public int HorizontalDimension { get; set; }
        public int VerticalDimension { get; set; }
    }
}
