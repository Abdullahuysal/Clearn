using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Clearn.Models
{
       [Table("Users")]
    public class UserData
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        [StringLength(20), Required(ErrorMessage ="kullanıcı adı boş bırakılamaz")]
        public string UserFirstName { get; set; }
        [StringLength(20), Required(ErrorMessage = "kullanıcı soyadı boş bırakılamaz")]
        public string UserSecondName { get; set; }
        [StringLength(50), Required(ErrorMessage = "kullanıcı E-mail'i boş bırakılamaz")]
        public string UserEmail { get; set; }
        [StringLength(50), Required(ErrorMessage = "kullanıcı Şifresi boş bırakılamaz")]
        public string UserPassword{ get; set; }

    }
}