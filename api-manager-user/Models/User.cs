using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api_manager_user.Models
{
    [Table("user")]
    public class User
    {
        [Key]
        public int id { get; private set; }
        public string nome { get; set; }
        public string email { get; set; }
        public string senha { get; set; }
        public DateTime dataDeCadastro { get; set; }


        public User() { }
        public User(string nome, string email, string senha, DateTime dataDeCadastro)
        {
            this.nome = nome ?? throw new ArgumentNullException(nameof(nome));
            this.email = email;
            this.senha = senha;
            this.dataDeCadastro = dataDeCadastro;
        }
    }
}
