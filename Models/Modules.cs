using System.ComponentModel.DataAnnotations;

namespace Time_Management.Models
{
    public class Modules
    {

        //add prperties to the  Module plannin class
        // (Troelsen and Japikse, 2017)
        public int Id { get; set; }
        public String Module_Name { get; set; }
        public String Module_Code { get; set; }
        public int Module_Credits { get; set; }
        public int Weekly_Class_Hours { get; set; }

        // number of weeks in a semester for that module
        public int Semester_Weeks { get; set; }

        
        public int Semester { get; set; }
        [DataType(DataType.Date)]
        public DateTime Semester_Start_Date { get; set; }



        public Modules()
        {

         


    }

}
}
