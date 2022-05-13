using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Notificition
    {
        [Key]
        public int NotificitionID { get; set; }
        public string NotificitionType { get; set; }
        public string NotificitionTypeSymbol { get; set; }
        public string NotificitionDetails { get; set; }
        public DateTime NotificitionDate { get; set; }
        public bool NotificitionStatus { get; set; }
        public string NotificitionColor { get; set; }
      
      
    }
}
