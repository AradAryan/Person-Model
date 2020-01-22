using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person_Model
{
    public class PersonInfoModel
    {
        public long Id { get; set; }
        public long RequestId { get; set; }
        public Guid FollowUp { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Seri { get; set; }
        public string Serial { get; set; }
        public int BirthDate { get; set; }
        public string FatherName { get; set; }
        public string IdentityNo { get; set; }
        public long NationalCode { get; set; }
        public bool Almosana { get; set; }
        public int Gender { get; set; }
        public string GenderToString { get { return Gender == 1 ? "مرد" : "زن"; } }
        public bool IsDead { get; set; }
        public string IsDeadToString { get { return Gender == 1 ? "زنده" : "فوت شده"; } }
        public string DeathDate { get; set; }
        public string Message { get; set; }
        public string[] DateString { get; set; }
     //   public PersonPostModel Post { get; set; }
      //  public PersonImageModel PersonalImage { get; set; }
     //   public ExceptionMessageModel ExceptionMessage { get; set; }
        public int State { get; set; }
        public string IP { get; set; }
        public string UserName { get; set; }
        public DateTime InsertDateTime { get; set; }
        public string ZipCode { get; set; }
        public string ZipCodeDescription { get; set; }
    }

}
