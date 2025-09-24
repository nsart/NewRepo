using System.ComponentModel.DataAnnotations;

namespace HW3_Task1.Models
{
    public class CalcModel
    {
        public decimal? Num1 { get; set; }       
        public decimal? Num2 { get; set; }
        public string? OperationName { get; set; }
        public decimal? Result { get; set; }            
    }
}
