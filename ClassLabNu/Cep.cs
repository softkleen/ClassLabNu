using System;
using System.Data;


namespace ClassLabNu
{
    public class Cep
    {
        #region "Váriavies"  
        string _uf;
        string _localidade;
        string _bairro;
        string _lagradouro;
        string _resultado;
        string _resultato_txt;
        #endregion

        #region "Propiedades"  
        public string UF
        {
            get { return _uf; }
        }
        public string Cidade
        {
            get { return _localidade; }
        }
        public string Bairro
        {
            get { return _bairro; }
        }
        public string Lagradouro
        {
            get { return _lagradouro; }
        }
        public string Resultado
        {
            get { return _resultado; }
        }
        public string ResultadoTXT
        {
            get { return _resultato_txt; }
        }
        #endregion
        #region "Construtor"  
        /// <summary>  
        /// WebService para Busca de CEP  
        ///  </summary>  
        /// <param  name="CEP"></param>  
        public Cep(string CEP)
        {
            
            _uf = "";
            _localidade = "";
            _bairro = "";
            _lagradouro = "";
            _resultado = "0";
            _resultato_txt = "CEP não encontrado";
            //Cria um DataSet  baseado no retorno do XML  
            DataSet ds = new DataSet();
            ds.ReadXml("http://viacep.com.br/ws/"+CEP+"/xml");
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    _uf = ds.Tables[0].Rows[0]["uf"].ToString().Trim();
                    _localidade = ds.Tables[0].Rows[0]["localidade"].ToString().Trim();
                    _bairro = ds.Tables[0].Rows[0]["bairro"].ToString().Trim();
                    _lagradouro = ds.Tables[0].Rows[0]["logradouro"].ToString().Trim();
                    _resultato_txt = "CEP completo"; 
                }
            }

//<? xml version = "1.0" encoding = "UTF-8" ?>
//< xmlcep >
//< cep > 01001 - 000 </ cep >
//< logradouro > Praça da Sé </ logradouro >
//< complemento > lado ímpar </ complemento >
//< bairro > Sé </ bairro >
//< localidade > São Paulo </ localidade >
//< uf > SP </ uf >
//< ibge > 3550308 </ ibge >
//< gia > 1004 </ gia >
//< ddd > 11 </ ddd >
//< siafi > 7107 </ siafi >
//</ xmlcep >

        }
        #endregion
    }
}
