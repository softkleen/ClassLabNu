using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLabNu
{
    // Documentação de classes de projeto. - XML Docs 
    public class Usuario
    {
        // atributos (campos)
        private int id;
        private string nome;
        private string email;
        private Nivel nivel;
        private string password;
        private bool ativo;

        // propriedades
        public int Id { get { return id; } }
        public string Nome { get { return nome; } }
        public string Email { get { return email; } set { email = value; } }
        public string Password { get{ return password; } }
        public Nivel Nivel { get { return nivel; } }
        public bool Ativo { get { return ativo; } set { ativo = value; } }


        // métodos Construtores
        public Usuario(int _id = 0)
        {
            id = _id;   
        }
        public Usuario(string nome, string email, Nivel nivel, string password)
        {
            this.nome = nome;
            this.email = email;
            this.password = password;
            this.nivel = nivel; 
            ativo = true;
        }

        public Usuario(int id, string nome, string email, string password, Nivel nivel, bool ativo)
        {
            this.id = id;
            this.nome = nome;
            this.email = email;
            this.password = password;
            this.nivel = nivel;  
            this.ativo = ativo;
        }
        // métodos da classe
        public void Inserir()
        {
            // chamadas de banco e gravo o registro - sp_usuario_inserir

            
        }
        public static Usuario ObterPorId(int _id)
        { 
            Usuario usuario = new Usuario(0);
            var cmd = Banco.Abrir();
            cmd.CommandText = "select * from usuarios where id = " + _id;
            var dr = cmd.ExecuteReader();
            if (dr.Read()) 
            { 
                usuario.id = dr.GetInt32(0);
                usuario.nome = dr.GetString(1);
                usuario.email = dr.GetString(2);
                usuario.password = dr.GetString(3);
                usuario.nivel = Nivel.ObterPorId(dr.GetInt32(4));
                usuario.ativo = dr.GetBoolean(5);
            }
            return usuario;
        }
        public static List<Usuario> Listar()
        {
            List<Usuario> lista = new List<Usuario>();
            var cmd = Banco.Abrir();
            cmd.CommandText = "select * from usuarios";
            var dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lista.Add(new Usuario(
                    dr.GetInt32(0),
                    dr.GetString(1),
                    dr.GetString(2),
                    dr.GetString(3),
                    Nivel.ObterPorId(dr.GetInt32(0)),
                    dr.GetBoolean(4)));
            }
            return lista;

        }
        public static Usuario EfetuarLogin(string email, string senha) 
        {
           Usuario usuario = new Usuario();
            // realiza validação e devolve verdadeiro ou falso
            var cmd = Banco.Abrir();
            cmd.CommandText = "select * from usuarios where email = '"+
                email+"' and senha = md5('"+senha+"')";
            var dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                usuario.id = dr.GetInt32(0);
                usuario.nome = dr.GetString(1);
                usuario.email = dr.GetString(2);
                usuario.password = dr.GetString(3);
                usuario.nivel = Nivel.ObterPorId(dr.GetInt32(4));
                usuario.ativo = dr.GetBoolean(5);
            }
            return usuario;
        }
    }
}
