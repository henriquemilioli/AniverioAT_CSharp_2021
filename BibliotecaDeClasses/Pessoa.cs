using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BibliotecaDeClasses
{
    public class Pessoa
    {
        [Key]
        public int Id { get; set; }
        public string _nome { get; set; }
        public string _sobreNome { get; set; }
        [DataType(DataType.Date)]
        public DateTime _birth { get; set; }

        
        public Pessoa(int id, String Nome, String Sobrenome, DateTime data)
        {
            Id = id;
            _nome = Nome;
            _sobreNome = Sobrenome;
            _birth = data;
        }

        public Pessoa(String Nome, String Sobrenome, DateTime data)
        {
            _nome = Nome;
            _sobreNome = Sobrenome;
            _birth = data;
        }

        public int QntosDiasFaltam()
        {
            DateTime today = DateTime.Today;
            DateTime niver = new DateTime(today.Year, _birth.Month, _birth.Day);

            if (niver < today)
            {
                niver = niver.AddYears(1);
            }

            int diasFaltantes = (niver - today).Days;
            return diasFaltantes;
        }
        public override string ToString()
        {
            return " Nome Completo: " + _nome + _sobreNome +
                   "\n Data do Aniversario: " + _birth.Day + "/" + _birth.Month + "/" + _birth.Year
                   + "\n Faltam " + QntosDiasFaltam() + " dias para esse aniversario";
        }
    }
}

