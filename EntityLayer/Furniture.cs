using System.ComponentModel.DataAnnotations;

namespace EntityLayer
{
    public class Furniture
    {
        [Range(1,500,ErrorMessage ="invalid id")]
        public int Fid { get; set; }
       
        [Required(ErrorMessage = "Name entry required")]
        public String Fname { get; set; }

        public Furniture()
        {
            Fid = 1;
            Fname = "default";
        }

        public Furniture(int id,string n)
        {
            Fid = id;
            Fname = n;
        }
    }
}