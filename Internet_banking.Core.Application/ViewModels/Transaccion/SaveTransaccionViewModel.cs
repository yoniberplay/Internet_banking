using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internet_banking.Core.Application.ViewModels.Transaccion
{
    public class SaveTransaccionViewModel
    {

        [Required(ErrorMessage = "Seleccion la cuenta de origen")]
        public int Origen { get; set; }

        [Required(ErrorMessage = "Seleccion la cuenta de destino")]
        public int Destino { get; set; }

        [Required(ErrorMessage = "Especifique un monto valido")]
        [DataType(DataType.Currency)]
        public double Monto { get; set; }

        [Required(ErrorMessage = "Especifique el tipo de transaccion")]
        [DataType(DataType.Currency)]
        public string Tipo { get; set; }

    }
}
