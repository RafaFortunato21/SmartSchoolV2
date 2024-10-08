namespace SmartSchoolV2.WebAPI.Models
{
    public class Aluno
    {
        public Aluno(){}

        public Aluno(int id, string nome, string sobrNome, string telefone) 
        {
            this.Id = id;
            this.Nome = nome;
            this.SobreNome = sobrNome;
            this.Telefone = telefone;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public string Telefone { get; set; }

        public IEnumerable<AlunoDisciplina> AlunosDisciplinas { get; set; }
        

    }
}